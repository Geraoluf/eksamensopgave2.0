using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace øve_15._10._2023
{
    public class Ingredienser
    {
        private List<string> _ingredienser;


        public Ingredienser(List<string> ingredienser)
        {
            _ingredienser = ingredienser;
        }



        public void Add(string ingrediens)
        {
            _ingredienser.Add(ingrediens);
        }



        public void Clear()
        {
            _ingredienser.Clear();
        }



        public override string ToString()
        {
            if (_ingredienser.Any())
            {
                return string.Join(",", _ingredienser);
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
