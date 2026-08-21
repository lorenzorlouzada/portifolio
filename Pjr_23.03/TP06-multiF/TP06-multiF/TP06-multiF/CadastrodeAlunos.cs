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
    public partial class CadastrodeAlunos : Form
    {
        public CadastrodeAlunos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CadastrodeAlunos_Load(object sender, EventArgs e)
        {
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            aluno.setRA(txtRA.Text);

            aluno.setNome(txtNome.Text);
            aluno.setTelefone(maskedTextBox1.Text);

            if (radioButton1.Checked)
            {
                aluno.setSexo("Feminino");
            }
            else if (radioButton2.Checked)
            {
                aluno.setSexo("Masculino");
            }
            else
            {
                MessageBox.Show("Selecione o sexo.");
                return;
            }

            aluno.setDataNasc(monthCalendar1.SelectionStart.ToShortDateString());

            AlunoBLL bll = new AlunoBLL();

            string resultado = bll.Salvar(aluno);

            if (resultado != "OK")
            {
                MessageBox.Show(resultado);
            }
            else
            {
                MessageBox.Show("Aluno cadastrado com sucesso!");
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlunoBLL bll = new AlunoBLL();

            string ra = txtRA.Text;

            Aluno aluno = bll.Buscar(ra);

            if (aluno != null)
            {
                txtRA.Text = aluno.getRA();
                txtNome.Text = aluno.getNome();
                maskedTextBox1.Text = aluno.getTelefone();

                if (aluno.getSexo() == "Feminino")
                {
                    radioButton1.Checked = true;
                }
                else if (aluno.getSexo() == "Masculino")
                {
                    radioButton2.Checked = true;
                }

                DateTime data;
                if (DateTime.TryParse(aluno.getDataNasc(), out data))
                {
                    monthCalendar1.SetDate(data);
                }
            }
            else
            {
                MessageBox.Show("Aluno não encontrado.");
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            maskedTextBox1.Text = "";

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            monthCalendar1.SetDate(DateTime.Now);

            txtNome.Focus();
        }

        private void txtRA_KeyPress(object sender, EventArgs e)
        {

        }

        private void txtRA_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
            !char.IsWhiteSpace(e.KeyChar) &&
            !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AlunoBLL bll = new AlunoBLL();

            string ra = txtRA.Text;

            if (string.IsNullOrWhiteSpace(ra))
            {
                MessageBox.Show("Digite o RA.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Tem certeza que deseja excluir este aluno?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                string resultado = bll.Deletar(ra);
                MessageBox.Show(resultado);
            }

            txtRA.Text = "";
            txtNome.Text = "";
            maskedTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            monthCalendar1.SetDate(DateTime.Now);
        }
    }
    
}
