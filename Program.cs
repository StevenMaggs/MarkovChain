using System;

namespace MarkovChainNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt = "Kevin Steven Thomas Timothy Christina Kyle Rachel Laura Lauren Amber Brittany Danielle Richard Kimin Mark Emily Aaron";
            
            Console.WriteLine(MarkovChain.GenerateName(4, 10, txt, 2));
        }
    }
}
