using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using DNT.UI.Enums;
using DNT.UI.Utils;
using DNT.UI.ViewModels.Base;
using DNT.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
namespace DNT.UI.ViewModels.EditViewModels
{
    public class EditCompanyViewModel : CardOwnerBase<Company>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Private fields
        private readonly ICompanyRepository _repository;
        #endregion

        public EditCompanyViewModel(ICompanyRepository repository, ICardRepository cardRepository) 
        {
            _repository = repository;
            CardRepository = cardRepository;
        }

        #region Abstract implemetations
        protected override async Task Save()
        {
            if (!Validate()) return;

            if (ForUpdate)
            {
                await _repository.Update(Model);
                DialogManager.ShowMessage("Firma uspješno ažurirana", OperationResult.Success);
            }
            else
            {
                await _repository.Create(Model);
                DialogManager.ShowMessage("Firma uspješno dodana", OperationResult.Success);
                Model.Id = await _repository.GetLastInsertedId();
            }
        }

        protected override void AddValidationRules()
        {
            //throw new System.NotImplementedException();
        }

        public override async Task LoadCards()
        {
            var list = (await CardRepository.GetCardsForCompany(Model));
            Cards = new ObservableCollection<Card>(list);
        }

        protected override void AddCard()
        {
            var window = DialogManager.ShowCustomDialogWindow("", 500);
            var viewModel = App.ServiceProvider.GetRequiredService<EditCardViewModel>();
            viewModel.Model = new Card { Company = Model};

            window.Content = new EditCardView(viewModel);

            window.ShowDialog();
        }
        #endregion
    }
}
