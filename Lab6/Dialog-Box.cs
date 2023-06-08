using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Dialog_Box : Form
    {
        string str;
        int size;
        public string Txt1
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string Txt2
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public Dialog_Box()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.OK;
            this.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //3shan lma y5osh yla2eh
            colorDialog1.Color = Form1.revenueColor;
            DialogResult dlg1= colorDialog1.ShowDialog();
            if (dlg1 == DialogResult.OK)
            {
                //3shan y8yro f form1
                Form1.revenueColor = colorDialog1.Color;
                Invalidate();

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        public string RadioFont
        {
            set
            {
                str = value;
                if(str=="Times New Roman")
                {
                    radioButton1.Checked= true;
                }else if (str=="Arial")
                {
                    radioButton2.Checked= true;
                }else if (str == "Courier")
                {
                    radioButton3.Checked= true;
                }
            }
            get
            {
                if(radioButton1.Checked == true)
                {
                    str = "Times New Roman";
                }else if(radioButton2.Checked == true)
                {
                    str = "Arial";
                }else if(radioButton3.Checked == true)
                {
                    str = "Courier";
                }
                return str;
            }

        }
        public int RadioSize
        {
            set
            {
                size = value;
                if(size == 16)
                {
                    radioButton4.Checked= true;
                }else if(size==20){
                    radioButton5.Checked= true;
                }else if (size == 24)
                {
                    radioButton6.Checked= true;
                }
            }
            get
            {
                if (radioButton4.Checked == true)
                {
                    size= 16;
                }else if(radioButton5.Checked == true)
                {
                    size= 20;
                }else if (radioButton6.Checked == true)
                {
                    size= 24;
                }
                return size;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
