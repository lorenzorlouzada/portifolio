using ConexaoClass2;
using System;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FormLaboratorio : Form
    {
        private Cliente _cliente;

        public FormLaboratorio(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
        }

        private void FormLaboratorio_Load(object sender, EventArgs e)
        {
            lblBemVindo.Text = $"Olá, {_cliente.Nome.Split(' ')[0]}!";
            CarregarPedidos();
            CarregarRetirados();
        }

        private void CarregarPedidos()
        {
            PedidoDAL dal = new PedidoDAL();
            var pedidos = dal.ListarTodos();
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = pedidos;

            if (dgvPedidos.Columns.Count > 0)
            {
                dgvPedidos.Columns["Id"].Visible = false;
                dgvPedidos.Columns["IdCliente"].Visible = false;
                dgvPedidos.Columns["Observacao"].Visible = false;
                dgvPedidos.Columns["CodigoPedido"].HeaderText = "Código";
                dgvPedidos.Columns["NomeCliente"].HeaderText = "Cliente";
                dgvPedidos.Columns["TelefoneCliente"].HeaderText = "Telefone";
                dgvPedidos.Columns["DataPedido"].HeaderText = "Data";
                dgvPedidos.Columns["Status"].HeaderText = "Status";
            }
        }

        private void CarregarRetirados()
        {
            PedidoDAL dal = new PedidoDAL();
            var todos = dal.ListarTodos();
            var retirados = new System.Collections.Generic.List<Pedido>();
            foreach (var p in todos)
                if (p.Status == "Retirado") retirados.Add(p);

            dgvRetirados.DataSource = null;
            dgvRetirados.DataSource = retirados;

            if (dgvRetirados.Columns.Count > 0)
            {
                dgvRetirados.Columns["Id"].Visible = false;
                dgvRetirados.Columns["IdCliente"].Visible = false;
                dgvRetirados.Columns["Observacao"].Visible = false;
                dgvRetirados.Columns["CodigoPedido"].HeaderText = "Código";
                dgvRetirados.Columns["NomeCliente"].HeaderText = "Cliente";
                dgvRetirados.Columns["TelefoneCliente"].HeaderText = "Telefone";
                dgvRetirados.Columns["DataPedido"].HeaderText = "Data";
                dgvRetirados.Columns["Status"].HeaderText = "Status";
            }
        }

        private void AtualizarStatus(string novoStatus)
        {
            if (dgvPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um pedido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPedido = (int)dgvPedidos.SelectedRows[0].Cells["Id"].Value;
            PedidoDAL dal = new PedidoDAL();
            bool sucesso = dal.AtualizarStatus(idPedido, novoStatus);

            if (sucesso)
            {
                MessageBox.Show($"Status atualizado para '{novoStatus}'!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarPedidos();
                CarregarRetirados();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar status.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmProducao_Click(object sender, EventArgs e)
        {
            AtualizarStatus("Em producao");
        }

        private void btnPronto_Click(object sender, EventArgs e)
        {
            AtualizarStatus("Pronto");
        }

        private void btnRetirado_Click(object sender, EventArgs e)
        {
            AtualizarStatus("Retirado");
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um pedido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Função não disponível.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dgvRetirados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um pedido retirado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPedido = (int)dgvRetirados.SelectedRows[0].Cells["Id"].Value;
            PedidoDAL dal = new PedidoDAL();
            bool sucesso = dal.AtualizarStatus(idPedido, "Aguardando");

            if (sucesso)
            {
                MessageBox.Show("Pedido recuperado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarPedidos();
                CarregarRetirados();
            }
            else
            {
                MessageBox.Show("Erro ao recuperar pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarPedidos();
            CarregarRetirados();
        }

        private void btnCadastrarPedido_Click(object sender, EventArgs e)
        {
            FormAtendente formAtendente = new FormAtendente(_cliente);
            formAtendente.ShowDialog();
            CarregarPedidos();
        }

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            FormCadastroProduto formProduto = new FormCadastroProduto();
            formProduto.ShowDialog();
        }

        private void pcbLogo_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e) { }
        private void dgvRetirados_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblBemVindo_Click(object sender, EventArgs e) { }
    }
}