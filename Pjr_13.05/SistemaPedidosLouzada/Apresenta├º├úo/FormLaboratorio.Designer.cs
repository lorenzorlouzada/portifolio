namespace Apresentacao
{
    partial class FormLaboratorio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLaboratorio));
            this.label1 = new System.Windows.Forms.Label();
            this.lblBemVindo = new System.Windows.Forms.Label();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.lblFilaPedidos = new System.Windows.Forms.Label();
            this.btnEmProducao = new System.Windows.Forms.Button();
            this.btnPronto = new System.Windows.Forms.Button();
            this.btnRetirado = new System.Windows.Forms.Button();
            this.btnDesfazer = new System.Windows.Forms.Button();
            this.btnCadastrarProduto = new System.Windows.Forms.Button();
            this.btnCadastrarPedido = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.dgvRetirados = new System.Windows.Forms.DataGridView();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetirados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(173, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 2);
            this.label1.TabIndex = 14;
            // 
            // lblBemVindo
            // 
            this.lblBemVindo.AutoSize = true;
            this.lblBemVindo.Location = new System.Drawing.Point(259, 39);
            this.lblBemVindo.Name = "lblBemVindo";
            this.lblBemVindo.Size = new System.Drawing.Size(90, 20);
            this.lblBemVindo.TabIndex = 13;
            this.lblBemVindo.Text = "Laboratório";
            this.lblBemVindo.Click += new System.EventHandler(this.lblBemVindo_Click);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(23, 149);
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.RowHeadersWidth = 62;
            this.dgvPedidos.RowTemplate.Height = 28;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(812, 336);
            this.dgvPedidos.TabIndex = 12;
            this.dgvPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellContentClick);
            this.dgvPedidos.SelectionChanged += new System.EventHandler(this.dgvPedidos_SelectionChanged);
            // 
            // pcbLogo
            // 
            this.pcbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogo.Image")));
            this.pcbLogo.Location = new System.Drawing.Point(139, 8);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(137, 107);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLogo.TabIndex = 11;
            this.pcbLogo.TabStop = false;
            this.pcbLogo.Click += new System.EventHandler(this.pcbLogo_Click);
            // 
            // lblFilaPedidos
            // 
            this.lblFilaPedidos.AutoSize = true;
            this.lblFilaPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblFilaPedidos.Location = new System.Drawing.Point(22, 122);
            this.lblFilaPedidos.Name = "lblFilaPedidos";
            this.lblFilaPedidos.Size = new System.Drawing.Size(144, 25);
            this.lblFilaPedidos.TabIndex = 15;
            this.lblFilaPedidos.Text = "Fila de pedidos";
            // 
            // btnEmProducao
            // 
            this.btnEmProducao.Location = new System.Drawing.Point(198, 492);
            this.btnEmProducao.Name = "btnEmProducao";
            this.btnEmProducao.Size = new System.Drawing.Size(143, 56);
            this.btnEmProducao.TabIndex = 16;
            this.btnEmProducao.Text = "Em produção";
            this.btnEmProducao.UseVisualStyleBackColor = true;
            this.btnEmProducao.Click += new System.EventHandler(this.btnEmProducao_Click);
            // 
            // btnPronto
            // 
            this.btnPronto.Location = new System.Drawing.Point(347, 491);
            this.btnPronto.Name = "btnPronto";
            this.btnPronto.Size = new System.Drawing.Size(143, 56);
            this.btnPronto.TabIndex = 17;
            this.btnPronto.Text = "Pronto";
            this.btnPronto.UseVisualStyleBackColor = true;
            this.btnPronto.Click += new System.EventHandler(this.btnPronto_Click);
            // 
            // btnRetirado
            // 
            this.btnRetirado.Location = new System.Drawing.Point(496, 491);
            this.btnRetirado.Name = "btnRetirado";
            this.btnRetirado.Size = new System.Drawing.Size(143, 56);
            this.btnRetirado.TabIndex = 18;
            this.btnRetirado.Text = "Retirado";
            this.btnRetirado.UseVisualStyleBackColor = true;
            this.btnRetirado.Click += new System.EventHandler(this.btnRetirado_Click);
            // 
            // btnDesfazer
            // 
            this.btnDesfazer.Location = new System.Drawing.Point(514, 95);
            this.btnDesfazer.Name = "btnDesfazer";
            this.btnDesfazer.Size = new System.Drawing.Size(143, 34);
            this.btnDesfazer.TabIndex = 19;
            this.btnDesfazer.Text = "Desfazer";
            this.btnDesfazer.UseVisualStyleBackColor = true;
            this.btnDesfazer.Click += new System.EventHandler(this.btnDesfazer_Click);
            // 
            // btnCadastrarProduto
            // 
            this.btnCadastrarProduto.Location = new System.Drawing.Point(339, 95);
            this.btnCadastrarProduto.Name = "btnCadastrarProduto";
            this.btnCadastrarProduto.Size = new System.Drawing.Size(169, 34);
            this.btnCadastrarProduto.TabIndex = 20;
            this.btnCadastrarProduto.Text = "Cadastrar produto";
            this.btnCadastrarProduto.UseVisualStyleBackColor = true;
            this.btnCadastrarProduto.Click += new System.EventHandler(this.btnCadastrarProduto_Click);
            // 
            // btnCadastrarPedido
            // 
            this.btnCadastrarPedido.Location = new System.Drawing.Point(184, 95);
            this.btnCadastrarPedido.Name = "btnCadastrarPedido";
            this.btnCadastrarPedido.Size = new System.Drawing.Size(143, 34);
            this.btnCadastrarPedido.TabIndex = 21;
            this.btnCadastrarPedido.Text = "Cadastrar pedido";
            this.btnCadastrarPedido.UseVisualStyleBackColor = true;
            this.btnCadastrarPedido.Click += new System.EventHandler(this.btnCadastrarPedido_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(760, 109);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 34);
            this.btnAtualizar.TabIndex = 22;
            this.btnAtualizar.Text = "Reload";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // dgvRetirados
            // 
            this.dgvRetirados.AllowUserToAddRows = false;
            this.dgvRetirados.AllowUserToDeleteRows = false;
            this.dgvRetirados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRetirados.Location = new System.Drawing.Point(23, 580);
            this.dgvRetirados.MultiSelect = false;
            this.dgvRetirados.Name = "dgvRetirados";
            this.dgvRetirados.ReadOnly = true;
            this.dgvRetirados.RowHeadersVisible = false;
            this.dgvRetirados.RowHeadersWidth = 62;
            this.dgvRetirados.RowTemplate.Height = 28;
            this.dgvRetirados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRetirados.Size = new System.Drawing.Size(812, 193);
            this.dgvRetirados.TabIndex = 23;
            this.dgvRetirados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRetirados_CellContentClick);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.Location = new System.Drawing.Point(692, 540);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(143, 34);
            this.btnRecuperar.TabIndex = 24;
            this.btnRecuperar.Text = "Recuperar";
            this.btnRecuperar.UseVisualStyleBackColor = true;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(22, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Pedido retirados";
            // 
            // FormLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 785);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.dgvRetirados);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnCadastrarPedido);
            this.Controls.Add(this.btnCadastrarProduto);
            this.Controls.Add(this.btnDesfazer);
            this.Controls.Add(this.btnRetirado);
            this.Controls.Add(this.btnPronto);
            this.Controls.Add(this.btnEmProducao);
            this.Controls.Add(this.lblFilaPedidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBemVindo);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.pcbLogo);
            this.Name = "FormLaboratorio";
            this.Text = "FormLaboratorio";
            this.Load += new System.EventHandler(this.FormLaboratorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetirados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBemVindo;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.Label lblFilaPedidos;
        private System.Windows.Forms.Button btnEmProducao;
        private System.Windows.Forms.Button btnPronto;
        private System.Windows.Forms.Button btnRetirado;
        private System.Windows.Forms.Button btnDesfazer;
        private System.Windows.Forms.Button btnCadastrarProduto;
        private System.Windows.Forms.Button btnCadastrarPedido;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridView dgvRetirados;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.Label label2;
    }
}