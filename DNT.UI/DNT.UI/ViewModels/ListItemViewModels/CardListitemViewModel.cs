using DNT.UI.ViewModels.Interfaces;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DNT.UI.ViewModels.ListItemViewModels
{
    public class CardListitemViewModel : IListItem
    {
        public string Label { get; set; }
        public ImageSource Image { get; set; }

        public CardListitemViewModel()
        {
            Label = "Kartice";
            Image = new BitmapImage(new Uri("../../Assets/Images/Card.png", UriKind.Relative));
        }
    }
}
