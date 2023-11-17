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

        public Form1()
        {
            InitializeComponent();
        }

        string valgtmåltid;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                valgtmåltid = "morgen";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                valgtmåltid = "frokost";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                valgtmåltid = "aftenmåltid";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = ingredienserListe.ToString(); // Brug ToString-metoden for at få ingredienser som en streng
            ingredienserListe.Clear();
            string key = textBox2.Text;

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
                    MessageBox.Show(valgtmåltid);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (valgtmåltid == "morgen")
            {
                foreach (var item in myDictionary1)
                {
                    listBox1.Items.Add($"{item.Key}: {item.Value}");
                }
            }
            else if (valgtmåltid == "frokost")
            {
                foreach (var item in myDictionary2)
                {
                    listBox1.Items.Add($"{item.Key}: {item.Value}");
                }
            }
            else if (valgtmåltid == "aftenmåltid")
            {
                foreach (var item in myDictionary3)
                {
                    listBox1.Items.Add($"{item.Key}: {item.Value}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ingredienser = textBox1.Text;
            ingredienserListe.Add(ingredienser);
            textBox1.Clear();
        }

        private void bntvismenu_Click(object sender, EventArgs e)
        {
            string word = txtsøgefelt.Text;

            if (myDictionary2.ContainsKey(word))
            {
                txtvismenu.Items.Clear();
                txtvismenu.Items.Add(myDictionary2[word]);
            }
            else
            {
                txtvismenu.Items.Clear();
                txtvismenu.Items.Add("Nøgle ikke fundet");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Få den markerede vare fra listBox1
            string selectedKey = listBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedKey))
            {
                MessageBox.Show("Vælg en post at slette.");
                return;
            }

            // Opdel den markerede vare for at få nøglen
            string[] parts = selectedKey.Split(':');
            if (parts.Length == 2)
            {
                string key = parts[0].Trim();

                // Fjern den markerede vare fra den relevante dictionary baseret på valgtmåltid
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

                // Opdater listBox1
                button2_Click(sender, e);

                MessageBox.Show("Posten er slettet.");
            }
            else
            {
                MessageBox.Show("Ugyldig markeret post.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                string searchMenu = textBox3.Text;

                if (string.IsNullOrWhiteSpace(searchMenu))
                {
                    MessageBox.Show("Indtast venligst et menunavn at søge efter.");
                    return;
                }

                Søgmenu menuSearch = new Søgmenu(valgtmåltid, myDictionary1, myDictionary2, myDictionary3);
                string result = menuSearch.SearchMenuAndGetIngredients(searchMenu);

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show($"Menuen med navnet '{searchMenu}' blev ikke fundet.");
                }
            }
        }
    }

   
}
