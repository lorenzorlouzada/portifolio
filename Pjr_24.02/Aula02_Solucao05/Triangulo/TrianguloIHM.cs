using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangulo
{
    public partial class TrianguloIHM : Form
    {
        public TrianguloIHM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Triangulo meutriangulo = new Triangulo();

            meutriangulo.setB(tbBase.Text);
            meutriangulo.setH(tbAltura.Text);
            TrianguloBLL.validaDados(meutriangulo);
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMens());
            }
            else
            {
                tbArea.Text = meutriangulo.getArea();
                tbBase.Enabled = false;
                tbAltura.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbBase.Clear();
            tbAltura.Clear();
            tbArea.Clear();
            tbBase.Enabled = true;
            tbAltura.Enabled = true;
            tbBase.Focus();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // propriedade keypreview do form em true
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
