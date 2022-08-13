using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DNT.UI.ViewModels.Base
{
    public abstract class CardOwnerBase<T> : CodebookBase<T>
    {
        protected ICardRepository CardRepository { get; set; }
        public ObservableCollection<Card> Cards { get; set; }
        public Card SelectedCard { get; set; }

        #region Commands
        public ICommand AddCardCommand { get; set; }
        public ICommand SaveCardCommand { get; set; }
        public ICommand LoadCardsCommand { get; set; }
        #endregion

        #region Command handlers
        protected abstract Task SaveCard();
        protected abstract Task LoadCards();
        protected abstract void AddCard();
        #endregion

        public CardOwnerBase()
        {
            SaveCardCommand = new AsyncRelayCommand(SaveCard);
            LoadCardsCommand = new AsyncRelayCommand(LoadCards);
            AddCardCommand = new RelayCommand(AddCard);
        }

        


    }
}
