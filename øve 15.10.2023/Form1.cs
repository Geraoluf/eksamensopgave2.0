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
        List<string> ingredienserListe = new List<string>();

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
            if (true)
            {
                valgtmåltid = "morgen";
                
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (true)
            {
                valgtmåltid = "frokost";
                
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (true)
            {
                valgtmåltid = "aftenmåltid";
                
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string value = string.Join(",", ingredienserListe);
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








        // viser de gemte menuer og værdier i en listbox

        private void button2_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear(); // Fjern eventuelle tidligere elementer fra listBox1



            if (valgtmåltid == "morgen")
            {
                foreach (var item in myDictionary1)
                {
                    listBox1.Items.Add($"{item.Key}: {item.Value}"); // Tilføj både nøglen og værdien til ListBox
                }

            }

            else if (valgtmåltid == "frokost")
            {

                foreach (var item in myDictionary2)
                {


                    listBox1.Items.Add($"{item.Key}: {item.Value}"); // Tilføj både nøglen og værdien til ListBox


                }
            }

            else if (valgtmåltid == "aftenmåltid")
            {
                foreach (var item in myDictionary3)
                {
                    listBox1.Items.Add($"{item.Key}: {item.Value}"); // Tilføj både nøglen og værdien til ListBox


                }

            }

        }








        // gemmer ingredienser i en List

        private void button3_Click(object sender, EventArgs e)   
        {

            string ingredienser = textBox1.Text;

           

            ingredienserListe.Add(ingredienser);


            textBox1.Clear();


        }





















        // søgefunktion - virker ikke endnu

        private void bntvismenu_Click(object sender, EventArgs e)
        {
            string word = txtsøgefelt.Text;

            if (myDictionary2.ContainsKey(word))
            {
                txtvismenu.Items.Clear(); // Ryd eventuelle tidligere elementer i listBox1
                txtvismenu.Items.Add(myDictionary2[word]);

            }
            else
            {
                txtvismenu.Items.Clear();
                txtvismenu.Items.Add("Nøgle ikke fundet");
            }



        }

        
    }
}
