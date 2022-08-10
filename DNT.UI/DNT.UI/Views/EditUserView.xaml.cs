using DNT.UI.ViewModels.EditViewModels;
using System.Windows.Controls;

namespace DNT.UI.Views
{
    /// <summary>
    /// Interaction logic for EditUserView.xaml
    /// </summary>
    public partial class EditUserView : UserControl
    {
        private readonly EditUserViewModel _model;

        public EditUserView(EditUserViewModel model)
        {
            InitializeComponent();
            _model = model;
            DataContext = _model;
        }
    }
}
