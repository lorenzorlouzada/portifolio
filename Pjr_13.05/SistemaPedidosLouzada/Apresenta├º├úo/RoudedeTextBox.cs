using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Apresentacao
{
    public class RoundedTextBox : Panel
    {
        private TextBox textBox;
        public int BorderRadius { get; set; } = 10;
        public char PasswordChar { get { return textBox.PasswordChar; } set { textBox.PasswordChar = value; } }
        public new string Text { get { return textBox.Text; } set { textBox.Text = value; } }
        public RoundedTextBox()
        {
            textBox = new TextBox();
            textBox.BorderStyle = BorderStyle.None;
            textBox.Dock = DockStyle.Fill;
            textBox.Margin = new Padding(5);
            Padding = new Padding(8, 5, 8, 5);
            Controls.Add(textBox);
            BackColor = Color.White;
            Height = 36;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(rect.Right - BorderRadius, rect.Y, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(rect.Right - BorderRadius, rect.Bottom - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - BorderRadius, BorderRadius, BorderRadius, 90, 90);
            path.CloseFigure();
            g.FillPath(new SolidBrush(BackColor), path);
            g.DrawPath(new Pen(Color.LightGray, 1.5f), path);
        }
    }
}