using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace øve_15._10._2023
{
    public partial class Form1 : Form
    {
        Ingredienser ingredienserListe = new Ingredienser(new List<string>());

        private Dictionary<string, string> myDictionary1 = new Dictionary<string, string>();
        private Dictionary<string, string> myDictionary2 = new Dictionary<string, string>();
        private Dictionary<string, string> myDictionary3 = new Dictionary<string, string>();
        string valgtmåltid;

        public Form1()
        {
            InitializeComponent();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)   //valg af måltid
        {
            valgtmåltid = radioButton1.Checked ? "morgen" : valgtmåltid;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            valgtmåltid = radioButton2.Checked ? "frokost" : valgtmåltid;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            valgtmåltid = radioButton3.Checked ? "aftenmåltid" : valgtmåltid;
        }


        private void button1_Click(object sender, EventArgs e)  // gemmer i det rigtige Dictionary
        {
            try
            {
                string value = ingredienserListe.ToString();
                ingredienserListe.Clear();
                string key = textBox2.Text;

                // Check om menunavnet er tomt
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new FormatException("Menunavnet må ikke være tomt.");
                }

                switch (valgtmåltid)
                {
                    case "morgen":
                        myDictionary1[key] = value;
                        textBox1.Clear();
                        textBox2.Clear();
                        break;

                    case "frokost":
                        myDictionary2[key] = value;
                        textBox1.Clear();
                        textBox2.Clear();
                        break;

                    case "aftenmåltid":
                        myDictionary3[key] = value;
                        textBox1.Clear();
                        textBox2.Clear();
                        break;

                    default:
                        MessageBox.Show("Du skal først vælge et måltid");
                        break;
                }
            }
            catch (FormatException ex)
            {
                // Vis en fejlmeddelelse med information fra undtagelsen
                MessageBox.Show($"Fejl: {ex.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Generel fejlhåndtering for andre undtagelser
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)   // Viser indholdet af dictionary i listboxen
        {
            Menuer.Items.Clear();

            List<string> sortedItems = new List<string>();

            if (valgtmåltid == "morgen")
            {
                sortedItems.AddRange(myDictionary1.Select(item => $"{item.Key}: {item.Value}"));  //Kompakt kode: Lambda-udtryk og LINQ-metoder som Select og AddRange
            }
            else if (valgtmåltid == "frokost")
            {
                sortedItems.AddRange(myDictionary2.Select(item => $"{item.Key}: {item.Value}"));
            }
            else if (valgtmåltid == "aftenmåltid")
            {
                sortedItems.AddRange(myDictionary3.Select(item => $"{item.Key}: {item.Value}"));
            }

            sortedItems.Sort();

            Menuer.Items.AddRange(sortedItems.ToArray());
        }

        private void button3_Click(object sender, EventArgs e)  //gemmer de intastet ingredienser i list ingredienser
        {
            string ingredienser = textBox1.Text;
            ingredienserListe.Add(ingredienser);
            textBox1.Clear();
        }

        

        private void button4_Click(object sender, EventArgs e)  // fjerne gemte menuer
        {
          
            string sletMenu = Menuer.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(sletMenu ))                    //Dette tjekker, om sletMenu enten er null eller en tom streng
            {
                MessageBox.Show("Vælg en menu du vil slette");
                return;
            }

            
            string[] parts = sletMenu.Split(':');     //Hvis sletMenu ikke er tom, fortsætter programmet med at opdele strengen sletMenu ved
                                                      //hjælp af kolon (':') som separator. Resultatet er gemt i et array kaldet parts
            if (parts.Length == 2)
            {
                string key = parts[0].Trim();         //Dette tjekker, om parts-arrayet har præcis to elementer.
                                                      //og koden inde i denne if-blok kan nu udføres.


                switch (valgtmåltid)
                {
                    case "morgen":
                        myDictionary1.Remove(key);
                        break;

                    case "frokost":
                        myDictionary2.Remove(key);
                        break;

                    case "aftenmåltid":
                        myDictionary3.Remove(key);
                        break;

                    default:
                        MessageBox.Show("Ugyldig valgt måltid.");
                        break;
                }

                
                button2_Click(sender, e);

                MessageBox.Show("Menuen er slettet.");
            }
            else
            {
                MessageBox.Show("Ugyldigt.");
            }
        }


        private void button5_Click(object sender, EventArgs e)  // bruges til at søge gemte menuer
        {
            
                string søgteMenu = textBox3.Text;

                if (string.IsNullOrWhiteSpace(søgteMenu))
                {
                    MessageBox.Show("Indtast venligst et menunavn at søge efter.");
                    return;
                }

                Søgmenu søg = new Søgmenu(valgtmåltid, myDictionary1, myDictionary2, myDictionary3);
                string resultatAfSøgning = søg.SøgIngrediens(søgteMenu);


                if (!string.IsNullOrEmpty(resultatAfSøgning))
                {
                    MessageBox.Show(resultatAfSøgning);
                }
                else
                {
                    MessageBox.Show($"Menuen med navnet '{søgteMenu}' blev ikke fundet.");
                }
            
        }

        











    }
    

   
}
