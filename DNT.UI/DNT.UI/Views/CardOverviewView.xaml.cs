using DNT.UI.ViewModels.OverviewViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace DNT.UI.Views
{
    /// <summary>
    /// Interaction logic for CardOverviewView.xaml
    /// </summary>
    public partial class CardOverviewView : UserControl
    {
        public CardOverviewView()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<CardOverviewViewModel>();
        }
    }
}
