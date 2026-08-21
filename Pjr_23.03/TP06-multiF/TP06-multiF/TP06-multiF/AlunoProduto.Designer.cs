namespace TP06_multiF
{
    partial class AlunoProduto
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.CADASTROSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosDeAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosDeProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CADASTROSToolStripMenuItem,
            this.sAIRToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CADASTROSToolStripMenuItem
            // 
            this.CADASTROSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosDeAlunosToolStripMenuItem,
            this.cadastrosDeProdutosToolStripMenuItem});
            this.CADASTROSToolStripMenuItem.Name = "CADASTROSToolStripMenuItem";
            this.CADASTROSToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.CADASTROSToolStripMenuItem.Text = "CADASTROS";
            // 
            // cadastrosDeAlunosToolStripMenuItem
            // 
            this.cadastrosDeAlunosToolStripMenuItem.Name = "cadastrosDeAlunosToolStripMenuItem";
            this.cadastrosDeAlunosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.cadastrosDeAlunosToolStripMenuItem.Text = "cadastros de alunos";
            this.cadastrosDeAlunosToolStripMenuItem.Click += new System.EventHandler(this.cadastrosDeAlunosToolStripMenuItem_Click);
            // 
            // cadastrosDeProdutosToolStripMenuItem
            // 
            this.cadastrosDeProdutosToolStripMenuItem.Name = "cadastrosDeProdutosToolStripMenuItem";
            this.cadastrosDeProdutosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.cadastrosDeProdutosToolStripMenuItem.Text = "cadastros de produtos";
            this.cadastrosDeProdutosToolStripMenuItem.Click += new System.EventHandler(this.cadastrosDeProdutosToolStripMenuItem_Click);
            // 
            // sAIRToolStripMenuItem
            // 
            this.sAIRToolStripMenuItem.Name = "sAIRToolStripMenuItem";
            this.sAIRToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.sAIRToolStripMenuItem.Text = "SAIR";
            this.sAIRToolStripMenuItem.Click += new System.EventHandler(this.sAIRToolStripMenuItem_Click);
            // 
            // AlunoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AlunoProduto";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AlunoProduto_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CADASTROSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosDeAlunosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosDeProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAIRToolStripMenuItem;
    }
}

