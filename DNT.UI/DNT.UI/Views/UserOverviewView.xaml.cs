using DNT.UI.ViewModels.OverviewViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace DNT.UI.Views
{
    /// <summary>
    /// Interaction logic for UserOverviewView.xaml
    /// </summary>
    public partial class UserOverviewView : UserControl
    {
        public UserOverviewView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<UserOverviewViewModel>();   
        }
    }
}
