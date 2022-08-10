using DNT.UI.Enums;
using System.Windows;
using System.Windows.Controls;

namespace DNT.UI.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogYesNo.xaml
    /// </summary>
    public partial class DialogYesNo : UserControl
    {
        private readonly Window _window;

        public DialogResult Result { get; set; }


        public DialogYesNo(Window window, string message)
        {
            InitializeComponent();
            _window = window;
            Message.Text = message;
        }

        private void btn_yes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Result = DialogResult.Yes;
            _window.Close();
        }

        private void btn_no_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Result = DialogResult.No;
            _window.Close();
        }
    }
}
