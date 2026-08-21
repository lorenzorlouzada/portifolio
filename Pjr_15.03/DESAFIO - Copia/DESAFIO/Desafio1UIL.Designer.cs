namespace DESAFIO
{
    partial class Desafio1UIL
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Desafio1UIL));
            this.txtPropriedade = new System.Windows.Forms.TextBox();
            this.Adicionar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClasse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listPropriedades = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtPropriedade
            // 
            this.txtPropriedade.Location = new System.Drawing.Point(38, 149);
            this.txtPropriedade.Multiline = true;
            this.txtPropriedade.Name = "txtPropriedade";
            this.txtPropriedade.Size = new System.Drawing.Size(198, 30);
            this.txtPropriedade.TabIndex = 1;
            // 
            // Adicionar
            // 
            this.Adicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Adicionar.Location = new System.Drawing.Point(38, 185);
            this.Adicionar.Name = "Adicionar";
            this.Adicionar.Size = new System.Drawing.Size(198, 33);
            this.Adicionar.TabIndex = 2;
            this.Adicionar.Text = "=>";
            this.Adicionar.UseVisualStyleBackColor = true;
            this.Adicionar.Click += new System.EventHandler(this.Adicionar_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button2.Location = new System.Drawing.Point(38, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(512, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Limpar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button3.Location = new System.Drawing.Point(38, 417);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(512, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "Gerar Classe";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(33, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome da Classe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(33, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Propriedade";
            // 
            // txtClasse
            // 
            this.txtClasse.Location = new System.Drawing.Point(280, 63);
            this.txtClasse.Multiline = true;
            this.txtClasse.Name = "txtClasse";
            this.txtClasse.Size = new System.Drawing.Size(270, 28);
            this.txtClasse.TabIndex = 8;
            this.txtClasse.TextChanged += new System.EventHandler(this.txtClasse_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(286, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lista de Propriedades";
            // 
            // listPropriedades
            // 
            this.listPropriedades.FormattingEnabled = true;
            this.listPropriedades.Location = new System.Drawing.Point(291, 149);
            this.listPropriedades.Name = "listPropriedades";
            this.listPropriedades.Size = new System.Drawing.Size(233, 186);
            this.listPropriedades.TabIndex = 11;
            this.listPropriedades.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Desafio1UIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(608, 536);
            this.Controls.Add(this.listPropriedades);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClasse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Adicionar);
            this.Controls.Add(this.txtPropriedade);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Name = "Desafio1UIL";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPropriedade;
        private System.Windows.Forms.Button Adicionar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClasse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listPropriedades;
    }
}

