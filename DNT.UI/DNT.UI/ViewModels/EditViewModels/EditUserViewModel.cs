using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using DNT.UI.Enums;
using DNT.UI.Utils;
using DNT.UI.ViewModels.Base;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmValidation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DNT.UI.ViewModels.EditViewModels
{
    public class EditUserViewModel : CodebookBase<User>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Private fields
        private readonly IUserRepository _userRepository;
        private readonly ICardRepository _cardRepository;
        private readonly ICompanyRepository _companyRepository;
        #endregion

        #region Bindings
        public List<Card> Cards { get; set; }
        public List<Company> Companies { get; set; }
        #endregion

        #region Commands
        public ICommand LoadCardsCommand { get; set; }
        public ICommand LoadCompaniesCommand { get; set; }
        #endregion

        private async Task LoadCards()
        {
            Cards = (await _cardRepository.GetAll()).ToList();
        }

        private async Task LoadCompanies()
        {
            Companies = (await _companyRepository.GetAll()).ToList();
        }

        public EditUserViewModel(IUserRepository userRepository, ICardRepository cardRepository, ICompanyRepository companyRepository)
        {
            InitializeCommands();

            _userRepository = userRepository;
            _cardRepository = cardRepository;
            _companyRepository = companyRepository;

            LoadCardsCommand.Execute(null);
            LoadCompaniesCommand.Execute(null);

        }

        protected override async Task Save()
        {
            if (!Validate()) return;
            
            if (ForUpdate)
            {
                await _userRepository.Update(Model);
                DialogManager.ShowMessage("Korinisk uspješno ažuriran", OperationResult.Success);
                Window.Close();
            }
            else
            {
                await _userRepository.Create(Model);
                DialogManager.ShowMessage("Korisnik uspješno dodan", OperationResult.Success);
                Window.Close();
            }
        }

        protected override void AddValidationRules()
        {
            Validator.AddRule(() => Model.Name,
                () =>
                {
                    return RuleResult.Assert(!string.IsNullOrEmpty(Model.Name), "Ime je obavezan podatak");
                });

            Validator.AddRule(() => Model.Surname,
                () =>
                {
                    return RuleResult.Assert(!string.IsNullOrEmpty(Model.Surname), "Prezime je obavezan podatak");
                });
            Validator.AddRule(() => Model.Surname,
                () =>
                {
                    return RuleResult.Assert(Model.Company != null, "Firma je obavezan podatak");
                });
        }
        private void InitializeCommands()
        {
            LoadCardsCommand = new AsyncRelayCommand(LoadCards);
            LoadCompaniesCommand = new AsyncRelayCommand(LoadCompanies);
        }
    }
}

