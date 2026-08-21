using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
namespace TP09_Livros
{
    public partial class Form1 : Form
    {
        private List<string[]> livros = new List<string[]>();
        private int indiceAtual = 0;
        private int numeroPagina = 0;
        private const int LIVROS_POR_PAGINA = 5;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LivroBLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LivroBLL.desconecta();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            OleDbDataReader reader = LivroBLL.listaLivros();
            while (reader.Read())
            {
                listBox1.Items.Add(
                    reader.GetString(0) + " - " +
                    reader.GetString(1) + " - " +
                    reader.GetString(2)
                );
            }
            reader.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OleDbDataReader reader = LivroBLL.listaLivros();
            if (reader == null)
            {
                MessageBox.Show("Erro ao acessar o banco!");
                return;
            }
            Word.Application word = new Word.Application();
            Word.Document doc = word.Documents.Add();
            while (reader.Read())
            {
                doc.Content.InsertAfter(
                    reader.GetString(0) + " - " +
                    reader.GetString(1) + " - " +
                    reader.GetString(2) + "\n"
                );
            }
            reader.Close();
            doc.SaveAs(@"C:\Users\Public\listagem.docx");
            word.Quit();
            MessageBox.Show("Arquivo Word gerado!");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OleDbDataReader reader = LivroBLL.listaLivros();
            Excel.Application excel = new Excel.Application();
            excel.Workbooks.Add();
            Excel.Worksheet ws = (Excel.Worksheet)excel.ActiveSheet;
            ws.Cells[1, 1] = "Código";
            ws.Cells[1, 2] = "Título";
            ws.Cells[1, 3] = "Autor";
            int linha = 2;
            while (reader.Read())
            {
                ws.Cells[linha, 1] = reader.GetString(0);
                ws.Cells[linha, 2] = reader.GetString(1);
                ws.Cells[linha, 3] = reader.GetString(2);
                linha++;
            }
            reader.Close();
            ws.SaveAs(@"C:\Users\Public\listagem.xlsx");
            excel.Quit();
            MessageBox.Show("Arquivo Excel gerado!");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            livros.Clear();
            indiceAtual = 0;
            numeroPagina = 0;

            OleDbDataReader reader = LivroBLL.listaLivros();
            if (reader == null) { MessageBox.Show("Erro no banco!"); return; }

            while (reader.Read())
                livros.Add(new string[] { reader.GetString(0), reader.GetString(1), reader.GetString(2) });

            reader.Close();

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float margEsq = 60f;
            float margDir = e.PageBounds.Width - 60f;
            float y = 55f;
            numeroPagina++;

            Font fGrande = new Font("Arial", 13, FontStyle.Bold);
            Font fMedio = new Font("Arial", 11, FontStyle.Bold);
            Font fNormal = new Font("Arial", 10);
            Font fRodape = new Font("Arial", 9, FontStyle.Italic);

            g.DrawString("UNISANTA", fGrande, Brushes.Black, margEsq, y);
            g.DrawString("- Universidade Santa Cecília", fMedio, Brushes.Black, margEsq + 120f, y + 2);
            y += fGrande.GetHeight() + 3;

            g.DrawString("Disciplina", fMedio, Brushes.Black, margEsq, y);
            g.DrawString("- Aplicações para Desktop", fNormal, Brushes.Black, margEsq + 120f, y + 1);
            y += fMedio.GetHeight() + 3;

            g.DrawString("Professor", fMedio, Brushes.Black, margEsq, y);
            g.DrawString("- Professor Exemplo", fNormal, Brushes.Black, margEsq + 120f, y + 1);
            y += fMedio.GetHeight() + 10;

            g.DrawLine(Pens.Black, margEsq, y, margDir, y);
            y += 14;

            int cont = 0;
            while (indiceAtual < livros.Count && cont < LIVROS_POR_PAGINA)
            {
                string[] l = livros[indiceAtual];
                g.DrawString(l[0] + "  -  " + l[1] + "  -  " + l[2], fNormal, Brushes.Black, margEsq, y);
                y += fNormal.GetHeight() + 5;
                indiceAtual++;
                cont++;
            }

            string pag = "Página " + numeroPagina;
            SizeF pagSize = g.MeasureString(pag, fRodape);
            g.DrawString(pag, fRodape, Brushes.Black, margDir - pagSize.Width, e.PageBounds.Height - 55f);

            e.HasMorePages = indiceAtual < livros.Count;
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
        }
    }
}