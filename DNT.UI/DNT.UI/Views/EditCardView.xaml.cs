using DNT.UI.ViewModels.EditViewModels;
using System.Windows.Controls;

namespace DNT.UI.Views
{
    /// <summary>
    /// Interaction logic for EditCardView.xaml
    /// </summary>
    public partial class EditCardView : UserControl
    {
        public EditCardView(EditCardViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }

    }
}
