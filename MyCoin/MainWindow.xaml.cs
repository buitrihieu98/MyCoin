using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows;

namespace MyCoin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static BindingList<Block> blockChain =new BindingList<Block>();
        public static BindingList<Wallet> wallets = new BindingList<Wallet>();
        public int difficulty = 5; //tự quy định độ khó = 5

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var wallet1 = new Wallet("Hieu", 20);
            var wallet2 = new Wallet("Thao", 50);
            Console.WriteLine($"name: {wallet1.name} private key: {wallet1.privateKey} public key: {wallet1.publicKey}");
            Console.WriteLine($"name: {wallet2.name} private key: {wallet2.privateKey} public key: {wallet2.publicKey}");
            
            var transaction1 = new Transaction(10, wallet2.publicKey, wallet1.publicKey, 1);
            var transaction2 = new Transaction(10, wallet1.publicKey, wallet2.publicKey, 1);
            var transaction3 = new Transaction(20, wallet1.publicKey, wallet2.publicKey, 1);
            List<Transaction> transactions1 = new List<Transaction>();
            transactions1.Add(transaction1);
            transactions1.Add(transaction2);
            transactions1.Add(transaction3);
            List<Transaction> transactions2 = new List<Transaction>();
            transactions2.Add(transaction1);
            transactions2.Add(transaction2);
            List<Transaction> transactions3 = new List<Transaction>();
            transactions3.Add(transaction3);
            transactions3.Add(transaction2);

            blockChain.Add(new Block(0,"0",transactions1, "Admin"));
            Console.WriteLine("Trying to Mine block 1... ");
            blockChain.ElementAt(0).MineBlock(difficulty);
            Console.WriteLine("\nBlockchain is Valid: " + IsChainValid());

            blockChain.Add(new Block(blockChain.Count-1, blockChain.ElementAt(blockChain.Count - 1).hash,transactions2,"Someone"));
            Console.WriteLine("Trying to Mine block 2... ");
            blockChain.ElementAt(blockChain.Count - 1).MineBlock(difficulty);
            Console.WriteLine("\nBlockchain is Valid: " + IsChainValid());

            blockChain.Add(new Block(blockChain.Count-1, blockChain.ElementAt(blockChain.Count - 1).hash,transactions3,"Hieu"));
            Console.WriteLine("Trying to Mine block 3... ");
            blockChain.ElementAt(blockChain.Count - 1).MineBlock(difficulty);
            Console.WriteLine("\nBlockchain is Valid: " + IsChainValid());

            string printBlockChain = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(blockChain);
            Console.WriteLine(printBlockChain);
            
            Console.ReadLine();
        }

        public static Boolean IsChainValid()
        {
            Block currentBlock;
            Block previousBlock;

            //loop through blockchain to check hashes:
            for (int i = 1; i < blockChain.Count; i++)
            {
                currentBlock = blockChain.ElementAt(i);
                previousBlock = blockChain.ElementAt(i - 1);

                //compare registered hash and calculated hash:
                if (!currentBlock.hash.Equals(currentBlock.CalculateHash()))
                {
                    Console.WriteLine("Current Hashes not equal");
                    return false;
                }

                //compare previous hash and registered previous hash
                if (!previousBlock.hash.Equals(currentBlock.previousHash))
                {
                    Console.WriteLine("Previous Hashes not equal");
                    return false;
                }
            }
            return true;
        }


    }
}
