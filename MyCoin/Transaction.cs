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
        public override string ToString()
        {
            return Amount.ToString("0.00000000") + Recipient + Sender;
        }
        public Transaction(int amount, string recipient, string sender, int fees )
        {
            this.Amount = amount;
            this.Recipient = recipient;
            this.Sender = sender;
            this.Fees = fees;
        }

        public bool isTransactionValid()
        {
            return true;
        }
    }
}
