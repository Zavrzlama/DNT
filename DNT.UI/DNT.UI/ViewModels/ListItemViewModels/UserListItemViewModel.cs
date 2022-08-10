using DNT.UI.ViewModels.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DNT.UI.ViewModels.ListItemViewModels
{
    public class UserListItemViewModel : IListItem, INotifyPropertyChanged
    {
        public string Label { get; set; }
        public ImageSource Image { get; set; }

        public UserListItemViewModel()
        {
            Label = "Korisnici";
            Image = new BitmapImage(new Uri("../../Assets/Images/User.png", UriKind.Relative));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
