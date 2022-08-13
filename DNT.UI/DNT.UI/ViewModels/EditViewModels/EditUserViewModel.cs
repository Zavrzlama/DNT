using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using DNT.UI.Enums;
using DNT.UI.Utils;
using DNT.UI.ViewModels.Base;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmValidation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DNT.UI.ViewModels.EditViewModels
{
    public class EditUserViewModel : CardOwnerBase<User>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Private fields
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        #endregion

        public IList<Company> Companies { get; set; }
        
        #region Commands
        public ICommand LoadCompaniesCommand { get; set; }
        #endregion

        private async Task LoadCompanies()
        {
            Companies = (await _companyRepository.GetAll()).ToList();
        }

        public EditUserViewModel(IUserRepository userRepository,ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;

            LoadCompaniesCommand = new AsyncRelayCommand(LoadCompanies);
            LoadCompaniesCommand.Execute(null);
            LoadCardsCommand.Execute(null);
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

        #region Abstract impelenatation
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
        
        protected override Task SaveCard()
        {
            throw new System.NotImplementedException();
        }

        protected override async Task LoadCards()
        {
            var list = (await CardRepository.GetCardsForUser(Model)).ToList();
            Cards = new ObservableCollection<Card>(list);
        }

        protected override void AddCard()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}

