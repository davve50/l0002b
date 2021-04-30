using System;

namespace Lab_1
{
    class Program
    {
        private static string[] value = { "femhundralapp", "hundralapp", "femtiolapp", "tjugolapp", "tiokrona", "femkrona", "enkrona" };
        private static string[] values = { "femhundralappar", "hundralappar", "femtiolappar", "tjugolappar", "tiokronor", "femkronor", "enkronor" };

        private static int[] amount = { 0, 0, 0, 0, 0, 0, 0 };

        private static void calcChange(int change)
        {
            while (change != 0)
            {
                if (change - 500 >= 0)
                {
                    amount[0]++;
                    change = change - 500;
                }
                else if (change - 100 >= 0)
                {
                    amount[1]++;
                    change = change - 100;
                }
                else if (change - 50 >= 0)
                {
                    amount[2]++;
                    change = change - 50;
                }
                else if (change - 20 >= 0)
                {
                    amount[3]++;
                    change = change - 20;
                }
                else if (change - 10 >= 0)
                {
                    amount[4]++;
                    change = change - 10;
                }
                else if (change - 5 >= 0)
                {
                    amount[5]++;
                    change = change - 5;
                }
                else if (change - 1 >= 0)
                {
                    amount[6]++;
                    change = change - 1;
                }
            }
        }

        private static void printChange()
        {
            Console.WriteLine("Växel tillbaka:");

            for (int i = 0; i < amount.Length; i++)
            {
                if (amount[i] > 0)
                {
                    if (amount[i] > 1)
                    {
                        Console.WriteLine($"{amount[i]} {values[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"{amount[i]} {value[i]}");

                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int payed, price, change;

            Console.Write("Ange pris: ");
            while (!Int32.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.WriteLine("Enbart positiva siffror tillåtna!");
            }

            Console.Write("Betalt: ");
            while (!Int32.TryParse(Console.ReadLine(), out payed) || payed < 0)
            {
                Console.WriteLine("Enbart positiva siffror tillåtna!");
            }

            if (price > payed)
            {
                Console.WriteLine($"Det saknas: {(payed - price) * -1} kr!");
            }
            else if (price == payed)
            {
                Console.WriteLine("Det gick jämt ut!");
            }
            else
            {
                change = payed - price;
                calcChange(change);
                printChange();
            }
        }
    }
}
