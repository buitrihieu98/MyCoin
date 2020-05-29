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
    /// Interaction logic for CreateTransaction.xaml
    /// </summary>
    public partial class CreateTransaction : Window
    {
        public CreateTransaction()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (recipientTextBox.Text == "")
            {
                MessageBox.Show("Recipient's public key cannot be empty");
            }
            if (senderTextBox.Text == "")
            {
                MessageBox.Show("Sender's public key cannot be empty");
            }
            if (amountTextBox.Text == "")
            {
                MessageBox.Show("Amount cannot be empty");
            }
            
            else
            {
                var newTransaction = new Transaction(Int32.Parse(amountTextBox.Text),recipientTextBox.Text,senderTextBox.Text,1);
                //if (newTransaction.isTransactionValid())
                //{
                    MyCoin.MainWindow.transactions.Add(newTransaction);
                    var newBlock = new Block(MyCoin.MainWindow.blockChain.Count - 1, MyCoin.MainWindow.blockChain.ElementAt(MyCoin.MainWindow.blockChain.Count - 1).hash, newTransaction, newTransaction.Sender);
                    MyCoin.MainWindow.blockChain.Add(newBlock);
                    //Console.WriteLine("Trying to Mine block ... ");
                    MessageBox.Show("Trying to mine block");
                    MyCoin.MainWindow.blockChain.ElementAt(MyCoin.MainWindow.blockChain.Count - 1).MineBlock(MyCoin.MainWindow.difficulty);
                    MessageBox.Show("Block Mined with Nonce:" + newBlock.nonce);
                    Console.WriteLine("\nBlockchain is Valid: " + MyCoin.MainWindow.IsChainValid());
                //}
                DialogResult = true;
                Close();


            }
        }
    }
}
