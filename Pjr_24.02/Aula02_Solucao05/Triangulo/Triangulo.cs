using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulo
{
    class Triangulo
    {
        private String b;
        private String h;

        public void setB(string _b) { b = _b; }
        public String getB() { return b; }
        public void setH(string _h) { h = _h; }
        public String getH() { return h; }
        public String getArea()
        {
            return ((float.Parse(b) * float.Parse(h)) / 2).ToString();
        }

    }
}
