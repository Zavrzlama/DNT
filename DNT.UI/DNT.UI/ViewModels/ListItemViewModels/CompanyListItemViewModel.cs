using DNT.UI.ViewModels.Interfaces;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DNT.UI.ViewModels.ListItemViewModels
{
    public class CompanyListItemViewModel : IListItem
    {
        public string Label { get; set; }
        public ImageSource Image { get; set; }

        public CompanyListItemViewModel()
        {
            Label = "Pravne osobe";
            Image = new BitmapImage(new Uri("../../Assets/Images/Company.png", UriKind.Relative));
        }
    }
}
