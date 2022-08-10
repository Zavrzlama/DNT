using DNT.UI.Enums;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DNT.UI.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogMessage.xaml
    /// </summary>
    public partial class DialogMessage : UserControl
    {

        private Window _window;
        private OperationResult _operationResult;
        public DialogMessage(Window window, string message, OperationResult operationSuccess)
        {
            InitializeComponent();
            _window = window;
            _operationResult = operationSuccess;

            Message.Text = message;

            if (operationSuccess == OperationResult.Success)
                ResultImage.Source = new BitmapImage(new Uri("../../Assets/Images/Check.png", UriKind.Relative));
            else
                ResultImage.Source = new BitmapImage(new Uri("../../Assets/Images/Failed.png", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _window.Close();
        }
    }
}
