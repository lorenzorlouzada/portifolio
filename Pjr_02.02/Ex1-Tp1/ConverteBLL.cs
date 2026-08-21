using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex1_Tp1;

namespace Ex1_Tp1
{
    internal class bll_2
    {

    }

    public class ConverteBLL
    {
        private float valor;

            public float Valor
            {
                get { return valor; }
                set { valor = value; }
            }

            public float converteKM()
            {
                return valor / 1.60934f;
            }

            public float converteMilha()
            {
                return valor * 1.60934f;
            }
        }
    }

