using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace øve_15._10._2023
{
    internal class Søgmenu
    {
        private string valgtmåltid;
        private Dictionary<string, string> myDictionary1;
        private Dictionary<string, string> myDictionary2;
        private Dictionary<string, string> myDictionary3;

        public Søgmenu(string valgtmåltid, Dictionary<string, string> dictionary1, Dictionary<string, string> dictionary2, Dictionary<string, string> dictionary3)
        {
            this.valgtmåltid = valgtmåltid;
            myDictionary1 = dictionary1;
            myDictionary2 = dictionary2;
            myDictionary3 = dictionary3;
        }



        public string SearchMenuAndGetIngredients(string menuName)
        {
            string result = string.Empty;

            switch (valgtmåltid)
            {
                case "morgen":
                    if (myDictionary1.ContainsKey(menuName))
                    {
                        result = myDictionary1[menuName];
                    }
                    break;

                case "frokost":
                    if (myDictionary2.ContainsKey(menuName))
                    {
                        result = myDictionary2[menuName];
                    }
                    break;

                case "aftenmåltid":
                    if (myDictionary3.ContainsKey(menuName))
                    {
                        result = myDictionary3[menuName];
                    }
                    break;

                default:
                    MessageBox.Show("Ugyldig valgt måltid.");
                    break;
            }

            return result;
        }

    }
}
