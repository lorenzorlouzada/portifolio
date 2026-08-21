using ConexaoClass2;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FormAtendente : Form
    {
        private Cliente _cliente;
        private List<Produto> _produtos;
        private List<Cliente> _clientes;

        public FormAtendente(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
        }

        private void FormAtendente_Load(object sender, EventArgs e)
        {
            lblBemVindo.Text = $"Olá, {_cliente.Nome.Split(' ')[0]}!";
            CarregarClientes();
            CarregarProdutos();
            CarregarPedidos();

            btnCadastrarFuncionario.Visible = _cliente.Perfil.ToLower() == "admin";
        }

        private void CarregarClientes()
        {
            ClienteDAL dal = new ClienteDAL();
            _clientes = dal.ListarTodos();
            cmbCliente.DataSource = _clientes;
            cmbCliente.DisplayMember = "Nome";
            cmbCliente.ValueMember = "Id";
        }

        private void CarregarProdutos()
        {
            ProdutoDAL dal = new ProdutoDAL();
            _produtos = dal.ListarTodos();
            cmbProduto.DataSource = _produtos;
            cmbProduto.DisplayMember = "Nome";
            cmbProduto.ValueMember = "Id";
        }

        private void CarregarPedidos()
        {
            PedidoDAL dal = new PedidoDAL();
            var pedidos = dal.ListarTodos();
            dgvPedidos.DataSource = pedidos;
            dgvPedidos.Columns["Id"].Visible = false;
            dgvPedidos.Columns["IdCliente"].Visible = false;
            dgvPedidos.Columns["CodigoPedido"].HeaderText = "Código";
            dgvPedidos.Columns["NomeCliente"].HeaderText = "Cliente";
            dgvPedidos.Columns["TelefoneCliente"].HeaderText = "Telefone";
            dgvPedidos.Columns["DataPedido"].HeaderText = "Data";
            dgvPedidos.Columns["Status"].HeaderText = "Status";
            dgvPedidos.Columns["Observacao"].HeaderText = "Observação";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem == null || cmbProduto.SelectedItem == null)
            {
                MessageBox.Show("Selecione cliente e produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clienteSelecionado = (Cliente)cmbCliente.SelectedItem;
            var produto = (Produto)cmbProduto.SelectedItem;

            ItemPedido item = new ItemPedido
            {
                IdProduto = produto.Id,
                NomeProduto = produto.Nome,
                Quantidade = (int)nudQuantidade.Value,
                Observacao = txtObservacao.Text,
                Tamanho = txtTamanho.Text,
                IdTamanho = null
            };

            Pedido pedido = new Pedido
            {
                IdCliente = clienteSelecionado.Id,
                CodigoPedido = clienteSelecionado.GerarCodigoPedido(),
                Observacao = txtObservacao.Text,
                Itens = new List<ItemPedido> { item }
            };

            PedidoDAL dal = new PedidoDAL();
            bool sucesso = dal.CriarPedido(pedido);

            if (sucesso)
            {
                MessageBox.Show($"Pedido {pedido.CodigoPedido} registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarPedidos();
                txtObservacao.Clear();
                txtTamanho.Clear();
                nudQuantidade.Value = 1;
            }
            else
            {
                MessageBox.Show("Erro ao registrar pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormCadastroProduto formProduto = new FormCadastroProduto();
            formProduto.ShowDialog();
            CarregarProdutos();
        }

        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            FormCadastroFuncionario formFunc = new FormCadastroFuncionario(_cliente);
            formFunc.ShowDialog();
        }

        private void pcbLogo_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbProduto_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void lblProduto_Click(object sender, EventArgs e) { }
        private void cmbTamanho_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void lblQuantidade_Click(object sender, EventArgs e) { }
        private void nudQuantidade_ValueChanged(object sender, EventArgs e) { }
        private void lblObservacao_Click(object sender, EventArgs e) { }
        private void txtObservacao_TextChanged(object sender, EventArgs e) { }
    }
}