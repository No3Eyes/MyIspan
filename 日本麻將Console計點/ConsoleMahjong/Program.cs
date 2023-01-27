using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleMahjong
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            int x = 0;
            while (true)
            {
                int Fan, Fu;
                Console.Write("請輸入翻數:");
                Fan = Convert.ToInt32(Console.ReadLine());
                Console.Write("請輸入符數:");
                Fu = Convert.ToInt32(Console.ReadLine());
                if (Fu == 25) { Fu = 25; }
                else
                {
                    if (Fu % 10 != 0) { Fu = ((Fu / 10) + 1) * 10; }
                }
                if (Fan > 13) { Fan = 13; }
                if (Fu > 110) { Fu = 110; }
                double Basic = Fu * Math.Pow(2, Fan + 2);
                if (Basic >= 2000)
                {
                    if ((Fan == 4 && Fu >= 40) || Fan == 5 || (Fan == 3 && Fu >= 70))
                    { Basic = 2000; }
                    else if (Fan == 6 || Fan == 7) { Basic = 3000; }
                    else if (Fan == 8 || Fan == 9 || Fan == 10) { Basic = 4000; }
                    else if (Fan == 11 || Fan == 12) { Basic = 6000; }
                    else if (Fan == 13) { Basic = 8000; }
                }
                int BasicI = (int)Basic;
                Console.Write("請問是否為莊家(Y/N):");
                string chin = Console.ReadLine();
                if (chin == "Y" || chin == "y")
                {
                    if (((Fan == 1 || Fan == 2 || Fan == 3) && (Fu == 30 || Fu == 40)) ||
                        (Fan == 3 && Fu == 60) || (Fan == 4 && Fu == 30))
                    {
                        Console.WriteLine($"({6 * BasicI / 100 * 100 + 100}),({2 * BasicI / 100 * 100 + 100} all)");
                    }
                    else if (Fan == 1 && (Fu == 20 || Fu == 25))
                    {
                        Console.WriteLine("(-),(-)");
                    }
                    else if (Fan == 2 && Fu == 25)
                    {
                        Console.WriteLine($"({6 * BasicI / 100 * 100}),(-)");
                    }
                    else if (Fu == 20 && (Fan == 2 || Fan == 3 || Fan == 4))
                    {
                        Console.WriteLine($"(-),({2 * BasicI / 100 * 100 + 100} all)");
                    }
                    else { Console.WriteLine($"({6 * BasicI / 100 * 100}),({2 * BasicI / 100 * 100} all)"); }

                }
                else if (chin == "N" || chin == "n")
                {
                    if (((Fan == 1 || Fan == 2 || Fan == 3) && (Fu == 30 || Fu == 40)) ||
                        (Fan == 3 && Fu == 60) || (Fan == 4 && Fu == 30))
                    {
                        Console.WriteLine($"({4 * BasicI / 100 * 100 + 100}),({BasicI / 100 * 100 + 100},{2 * BasicI / 100 * 100 + 100})");
                    }
                    else if (Fan == 1 && (Fu == 20 || Fu == 25))
                    {
                        Console.WriteLine("(-),(-)");
                    }
                    else if (Fan == 2 && Fu == 25)
                    {
                        Console.WriteLine($"({4 * BasicI / 100 * 100}),(-)");
                    }
                    else if (Fu == 20 && (Fan == 2 || Fan == 3 || Fan == 4))
                    {
                        Console.WriteLine($"(-),({BasicI / 100 * 100 + 100},{2 * BasicI / 100 * 100 + 100})");
                    }
                    else { Console.WriteLine($"({4 * BasicI / 100 * 100}),({BasicI / 100 * 100} ,{2 * BasicI / 100 * 100})"); }
                }
                Console.WriteLine("\n=================");
                x += 1;
                if (x >= 4) { break; }
            }
            Console.ReadKey();
        }
    }
}
