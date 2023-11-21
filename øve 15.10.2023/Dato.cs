using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace øve_15._10._2023
{
    internal class Dato
    {


        public object _år { get; internal set; }
        public int _månede { get; internal set; }
        public int _dag { get; internal set; }
        public int År { get; internal set; }

        public Dato(int year, int month, int day)
        {
            _år = year;
            _månede = month;
            _dag = day;

        }


        public override string ToString()
        {
            return $"{_dag}.{_månede}.{_år}";
        }
    }
}
