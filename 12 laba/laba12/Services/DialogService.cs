using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace laba12.Services
{
    public class DialogService : IDialogService
    {
        public void ShowInfo(string message, string title = "Information")
        {
            MessageBox.Show(message, title);
        }
        public void ShowWarning(string message, string title = "Warning")
        {
            MessageBox.Show(message, title);
        }
        public void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title);
        }
        public bool ShowConfirmation(string message, string title = "Confirmation")
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNoCancel);
            return result == MessageBoxResult.Yes;
        }
    }
}