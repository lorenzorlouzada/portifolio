using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ConexaoClass2;

namespace Apresentacao
{
    public partial class FormLogin : Form
    {
        public FormLogin()
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.BackColor = Color.MistyRose;
                valido = false;
            }
            else txtEmail.BackColor = Color.White;

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                txtSenha.BackColor = Color.MistyRose;
                valido = false;
            }
            else txtSenha.BackColor = Color.White;

            if (!valido)
            {
                MessageBox.Show("Preencha email e senha!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string senhaCriptografada = GerarMD5(txtSenha.Text);
            ClienteDAL dal = new ClienteDAL();
            Cliente cliente = dal.Login(txtEmail.Text, senhaCriptografada);

            if (cliente == null)
            {
                MessageBox.Show("Email ou senha incorretos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cliente.Perfil == "admin" || cliente.Perfil == "atendente")
            {
                FormAtendente formAtendente = new FormAtendente(cliente);
                formAtendente.Show();
                this.Hide();
            }
            else if (cliente.Perfil == "laboratorio")
            {
                FormLaboratorio formLab = new FormLaboratorio(cliente);
                formLab.Show();
                this.Hide();
            }
            else
            {
                FormCliente formCliente = new FormCliente(cliente);
                formCliente.Show();
                this.Hide();
            }
        }
        private void btnEntrar_Click_1(object sender, EventArgs e) { }

        private void lblCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.Show();
            this.Hide();
        }

        private void lblCadastro_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.Show();
            this.Hide();
        }

        private void FormLogin_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lblSenha_Click(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
    }
}