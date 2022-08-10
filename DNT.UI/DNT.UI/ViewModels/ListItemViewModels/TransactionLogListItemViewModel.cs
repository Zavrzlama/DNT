using DNT.UI.ViewModels.Interfaces;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DNT.UI.ViewModels.ListItemViewModels
{
    public class TransactionLogListItemViewModel : IListItem
    {
        public string Label { get; set; }
        public ImageSource Image { get; set; }

        public TransactionLogListItemViewModel()
        {
            Label = "Transakcije";
            Image = new BitmapImage(new Uri("../../Assets/Images/TransactionLog.png", UriKind.Relative));
        }
    }
}
