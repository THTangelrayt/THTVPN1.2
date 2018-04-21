using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myVPN
{
    public partial class Form4 : Form
    {

        private static string FolderPath => string.Concat(Directory.GetCurrentDirectory(),
            "\\VPN");
        public Form4()
        {
            InitializeComponent();
        }

        private void ambiance_Button_13_Click(object sender, EventArgs e)
        {
            vpnbaglan();
            teset();
            


        }
        private void durumkaydet()
        {
            Form1 frm1 = new Form1();
            string dosya_yolu = @"vpn.status";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(frm1.ambiance_Label5.Text);
            sw.Flush();
            sw.Close();
            fs.Close();


        }
        private void durumsil()
        {
            File.Delete(@"vpn.status");
            FileStream fs = File.Create(@"vpn.status");
            fs.Close();
            durumkaydet();

        }

        private void vpnbaglan()
        {
            Form1 frm1 = new Form1();
            frm1.ambiance_Label5.Text = "Durum : Sunucular kontrol ediliyor...";
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + ambiance_TextBox4.Text);
            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());
            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + ambiance_TextBox2.Text + " " + ambiance_TextBox3.Text + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            frm1.ambiance_Label5.Text = "Durum : Bağlantı bekleniyor";
            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Hidden

                }
            };
            newProcess.Start();
            newProcess.WaitForExit();
           frm1.ambiance_Label5.Text = "Durum :Bağlantı oluştu, son kontroller yapılıyor";



            frm1.ambiance_Label7.Text = "Bağlandığınız sunucu  : " + ambiance_TextBox4.Text;
           frm1. ambiance_Label6.Text = "Kullanıcı adı                 :" +ambiance_TextBox2.Text;
            frm1.ambiance_Label10.Text = "Şifre                              :" + ambiance_TextBox3.Text;
            teset();
        }
        private void teset()
        {

            Form1 frm1 = new Form1();
            try
            {
                Uri url = new Uri("https://www.wikipedia.org/");
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);

                frm1.ambiance_Label5.Text = "VPN sunucusuna bağlanıldı.";
                ipsorgula();

            }
            catch
            {
                MessageBox.Show("Bağlanırken hata oluştu");

                frm1.ambiance_Label5.Text = "VPN Bağlı değil.";


                frm1.ambiance_Label7.Text = "Bağlandığınız Sunucu  : ";
                frm1.ambiance_Label6.Text = "Kullanıcı Adı                 : ";
                frm1.ambiance_Label10.Text = "Şifre                              :";

            }

            ipsorgula();


        }
        private void ipsorgula()
        {
            Form1 frm1 = new Form1();

            try
            {
                Uri url = new Uri("http://whatismyip.host/my-ip-address-details");
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);
                HtmlNodeCollection titles = dokuman.DocumentNode.SelectNodes("//*[@id='hostname']/p");
                HtmlNodeCollection titles2 = dokuman.DocumentNode.SelectNodes("//*[@id='ipv4']/p");

                foreach (HtmlNode title in titles)
                {
                    frm1.iptxt.Text = (title.InnerText);
                    foreach (HtmlNode title2 in titles)
                    {
                        frm1.ambiance_Label11.Text = (title2.InnerText);
                    }



                }


            }

            catch (Exception)
            {

            }





            // 




        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void sunucuyaz()
        {
            Form1 frm1 = new Form1();
            string dosya_yolu = @"sunucu.ep";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(frm1.ambiance_Label7.Text);
            sw.Flush();
            sw.Close();
            fs.Close();




        }
        private void sunucukaydet()
        {
            Form1 frm1 = new Form1();
            File.Delete(@"sunucu.ep");
            FileStream fs = File.Create(@"sunucu.ep");
            fs.Close();
            sunucuyaz();



        }
        private void kadiyaz()
        {
            Form1 frm1 = new Form1();
            string dosya_yolu = @"vpn.ep";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(frm1.ambiance_Label6.Text);
            sw.Flush();
            sw.Close();
            fs.Close();




        }
        private void kadikaydet()
        {
            Form1 frm1 = new Form1();
            
            File.Delete(@"vpn.ep");
            FileStream fs = File.Create(@"vpn.ep");
            fs.Close();
            kadiyaz();




        }

        private void passyaz()
        {
            Form1 frm1 = new Form1();
            string dosya_yolu = @"pass.liv";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(frm1.ambiance_Label10.Text);
            sw.Flush();
            sw.Close();
            fs.Close();

        }
        private void passkaydet()
        {
            File.Delete(@"pass.liv");
            FileStream fs = File.Create(@"pass.liv");
            fs.Close();
            passyaz();
        }

       
    }
}
