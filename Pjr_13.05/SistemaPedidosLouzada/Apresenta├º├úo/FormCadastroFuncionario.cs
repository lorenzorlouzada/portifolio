using ConexaoClass2;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FormCadastroFuncionario : Form
    {
        private Cliente _admin;

        public FormCadastroFuncionario(Cliente admin)
        {
            InitializeComponent();
            _admin = admin;
        }

        private string GerarMD5(string texto)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(texto);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
                sb.Append(hashBytes[i].ToString("x2"));
            return sb.ToString();
        }

        private void FormCadastroFuncionario_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Add("atendente");
            cmbTipo.Items.Add("laboratorio");
            cmbTipo.SelectedIndex = 0;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtSenha.Text) || cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente funcionario = new Cliente
            {
                Nome = txtNome.Text,
                Telefone = "0000000000",
                Email = txtEmail.Text,
                Senha = GerarMD5(txtSenha.Text),
                Cep = "",
                Rua = "",
                Bairro = "",
                Cidade = "",
                Estado = "",
                Perfil = cmbTipo.SelectedItem.ToString()
            };

            ClienteDAL dal = new ClienteDAL();
            bool sucesso = dal.Cadastrar(funcionario);

            if (sucesso)
            {
                MessageBox.Show($"Funcionário '{funcionario.Nome}' cadastrado como {funcionario.Perfil}!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Clear();
                txtEmail.Clear();
                txtSenha.Clear();
                cmbTipo.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar funcionário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pcbLogo_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }
    }
}