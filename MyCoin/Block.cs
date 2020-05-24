using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin
{
    class Block
    {
        public String hash;
        public String previousHash;
        private String data; 
        private long timeStamp; 
        private int nonce = 0;

        //Block Constructor.
        public Block(String data, String previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;
            //this.timeStamp = DatetimeHandle.GetTime();
            this.hash = CalculateHash();
        }

        private string CalculateHash()
        {
            throw new NotImplementedException();
        }
    }
}
