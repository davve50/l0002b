using System;
using System.IO;

namespace Lab_2
{
    class Program
    {
        //[sellerID][Name, SSN, district, amount, lvl]
        private static string[][] sellers;
        //Counter for each lvl
        private static int[] numberLVL = { 0, 0, 0, 0 };
        //Requirements for each lvl
        private static string[] reqLVL = { "under 50", "50-99", "100-199", "över 199" };
        //Amount of sellers
        private static int numberOfSellers;
        //String for file writing
        private static string toFile;

        //Calculate the correct lvl from amount of sold products
        private static string CalculateLVL(int amount)
        {
            if (amount < 50)
            {
                return "1";
                numberLVL[0]++;
            }
            else if (amount < 100)
            {
                return "2";
                numberLVL[1]++;
            }
            else if (amount < 200)
            {
                return "3";
                numberLVL[2]++;
            }
            else
            {
                return "4";
                numberLVL[3]++;
            }
        }

        //Sort the sellers bases on the amount of sold products
        private static void SortSellers(string[][] sellers)
        {
            string[][] temp = new string[numberOfSellers][];

            for (int j = 0; j <= sellers.Length - 2; j++)
            {
                for (int i = 0; i <= sellers.Length - 2; i++)
                {
                    if (Int32.Parse(sellers[i][3]) < Int32.Parse(sellers[i + 1][3]))
                    {
                        temp[i] = sellers[i + 1];
                        sellers[i + 1] = sellers[i];
                        sellers[i] = temp[i];
                    }
                }
            }
        }

        //Prints the sellers accordingly
        private static void PrintSellers(string[][] sellers)
        {
            Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-10} {3,-10}", "Namn:", "Persnr:", "Distrikt:", "Antal:"));
            toFile = String.Format("{0,-10} {1,-10} {2,-10} {3,-10}", "Namn:", "Persnr:", "Distrikt:", "Antal:");

            for (int i = 4; i > 0; i--)
            {
                int count = 0;
                for (int j = 0; j < numberOfSellers; j++)
                {
                    if (Int32.Parse(sellers[j][4]) == i)
                    {
                        Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-10} {3,-10}", $"{sellers[j][0]}", $"{sellers[j][1]}", $"{sellers[j][2]}", $"{sellers[j][3]}"));
                        toFile = toFile + "\n" + String.Format("{0,-10} {1,-10} {2,-10} {3,-10}", $"{sellers[j][0]}", $"{sellers[j][1]}", $"{sellers[j][2]}", $"{sellers[j][3]}");
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine($"{count} säljare har nått nivå {i}: {reqLVL[i - 1]} artiklar \n");
                    toFile = toFile + "\n" + ($"{count} säljare har nått nivå {i}: {reqLVL[i - 1]} artiklar \n");
                }
            }
        }

        //Write result to a file
        private static void writeToFile(string toFile)
        {
            File.WriteAllText("ListOfSellers.txt", toFile);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Antal säljare: ");
            numberOfSellers = Int32.Parse(Console.ReadLine());
            sellers = new string[numberOfSellers][];

            for (int i = 1; i <= numberOfSellers; i++)
            {
                Console.WriteLine($"Namn på säljare: {i}");
                string temp1 = Console.ReadLine();

                Console.WriteLine($"Personnummer på säljare: {i}");
                string temp2 = Console.ReadLine();

                Console.WriteLine($"Distrikt på säljare: {i}");
                string temp3 = Console.ReadLine();

                Console.WriteLine($"Antal sålda produkter på säljare: {i}");
                string temp4 = Console.ReadLine();

                string temp5 = CalculateLVL(Int32.Parse(temp4));

                string[] tempArray = { temp1, temp2, temp3, temp4, temp5 };

                sellers[i-1] = tempArray;
            }
            SortSellers(sellers);
            PrintSellers(sellers);
            writeToFile(toFile);
        }
    }
}
