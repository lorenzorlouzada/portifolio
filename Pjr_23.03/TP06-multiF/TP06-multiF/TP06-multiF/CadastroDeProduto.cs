using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP06_multiF
{
    public partial class CadastroDeProduto : Form
    {
        public CadastroDeProduto()
        {
            InitializeComponent();
            this.Load += new EventHandler(CadastroDeProduto_Load); // Load vinculado corretamente
        }

        // Evento Load do Form
        private void CadastroDeProduto_Load(object sender, EventArgs e)
        {

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.setCodigo(txtCodigo.Text);
            produto.setDescricao(txtDescricao.Text);
            produto.setFornecedor(txtFornecedor.Text);
            produto.setQtdEstoque(txtQtdEstoque.Text);
            produto.setValorUnitario(txtValorUnitario.Text);

            ProdutoBLL bll = new ProdutoBLL();
            string resultado = bll.Salvar(produto);

            MessageBox.Show(resultado);
        }

        private void limpar_Click(object sender, EventArgs e)
        {
            //txtCodigo.Clear();
            txtDescricao.Clear();
            txtFornecedor.Clear();
            txtQtdEstoque.Clear();
            txtValorUnitario.Clear();
            txtCodigo.Focus();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtQtdEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
                e.Handled = true;
        }

        private void ler_Click(object sender, EventArgs e)
        {
            ProdutoBLL bll = new ProdutoBLL();
            List<string> codigos = bll.ListarCodigos();

            if (codigos.Count == 0)
            {
                MessageBox.Show("Sem códigos cadastrados.");
                return;
            }

            string codigo = txtCodigo.Text;
            Produto produto = bll.Buscar(codigo);

            if (produto != null)
            {
                txtCodigo.Text = produto.getCodigo();
                txtDescricao.Text = produto.getDescricao();
                txtFornecedor.Text = produto.getFornecedor();
                txtQtdEstoque.Text = produto.getQtdEstoque();
                txtValorUnitario.Text = produto.getValorUnitario();
            }
            else
            {
                MessageBox.Show("Produto não encontrado.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProdutoBLL bll = new ProdutoBLL();

            string codigo = txtCodigo.Text;

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Digite o código.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Tem certeza que deseja excluir este produto?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                string resultado = bll.Deletar(codigo);
                MessageBox.Show(resultado);

                txtCodigo.Text = "";
                txtDescricao.Text = "";
                txtFornecedor.Text = "";
                txtQtdEstoque.Text = "";
                txtValorUnitario.Text = "";
            }
        }
    }
}