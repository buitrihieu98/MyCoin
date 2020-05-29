using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyCoin
{
    /// <summary>
    /// Interaction logic for CreateNewWalletDialog.xaml
    /// </summary>
    public partial class CreateNewWalletDialog : Window
    {
        public CreateNewWalletDialog()
        {
            InitializeComponent();
        }
        
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Name cannot be empty");
            }
            if (balanceTextBox.Text == "")
            {
                MessageBox.Show("Init balance cannot be empty");
            }
            else
            {
                var newWallet = new Wallet(nameTextBox.Text, Int32.Parse(balanceTextBox.Text));
                Console.WriteLine($"name: {newWallet.name} private key: {newWallet.privateKey} public key: {newWallet.publicKey}");
                MyCoin.MainWindow.wallets.Add(newWallet);
                DialogResult = true;
                Close();
                
                
            }
        }
    }
}
