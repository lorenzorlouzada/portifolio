using ConexaoClass2;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
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

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            mtxtTelefone.Mask = "(00) 00000-0000";
        }

        private async void txtCep_Leave(object sender, EventArgs e)
        {
            string cep = txtCep.Text.Replace("-", "").Trim();
            if (cep.Length != 8) return;

            try
            {
                using (var client = new HttpClient())
                {
                    string json = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
                    JObject dados = JObject.Parse(json);

                    if (dados["erro"] != null)
                    {
                        MessageBox.Show("CEP não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    txtRua.Text = dados["logradouro"].ToString();
                    txtBairro.Text = dados["bairro"].ToString();
                    txtCidade.Text = dados["localidade"].ToString();
                    txtUf.Text = dados["uf"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao buscar CEP. Verifique sua conexão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(mtxtTelefone.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSenha.Text) ||
                string.IsNullOrEmpty(txtCep.Text) || string.IsNullOrEmpty(txtRua.Text) ||
                string.IsNullOrEmpty(txtBairro.Text) || string.IsNullOrEmpty(txtCidade.Text) ||
                string.IsNullOrEmpty(txtUf.Text))
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente c = new Cliente
            {
                Nome = txtNome.Text,
                Telefone = mtxtTelefone.Text,
                Email = txtEmail.Text,
                Senha = GerarMD5(txtSenha.Text),
                Cep = txtCep.Text,
                Rua = txtRua.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = txtUf.Text,
                Perfil = "cliente"
            };

            ClienteDAL dal = new ClienteDAL();
            bool sucesso = dal.Cadastrar(c);

            if (sucesso)
            {
                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void btnVoltar_Click_1(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            bool valido = true;
            string telefone = mtxtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();

            if (string.IsNullOrEmpty(txtNome.Text)) { txtNome.BackColor = System.Drawing.Color.MistyRose; valido = false; }
            else txtNome.BackColor = System.Drawing.Color.White;

            if (telefone.Length < 10) { mtxtTelefone.BackColor = System.Drawing.Color.MistyRose; valido = false; }
            else mtxtTelefone.BackColor = System.Drawing.Color.White;

            if (string.IsNullOrEmpty(txtEmail.Text)) { txtEmail.BackColor = System.Drawing.Color.MistyRose; valido = false; }
            else txtEmail.BackColor = System.Drawing.Color.White;

            if (string.IsNullOrEmpty(txtSenha.Text)) { txtSenha.BackColor = System.Drawing.Color.MistyRose; valido = false; }
            else txtSenha.BackColor = System.Drawing.Color.White;

            if (string.IsNullOrEmpty(txtCep.Text)) { txtCep.BackColor = System.Drawing.Color.MistyRose; valido = false; }
            else txtCep.BackColor = System.Drawing.Color.White;

            if (string.IsNullOrEmpty(txtRua.Text)) { txtRua.BackColor = System.Drawing.Color.MistyRose; valido = false; }
            else txtRua.BackColor = System.Drawing.Color.White;

            if (string.IsNullOrEmpty(txtBairro.Text)) { txtBairro.BackColor = System.Drawing.Color.MistyRose; valido = false; }
            else txtBairro.BackColor = System.Drawing.Color.White;

            if (string.IsNullOrEmpty(txtCidade.Text)) { txtCidade.BackColor = System.Drawing.Color.MistyRose; valido = false; }
            else txtCidade.BackColor = System.Drawing.Color.White;

            if (string.IsNullOrEmpty(txtUf.Text)) { txtUf.BackColor = System.Drawing.Color.MistyRose; valido = false; }
            else txtUf.BackColor = System.Drawing.Color.White;

            if (!valido)
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente c = new Cliente
            {
                Nome = txtNome.Text,
                Telefone = mtxtTelefone.Text,
                Email = txtEmail.Text,
                Senha = GerarMD5(txtSenha.Text),
                Cep = txtCep.Text,
                Rua = txtRua.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = txtUf.Text,
                Perfil = "cliente"
            };

            ClienteDAL dal = new ClienteDAL();
            bool sucesso = dal.Cadastrar(c);

            if (sucesso)
            {
                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pcbLogo_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }
    }
}