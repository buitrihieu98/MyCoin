using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin
{
    public class Wallet
    {
        public string name { get; set; }
        public string publicKey { get; set; }
        public string privateKey { get; set; }
        public int balance { get; set; }
        
        public int calculateBalance (List<Block> blockChain)
        {
            int balance = 0;
            int spending = 0;
            int income = 0;

            foreach (Block block in blockChain)
            {
                var transactions = block.transactions;

                foreach (Transaction transaction in transactions)
                {

                    var sender = transaction.Sender;
                    var recipient = transaction.Recipient;

                    if (this.publicKey.ToLower().Equals(sender.ToLower()))
                    {
                        spending += transaction.Amount + transaction.Fees;
                    }


                    if (this.publicKey.ToLower().Equals(recipient.ToLower()))
                    {
                        income += transaction.Amount;
                    }

                    balance = income - spending;
                }
            }
            return balance;
        }
        static string ToHex(byte[] data) => String.Concat(data.Select(x => x.ToString("x2")));
        
        public Wallet(string name, int initBalance)
        {
            this.name = name;
            this.balance = initBalance;
            var curve = ECNamedCurveTable.GetByName("secp256k1");
            var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());
            var secureRandom = new SecureRandom();
            var keyParams = new ECKeyGenerationParameters(domainParams, secureRandom);
            var generator = new ECKeyPairGenerator("ECDSA");
            generator.Init(keyParams);
            var keyPair = generator.GenerateKeyPair();
            var privateKey = keyPair.Private as ECPrivateKeyParameters;
            var publicKey = keyPair.Public as ECPublicKeyParameters;
            this.privateKey = ToHex(privateKey.D.ToByteArrayUnsigned());
            this.publicKey = ToHex(publicKey.Q.GetEncoded());
        }

    }
}
