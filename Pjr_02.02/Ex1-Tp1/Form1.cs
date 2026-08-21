using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex1_Tp1;

namespace Ex1_Tp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float n1, n2, n3, n4, resultado;

            n1 = float.Parse(textBox1.Text);
            n2 = float.Parse(textBox1.Text);
            n3 = float.Parse(textBox1.Text);
            n4 = float.Parse(textBox1.Text);

            resultado = (n1 + n2 + n3 + n4)/4;

            MessageBox.Show("Média = " + resultado);



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CalcMédia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox5.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double angulo, sen, cos, tan, sec;

            angulo = double.Parse(textBox5.Text);

            angulo = angulo * Math.PI / 180;
            
            sen = Math.Sin(angulo);
            cos = Math.Cos(angulo);
            tan = Math.Tan(angulo);
            sec = 1 / Math.Cos(angulo);

            MessageBox.Show("Sen: "+sen);
            MessageBox.Show("Cos: " + cos);
            MessageBox.Show("Tan: " + tan);
            MessageBox.Show("Sec: " + sec);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double x, y, cont, r;

            x = double.Parse(textBox10.Text);
            y = double.Parse(textBox11.Text);

            r = Math.Pow(x,y);

            MessageBox.Show("Resultado = " + r);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox11.Text = "";

            textBox10.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            

            }

        private void button7_Click(object sender, EventArgs e)
        {
            float valor;
            if(!float.TryParse(comboBox1.Text, out valor) || valor < 0)
            {
                MessageBox.Show("Selecione uma opção");

            }

            ConverteBLL bll = new ConverteBLL();
            bll.Valor = valor;

            float resultado;

            if (comboBox1.SelectedIndex == 0)
            {
                resultado = bll.converteKM();
            }else
            {
                resultado = bll.converteMilha();
            }

            textBox7.Text = resultado.ToString("F2");

            textBox7.Focus();
        }

        private void convert_tbl5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Digite um valor!");
                return;
            }

            float valor;
            if (!float.TryParse(textBox6.Text, out valor) || valor < 0)
            {
                MessageBox.Show("Digite um número válido!");
                return;
            }

            ConverteBLL bll = new ConverteBLL();
            bll.Valor = valor;

            float resultado;

            if (radioButton1.Checked)
            {
                resultado = bll.converteKM();
            }
            else if (radioButton2.Checked)
            {
                resultado = bll.converteMilha();
            }
            else
            {
                MessageBox.Show("Selecione uma opção");
                return;
            }

            textBox9.Text = resultado.ToString("F2");

            textBox9.Focus();
        }
    }

    }


