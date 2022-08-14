using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using DNT.UI.Enums;
using DNT.UI.Utils;
using DNT.UI.ViewModels.Base;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DNT.UI.ViewModels.EditViewModels
{
    public class EditCardViewModel : CodebookBase<Card>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ICardRepository _cardRepository;

        public EditCardViewModel(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
            SaveCard = new RelayCommand(SaveCar);

        }

        public ICommand SaveCard { get; set; }

        protected async override Task Save()
        {
            if (!Validate()) return;

            if (ForUpdate)
            {
                await _cardRepository.Update(Model);
                DialogManager.ShowMessage("Kartica uspješno ažurirana", OperationResult.Success);
            }
            else
            {
                await _cardRepository.Create(Model);
                DialogManager.ShowMessage("Kartica uspješno dodana", OperationResult.Success);
            }
        }

        private void SaveCar()
        {
            _cardRepository.Create(Model);
        }

        protected override void AddValidationRules()
        {
            //throw new NotImplementedException();
        }
    }
}
