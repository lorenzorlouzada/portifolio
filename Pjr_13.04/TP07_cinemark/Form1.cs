using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP07_cinemark
{
    public partial class Form1 : Form
    {
        Button[,] cadeira = new Button[10, 20];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 20; j++)
                {
                    cadeira[i, j] = new Button();
                    cadeira[i, j].Size = new Size(40, 40);
                    cadeira[i, j].Location = new Point(20 + j * 45, 20 + i * 45);
                    cadeira[i, j].BackColor = Color.Green;
                    cadeira[i, j].Text = ((char)('A' + i)) + "" + (j + 1);

                    cadeira[i, j].Click += ClickBtn;
                    Controls.Add(cadeira[i, j]);

                }
        }
        private void ClickBtn(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == Color.Green)
            {
                if (MessageBox.Show("Reservar?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    b.BackColor = Color.Red;
            }
            else
            {
                b.BackColor = Color.Green;
            }
        }

        private void btnFaturamento_Click(object sender, EventArgs e)
        {
            int cont = 0;
            foreach (Button b in cadeira)
                if (b.BackColor == Color.Red) cont++;
            MessageBox.Show("R$ " + (cont * 20));
        }
    }
}
