using DNT.UI.ViewModels.Interfaces;
using DNT.UI.ViewModels.ListItemViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace DNT.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<IListItem> ItemList { get; set; }

        public IListItem SelectedItem { get; set; }

        public MainViewModel()
        {
            RegisterItems();
        }

        

        private void RegisterItems()
        {
            ItemList = new List<IListItem>();
            ItemList.Add(new TransactionLogListItemViewModel());
            ItemList.Add(new CompanyListItemViewModel());
            ItemList.Add(new UserListItemViewModel());
            ItemList.Add(new CardListitemViewModel());
        }
    }
}
