using DNT.UI.ViewModels.EditViewModels;
using System.Windows.Controls;

namespace DNT.UI.Views
{
    /// <summary>
    /// Interaction logic for EditCompanyView.xaml
    /// </summary>
    public partial class EditCompanyView : UserControl
    {
        private EditCompanyViewModel _model;
        public EditCompanyView(EditCompanyViewModel model)
        {
            InitializeComponent();
            _model = model;
            DataContext = _model;
            Loaded += _editCompanyView_Loaded;

        }

        private async void _editCompanyView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await _model.LoadCards();
        }
    }
}
