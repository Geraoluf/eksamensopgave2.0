﻿using System;
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
            string value = ingredienserListe.ToString(); 
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
                    MessageBox.Show("Du skal først vælge et måltid");
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menuer.Items.Clear();

            if (valgtmåltid == "morgen")
            {
                foreach (var item in myDictionary1)
                {
                    Menuer.Items.Add($"{item.Key}: {item.Value}");
                }
            }
            else if (valgtmåltid == "frokost")
            {
                foreach (var item in myDictionary2)
                {
                    Menuer.Items.Add($"{item.Key}: {item.Value}");
                }
            }
            else if (valgtmåltid == "aftenmåltid")
            {
                foreach (var item in myDictionary3)
                {
                    Menuer.Items.Add($"{item.Key}: {item.Value}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ingredienser = textBox1.Text;
            ingredienserListe.Add(ingredienser);
            textBox1.Clear();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
          
            string selectedKey = Menuer.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedKey))
            {
                MessageBox.Show("Vælg en menu du vil slette");
                return;
            }

            
            string[] parts = selectedKey.Split(':');
            if (parts.Length == 2)
            {
                string key = parts[0].Trim();

               
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
