using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESAFIO
{
    public partial class Desafio1UIL : Form
    {
        List<string> propriedades = new List<string>();
        public Desafio1UIL()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            DesafioBLL.validarPropriedade(txtPropriedade.Text);

            if (!Erro.temErro)
            {
                propriedades.Add(txtPropriedade.Text);

                listPropriedades.Items.Add(txtPropriedade.Text);

                txtPropriedade.Clear();
            }
            else
            {
                MessageBox.Show(Erro.mensagem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtClasse.Clear();
            txtPropriedade.Clear();

            listPropriedades.Items.Clear();

            propriedades.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Erro.limpar();

            DesafioBLL.validarClasse(txtClasse.Text);

            if (propriedades == null || propriedades.Count == 0)
            {
                Erro.mensagem = "Adicione pelo menos uma propriedade.";
                Erro.temErro = true;
            }

            if (Erro.temErro)
            {
                MessageBox.Show(Erro.mensagem);
                return;
            }

            string saida = "public class " + txtClasse.Text + "\n";
            saida += "{\n";

            foreach (var prop in propriedades)
            {
                saida += "    public void set" + prop + "(string _" + prop + ") { " + prop + " = _" + prop + "; }\n";
                saida += "    public string get" + prop + "() { return " + prop + "; }\n";
            }

            saida += "}";

            Clipboard.SetText(saida);
            MessageBox.Show("Classe copiada para a área de transferência!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtClasse_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
