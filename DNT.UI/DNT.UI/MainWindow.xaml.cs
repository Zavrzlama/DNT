using DNT.UI.ViewModels;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace DNT.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<MainViewModel>();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            WindowState = System.Windows.WindowState.Maximized;

        }
    }
}
