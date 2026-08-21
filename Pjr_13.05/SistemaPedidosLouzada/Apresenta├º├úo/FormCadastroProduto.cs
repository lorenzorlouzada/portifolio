using ConexaoClass2;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FormCadastroProduto : Form
    {
        private List<Categoria> _categorias;

        public FormCadastroProduto()
        {
            InitializeComponent();
        }

        private void FormCadastroProduto_Load(object sender, EventArgs e)
        {
            CarregarCategorias();
        }

        private void CarregarCategorias()
        {
            // Como não temos CategoriaDAL ainda, vamos carregar manual
            _categorias = new List<Categoria>
            {
                new Categoria { Id = 1, Nome = "Foto-Presente" },
                new Categoria { Id = 2, Nome = "Ótica" },
                new Categoria { Id = 3, Nome = "Foto-Documento" },
                new Categoria { Id = 4, Nome = "Revelação de Fotos" }
            };
            cmbCategoria.DataSource = _categorias;
            cmbCategoria.DisplayMember = "Nome";
            cmbCategoria.ValueMember = "Id";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtPreco.Text))
            {
                MessageBox.Show("Preencha nome e preço!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal preco;
            if (!decimal.TryParse(txtPreco.Text.Replace(",", "."), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out preco))
            {
                MessageBox.Show("Preço inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Produto p = new Produto
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                Preco = preco,
                TemFoto = false,
                IdCategoria = (int)cmbCategoria.SelectedValue
            };

            ProdutoDAL dal = new ProdutoDAL();
            bool sucesso = dal.Cadastrar(p);

            if (sucesso)
            {
                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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