using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemensTopSite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var lastSavedAddress = Properties.Settings.Default.LastSiteAddress;
            handleAddress(lastSavedAddress);
        }

        private void showAlert(string title, string message)
        {
            MessageBox.Show(message, title);
        }

        private void handleAddress(string address)
        {
            addressTextBox.Text = address;
            if (address.StartsWith("https://") == false)
            {
                address = "https://" + address;
            }
            try
            {
                webView.Source = new Uri(address);
                Properties.Settings.Default.LastSiteAddress = address;
                Properties.Settings.Default.Save();
            }
            catch (Exception exception)
            {
                showAlert("Error!", $"{exception.Message}: {address}");
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var address = addressTextBox.Text;
                handleAddress(address);
            }
        }
    }
}
