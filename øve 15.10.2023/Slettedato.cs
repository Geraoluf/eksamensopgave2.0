using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace øve_15._10._2023
{
    internal class Slettedato
    {


        private Dato _slettedato;


        public Slettedato(Dato slettedato)
        {
            _slettedato = slettedato;
        }




        public Dato HentSlettedato()
        {
            return _slettedato;
        }


        

    }
}
