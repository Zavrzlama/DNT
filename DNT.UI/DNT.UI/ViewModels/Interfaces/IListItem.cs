using System.Windows.Media;

namespace DNT.UI.ViewModels.Interfaces
{
    public interface IListItem
    {
        public string Label { get; set; }
        public ImageSource Image { get; set; }
    }
}
