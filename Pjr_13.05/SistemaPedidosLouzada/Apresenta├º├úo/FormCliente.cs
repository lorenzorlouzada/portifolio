using ConexaoClass2;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FormCliente : Form
    {
        private Cliente _cliente;
        private List<Produto> _produtos;
        private System.ComponentModel.BindingList<ItemPedido> _carrinho = new System.ComponentModel.BindingList<ItemPedido>();
        public FormCliente(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            lblBemVindo.Text = $"Olá, {_cliente.Nome.Split(' ')[0]}!";
            CarregarProdutos();
            AtualizarCarrinho();
        }

        private void CarregarProdutos()
        {
            ProdutoDAL dal = new ProdutoDAL();
            _produtos = dal.ListarTodos();
            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = _produtos;

            if (dgvProdutos.Columns.Count > 0)
            {
                dgvProdutos.Columns["Id"].Visible = false;
                dgvProdutos.Columns["Ativo"].Visible = false;
                dgvProdutos.Columns["IdCategoria"].Visible = false;
                dgvProdutos.Columns["TemFoto"].Visible = false;
                dgvProdutos.Columns["Nome"].HeaderText = "Produto";
                dgvProdutos.Columns["Descricao"].HeaderText = "Descrição";
                dgvProdutos.Columns["Preco"].HeaderText = "Preço";
                dgvProdutos.Columns["NomeCategoria"].HeaderText = "Categoria";
            }
        }

        private void AtualizarCarrinho()
        {
            dgvCarrinho.DataSource = null;
            dgvCarrinho.DataSource = _carrinho;

            if (dgvCarrinho.Columns.Count > 0)
            {
                dgvCarrinho.Columns["Id"].Visible = false;
                dgvCarrinho.Columns["IdPedido"].Visible = false;
                dgvCarrinho.Columns["IdProduto"].Visible = false;
                dgvCarrinho.Columns["IdTamanho"].Visible = false;
                dgvCarrinho.Columns["NomeTamanho"].Visible = false;
                dgvCarrinho.Columns["Preco"].Visible = false;
                dgvCarrinho.Columns["NomeProduto"].HeaderText = "Produto";
                dgvCarrinho.Columns["Quantidade"].HeaderText = "Qtd";
                dgvCarrinho.Columns["Observacao"].HeaderText = "Observação";
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var produto = _produtos[dgvProdutos.SelectedRows[0].Index];

            ItemPedido item = new ItemPedido
            {
                IdProduto = produto.Id,
                NomeProduto = produto.Nome,
                Quantidade = (int)nudQuantidade.Value,
                Observacao = txtObservacao.Text,
                IdTamanho = null
            };

            _carrinho.Add(item);
            AtualizarCarrinho();
            txtObservacao.Clear();
            nudQuantidade.Value = 1;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCarrinho.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item do carrinho!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvCarrinho.SelectedRows[0].Index;
            _carrinho.RemoveAt(index);
            AtualizarCarrinho();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            if (_carrinho.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um produto ao carrinho!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Pedido pedido = new Pedido
            {
                IdCliente = _cliente.Id,
                CodigoPedido = _cliente.GerarCodigoPedido(),
                Observacao = txtObservacao.Text,
                Itens = new List<ItemPedido>(_carrinho)
            };

            PedidoDAL dal = new PedidoDAL();
            bool sucesso = dal.CriarPedido(pedido);

            if (sucesso)
            {
                MessageBox.Show($"Pedido {pedido.CodigoPedido} realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _carrinho.Clear();
                AtualizarCarrinho();
                txtObservacao.Clear();
            }
            else
            {
                MessageBox.Show("Erro ao realizar pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvCarrinho_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtObservacao_TextChanged(object sender, EventArgs e) { }
    }
}