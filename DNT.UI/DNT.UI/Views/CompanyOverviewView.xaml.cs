using DNT.UI.ViewModels.OverviewViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace DNT.UI.Views
{
    /// <summary>
    /// Interaction logic for CompanyOverviewView.xaml
    /// </summary>
    public partial class CompanyOverviewView : UserControl
    {
        public CompanyOverviewView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<CompanyOverviewViewModel>();
        }
    }
}
