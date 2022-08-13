using DNT.UI.Enums;
using DNT.UI.Views.Dialogs;
using MahApps.Metro.Controls;
using System.Windows;

namespace DNT.UI.Utils
{
    internal class DialogManager
    {
        public static DialogResult ShowDialog(string message)
        {
            var window = CreateWindow();
            var control = new DialogYesNo(window, message);
            window.Content = control;
            window.ShowDialog();

            return control.Result;
        }

        public static void ShowMessage(string message, OperationResult operationResult)
        {
            var window = CreateWindow();
            var control = new DialogMessage(window, message, operationResult);
            window.Content = control;
            window.ShowDialog();
        }

        private static MetroWindow CreateWindow()
        {
            var window = new MetroWindow();
            window.Height = 100;
            window.Width = 800;
            window.ShowMinButton = false;
            window.ShowMaxRestoreButton = false;
            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            return window;
        }

        public static Window ShowCustomDialogWindow(string title, int height)
        {
            var window = new MetroWindow
            {
                WindowState = WindowState.Normal,
                Width = 550,
                Height = height,
                Title = title,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            return window;
        }
    }
}
