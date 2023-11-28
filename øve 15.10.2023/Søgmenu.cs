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



        public string SøgIngrediens(string menuName)
        {
            string søgeResultat = string.Empty;

            switch (valgtmåltid)
            {
                case "morgen":
                    if (myDictionary1.ContainsKey(menuName))
                    {
                        søgeResultat = myDictionary1[menuName];
                    }
                    break;

                case "frokost":
                    if (myDictionary2.ContainsKey(menuName))
                    {
                       søgeResultat = myDictionary2[menuName];
                    }
                    break;

                case "aftenmåltid":
                    if (myDictionary3.ContainsKey(menuName))
                    {
                        søgeResultat = myDictionary3[menuName];
                    }
                    break;

                default:
                    MessageBox.Show("Ugyldig valgt måltid.");
                    break;
            }

            return søgeResultat;
        }

    }
}
