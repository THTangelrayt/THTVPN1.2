using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myVPN
{


    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private static string FolderPath => string.Concat(Directory.GetCurrentDirectory(),
           "\\VPN");
        private void monoFlat_TrackBar1_ValueChanged()
        {

        }

        private void monoFlat_TrackBar2_ValueChanged()
        {

        }

        private void monoFlat_Toggle1_ToggledChanged()
        {

        }

        private void starteryaz()
        {

        }
        private void starteroku()
        {


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dosyaoku();

        }

        private void ambiance_Button_12_Click(object sender, EventArgs e)
        {
            string yazi = "x";
            if (monoFlat_Toggle1.Toggled)
            {
                yazi = "1";
            }
            else
            {
                yazi = "0";
            }


            if (yazi == "1")
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue("myVPN", "\"" + Application.ExecutablePath + "\"");
                monoFlat_Toggle1.Toggled = true;



            }
            else if (yazi == "0")
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue("myVPN");
                monoFlat_Toggle1.Toggled = false;
            }
            sunucukaydet();




        }

        private void dosyaoku()
        {
            string dosya_yolu = @"starter.true";

            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);

            StreamReader sw = new StreamReader(fs);

            string yazi = sw.ReadLine();

            if (yazi == "1")
            {
                monoFlat_Toggle1.Toggled = true;


            }
            else
            {
                monoFlat_Toggle1.Toggled = false;
            }


            sw.Close();
            fs.Close();
        }


        private void sunucuyaz()
        {
            string dosya_yolu = @"starter.true";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            if (monoFlat_Toggle1.Toggled)
            {
                sw.WriteLine("1");
            }
            else
            {
                sw.WriteLine("0");
            }

            
            sw.Flush();
            sw.Close();
            fs.Close();




        }
        private void sunucukaydet()
        {
            File.Delete(@"starter.true");
            FileStream fs = File.Create(@"starter.true");
            fs.Close();
            sunucuyaz();



        }

        private void ambiance_Button_11_Click(object sender, EventArgs e)
        {
            disconnet();

        }
        private void disconnet()
        {
            File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");
            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            newProcess.Start();
            newProcess.WaitForExit();

            Directory.Delete(@"VPN");

        }
    }

}
