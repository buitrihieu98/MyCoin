using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin
{
    public class Transaction
    {
        //public int Id { get; set; }
        public int Amount { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; }
        //public string Signature { get; set; }
        public int Fees { get; set; }
        
        public Transaction(int amount, string recipient, string sender, int fees )
        {
            this.Amount = amount;
            this.Recipient = recipient;
            this.Sender = sender;
            this.Fees = fees;
        }

        public bool isTransactionValid()
        {
            var senderWallet = MyCoin.MainWindow.walletWithPublicKey(this.Sender);
            if (MyCoin.MainWindow.isValidPublicKey(this.Recipient) &&(this.Amount + this.Fees > senderWallet.balance))
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}
