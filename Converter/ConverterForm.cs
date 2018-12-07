using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class ConverterForm : Form
    {
        public ConverterForm()
        {
            InitializeComponent();
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox1, "О программе");
        }

        private void ConvertValue()
        {
            string from, to;
            double converted;
            from = comboBox1.SelectedItem.ToString();
            to = comboBox2.SelectedItem.ToString();
            converted = Convert.ToDouble(richTextBox1.Text);
            using (StreamReader sr = new StreamReader("..\\..\\kurs.csv"))
            {
                string line;
                string[] row = new string[6];
                double[] UAH = new double[2];
                double[] USD = new double[2];
                double[] RUB = new double[2];
                while ((line = sr.ReadLine()) != null)
                {
                    row = line.Split(';');
                    UAH[0] = double.Parse(row[0]);
                    UAH[1] = double.Parse(row[1]);
                    USD[0] = double.Parse(row[2]);
                    USD[1] = double.Parse(row[3]);
                    RUB[0] = double.Parse(row[4]);
                    RUB[1] = double.Parse(row[5]);
                }
                if (from == "UAH")
                {
                    switch (to)
                    {
                        case "USD":
                            richTextBox2.Text = Convert.ToString(converted * UAH[0]);
                            break;
                        case "RUB":
                            richTextBox2.Text = Convert.ToString(converted * UAH[1]);
                            break;
                    }
                }
                if (from == "USD")
                {
                    switch (to)
                    {
                        case "UAH":
                            richTextBox2.Text = Convert.ToString(converted * USD[0]);
                            break;
                        case "RUB":
                            richTextBox2.Text = Convert.ToString(converted * USD[1]);
                            break;
                    }
                }
                if (from == "RUB")
                {
                    switch (to)
                    {
                        case "USD":
                            richTextBox2.Text = Convert.ToString(converted * RUB[0]);
                            break;
                        case "UAH":
                            richTextBox2.Text = Convert.ToString(converted * RUB[1]);
                            break;
                    }
                }
            }
        }

        private void EqualValue()
        {
            string from, to;
            from = comboBox1.SelectedItem.ToString();
            to = comboBox2.SelectedItem.ToString();
            if (from == to)
            {
                MessageBox.Show("Это одна и та же валюта", "Внимание!");
            }
        }

        private void AddNumber(int s)
        {
            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = s.ToString("0.######");
            }
            else
            {
                richTextBox1.Text += s;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            EqualValue();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EqualValue();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = double.Parse(richTextBox1.Text);
            }
            catch (Exception ex)
            {
                string err = String.Format("Error number. {0}", ex.Message);
                MessageBox.Show(err, "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (richTextBox1.Text == string.Empty)
            {
                MessageBox.Show("Введите количество валюты для перевода!", "Внимание!");
            }
            else
            {
                ConvertValue();
            }
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            AddNumber(0);
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            AddNumber(1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AddNumber(2);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AddNumber(3);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AddNumber(4);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            AddNumber(5);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            AddNumber(6);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            AddNumber(7);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            AddNumber(8);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            AddNumber(9);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "0";
            richTextBox2.Text = "0";
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            string a = "";
            int i = 0;
            if (richTextBox1.Text != "0")
            {
                while (i < richTextBox1.Text.Length - 1)
                {
                    a += richTextBox1.Text[i];
                    i++;
                }
                richTextBox1.Text = a;
                if (a == string.Empty)
                {
                    richTextBox1.Text = "0";
                }
            }

        }

        private void ButtonComma_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += ",";
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            About about = new About();
            if (about.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}