using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myVPN
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }


        private void ambiance_Button_11_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (kadi.Text == "AngelRayt" && pass.Text == "THT")
                {

                    Form1 frm1 = new Form1();
                    frm1.Show();
                    Hide();






                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                }
            }
            catch
            {
               

            }
            {
               
            }
        }
    }

    }

