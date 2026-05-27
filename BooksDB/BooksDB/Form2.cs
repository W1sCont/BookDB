using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BooksDB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string InputTextBox1
        {
            get { return textBox1.Text.Trim(); }
            set { textBox1.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Будь ласка, заповніть поле.");
                return;
            }
        }

        public void SetDialogTitle(string text,string label)
        {
            Text = text;
            label1.Text = label;
            button1.Text = "Ок";
            button2.Text = "Скасувати";
        }
    }
}
