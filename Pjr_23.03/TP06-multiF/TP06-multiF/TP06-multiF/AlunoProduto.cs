using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP06_multiF
{
    public partial class AlunoProduto : Form
    {
        public AlunoProduto()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void CADASTROSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AlunoProduto_Load(object sender, EventArgs e)
        {

        }

        private void cadastrosDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        { 
                CadastrodeAlunos tela = new CadastrodeAlunos();
                tela.ShowDialog();
            
        }

        private void cadastrosDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
                CadastroDeProduto tela = new CadastroDeProduto();
                tela.ShowDialog();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
