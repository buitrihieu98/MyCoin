using System;
using System.Text;

namespace MyCoin
{
    internal class HashSha256
    {
        public string Hash(string Input)
        {
            try
            {
                var crypt = new System.Security.Cryptography.SHA256Managed();
                var hash = new System.Text.StringBuilder();
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(Input));
                foreach (byte theByte in crypto)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        

    }
}