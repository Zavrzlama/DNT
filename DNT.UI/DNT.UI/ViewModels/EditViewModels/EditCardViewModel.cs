using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using DNT.UI.Enums;
using DNT.UI.Utils;
using DNT.UI.ViewModels.Base;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DNT.UI.ViewModels.EditViewModels
{
    public class EditCardViewModel : CodebookBase<Card>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ICardRepository _cardRepository;

        public EditCardViewModel(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        protected async override Task Save()
        {
            if (!Validate()) return;

            if (ForUpdate)
            {
                await _cardRepository.Update(Model);
                DialogManager.ShowMessage("Kartica uspješno ažurirana", OperationResult.Success);
                Window.Close();
            }
            else
            {
                await _cardRepository.Create(Model);
                DialogManager.ShowMessage("Kartica uspješno dodana", OperationResult.Success);
                Window.Close();
            }
        }

        protected override void AddValidationRules()
        {
            throw new NotImplementedException();
        }
    }
}
