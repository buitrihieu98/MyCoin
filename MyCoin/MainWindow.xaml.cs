using System;
using System.Collections.Generic;
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

        public static List<Block> blockChain =new List<Block>();
        public int difficulty = 5;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            blockChain.Add(new Block("Hi im the first block", "0"));
            Console.WriteLine("Trying to Mine block 1... ");
            blockChain.ElementAt(0).MineBlock(difficulty);

            blockChain.Add(new Block("Yo im the second block", blockChain.ElementAt(blockChain.Count - 1).hash));
            Console.WriteLine("Trying to Mine block 2... ");
            blockChain.ElementAt(blockChain.Count - 1).MineBlock(difficulty);

            blockChain.Add(new Block("Hey im the third block", blockChain.ElementAt(blockChain.Count - 1).hash));
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
