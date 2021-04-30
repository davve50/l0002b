using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] value = { "femhundralapp", "hundralapp", "femtiolapp", "tjugolapp", "tiokrona", "femkrona", "enkrona" };
        private string[] values = { "femhundralappar", "hundralappar", "femtiolappar", "tjugolappar", "tiokronor", "femkronor", "enkronor" };

        private int[] amount = { 0, 0, 0, 0, 0, 0, 0 };

        private void calcChange(int change)
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

        private void printChange()
        {
            string print;
            print = "Växel tillbaka: \n";

            for (int i = 0; i < amount.Length; i++)
            {
                if (amount[i] > 0)
                {
                    if (amount[i] > 1)
                    {
                        print += ($"{amount[i]} {values[i]} \n");
                    }
                    else
                    {
                        print += ($"{amount[i]} {value[i]} \n");
                    }
                }
            }
            changeBox.Text = print;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            Array.Clear(amount, 0, amount.Length);
            int price, payed, change;

            if (Int32.TryParse(priceBox.Text, out price) && Int32.TryParse(payedBox.Text, out payed))
            {
                price = Int32.Parse(priceBox.Text);
                payed = Int32.Parse(payedBox.Text);

                if(price < 0 || payed < 0)
                {
                    changeBox.Text = ("Enbart positiva siffror!");
                }
                else
                {
                    if (price > payed)
                    {
                        changeBox.Text = ($"Det saknas: {(payed - price) * -1} kr!");
                    }
                    else if (price == payed)
                    {
                        changeBox.Text = ("Det gick jämt ut!");
                    }
                    else
                    {
                        change = payed - price;
                        calcChange(change);
                        printChange();
                    }
                } 
            }
            else
            {
                changeBox.Text = "Fyll i båda fälten och använd bara siffror!";
            }

        }
    }
}
