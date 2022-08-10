using DNT.UI.ViewModels.EditViewModels;
using System.Windows.Controls;

namespace DNT.UI.Views
{
    /// <summary>
    /// Interaction logic for EditCompanyView.xaml
    /// </summary>
    public partial class EditCompanyView : UserControl
    {
        public EditCompanyView(EditCompanyViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
