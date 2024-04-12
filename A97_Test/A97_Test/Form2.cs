using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace A97_Test
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "ADMIN")
            {
                Form1 mainProgram = new Form1();
                this.Visible = false;

                mainProgram.Visible = true;
                mainProgram.textboxMSG = textBox1.Text;
            }
            else
            {
                if (textBox1.Text.Length != 8)
                {
                    MessageBox.Show("OPID 格式不符!!!", "提示");
                }
                else
                {
                    Form1 mainProgram = new Form1();
                    this.Visible = false;
                    
                    mainProgram.Visible = true;
                    mainProgram.textboxMSG = textBox1.Text;
                }
            }
        }

        

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                if (textBox1.Text.ToUpper() == "ADMIN" )
                {
                    Form1 mainProgram = new Form1();
                    this.Visible = false;
                    
                    mainProgram.Visible = true;
                    mainProgram.textboxMSG = textBox1.Text;
                }
                else
                {
                    if (textBox1.Text.Length != 8)
                    {
                        MessageBox.Show("OPID 格式不符!!!", "提示");
                    }
                    else
                    {
                        Form1 mainProgram = new Form1();
                        this.Visible = false;

                        mainProgram.Visible = true;
                        mainProgram.textboxMSG = textBox1.Text;
                    }
                }
                
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //關閉介面 將程式完全關閉
            Environment.Exit(Environment.ExitCode);

            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
