using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        //Person class
        public class Person
        {
            string firstName, lastName, ssn, gender;

            public Person(string firstName, string lastName, string ssn, string gender)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.ssn = ssn;
                this.gender = gender;
            }

            public string PrintPerson()
            {
                return ($"Namn: {firstName} \nEfternamn: {lastName} \nPersonnr: {ssn} \nKön: {gender}");
            }

        }


        //Check if SSN is valid by using 21Algoritm
        private static Boolean CheckSSN(string ssn)
        {
            int temp = 0, sum = 0, count = 0;

            foreach (char s in ssn)
            {
                if (s >= '0' && s <= '9')
                {
                    if (count % 2 == 0)
                    {
                        temp = (s - '0') * 2;
                        if (temp > 9)
                        {
                            sum += temp % 10 + temp / 10;
                        }
                        else
                        {
                            sum += temp;
                        }
                    }
                    else
                    {
                        sum += (s - '0');
                    }
                    count++;
                }
            }

            if (sum % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string firstName, lastName, ssn, gender;

            firstName = firstTB.Text;
            lastName = lastTB.Text;
            ssn = ssnTB.Text;


            if (CheckSSN(ssn))
            {
                //Check gender
                if (ssn[2] % 2 == 0)
                {
                    gender = "Kvinna";
                }
                else
                {
                    gender = "Man";
                }

                //Create new person object
                Person person = new Person(firstName, lastName, ssn, gender);
                resultTB.Text = person.PrintPerson();
            }
            else
            {
                resultTB.Text = "Enter valid SSN!";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
