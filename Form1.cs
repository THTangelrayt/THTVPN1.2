using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Net;
using HtmlAgilityPack;




namespace myVPN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string pass;

        private static string FolderPath => string.Concat(Directory.GetCurrentDirectory(),
            "\\VPN");

      
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };

            newProcess.Start();
            newProcess.WaitForExit();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }



        public void dosyadanOku()
        {
            string dosya_yolu = @"sunucu.ep";
            
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
          
            StreamReader sw = new StreamReader(fs);
           
            string yazi = sw.ReadLine();
            
            

                ambiance_Label7.Text = yazi;
            
          
            sw.Close();
            fs.Close();
            
        }
        public void dosyadanOku4()
        {
            string dosya_yolu = @"vpn.status";

            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);

            StreamReader sw = new StreamReader(fs);

            string yazi = sw.ReadLine();



            ambiance_Label5.Text = yazi;


            sw.Close();
            fs.Close();

        }


        public void dosyadanOku2()
        {
            string dosya_yolu = @"vpn.ep";

            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);

            StreamReader sw = new StreamReader(fs);

            string yazi = sw.ReadLine();
         

                ambiance_Label6.Text = yazi;
            

            sw.Close();
            fs.Close();

        }

        public void dosyadanOku3()
        {
            string dosya_yolu = @"pass.liv";

            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);

            StreamReader sw = new StreamReader(fs);

            string yazi = sw.ReadLine();
           

                ambiance_Label10.Text = yazi;
            

            sw.Close();
            fs.Close();

        }





        private void Form1_Load(object sender, EventArgs e)
        {
            ipsorgula();
            monoFlat_TrackBar2.Maximum = 100;
            monoFlat_TrackBar2.Minimum = 0;



           vericek();


           





            txtUsrname.Hide();
            txtPassword.Hide();

           dosyadanOku();
            dosyadanOku2();
            dosyadanOku3();
            dosyadanOku4();

            //KONTROL













            //KONTROL



            //try
            //{

            //string al = txtPassword.Text;
            //Uri url = new Uri("http://ezberyap.tk/post/farketmez");
            //WebClient client = new WebClient();
            //client.Encoding = Encoding.UTF8;
            //string html = client.DownloadString(url);
            //HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            //dokuman.LoadHtml(html);
            //HtmlNodeCollection titles = dokuman.DocumentNode.SelectNodes("//*[@id='content']/div[1]/div[3]/p/span");

            //foreach (HtmlNode title in titles)
            //{


            //    string kontrol = (title.InnerText);


            //        if (kontrol != "1.2")
            //        {
            //            MessageBox.Show("Programın yeni versiyonu yayınlandı. Lütfen aşağıdaki yeni sürümü indiriniz.");
            //            Process.Start("https://www.turkhackteam.org/turkhackteam-ar-ge-tim/1703767-turkhackteam-icin-vpn-angelrayt.html");
            //            this.Close();


            //        }


            //}
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Maalesef internetten bağlantınızda bir sorun olabilir. Lütfen kontrol ediniz");

            //}

            //finally
            //{
            //    //site aç https://www.turkhackteam.org/turkhackteam-ar-ge-tim/1703767-turkhackteam-icin-vpn-angelrayt.html


            //}

        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            for (int x=0; x < 30; x++)
            {

            }
        }

        private void avrupa1()
        {

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + "euro217.vpnbook.com");

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + txtPassword.Text + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };

            newProcess.Start();
            newProcess.WaitForExit();





        }

        private void vericek()
        {
            try
            {
                string al = txtPassword.Text;
                Uri url = new Uri("https://www.vpnbook.com/freevpn");
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);
                HtmlNodeCollection titles = dokuman.DocumentNode.SelectNodes("//*[@id='pricing']/div/div[2]/ul/li[9]/strong");

                foreach (HtmlNode title in titles)
                {
                    pass = (title.InnerText);


                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Sunucuyla bağlantı kurulamadı");
            }
            finally
            {

            }
            
        }

        private void sunucuyaz()
        {
            string dosya_yolu = @"sunucu.ep";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(ambiance_Label7.Text);
            sw.Flush();
            sw.Close();
            fs.Close();




        }
        private void sunucukaydet()
        {
            File.Delete(@"sunucu.ep");
            FileStream fs = File.Create(@"sunucu.ep");
            fs.Close();
            sunucuyaz();



        }
        private void kadiyaz()
        {
            string dosya_yolu = @"vpn.ep";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(ambiance_Label6.Text);
            sw.Flush();
            sw.Close();
            fs.Close();




        }
        private void kadikaydet()
        {
            File.Delete(@"vpn.ep");
            FileStream fs = File.Create(@"vpn.ep");
            fs.Close();
            kadiyaz();




        }

        private void passyaz()
        {
            string dosya_yolu = @"pass.liv";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(ambiance_Label10.Text);
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








        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            vericek();
            
            vpnbaglan();
            sunucukaydet();
            passkaydet();
            kadikaydet();
            durumkaydet();




        }
        private void durumkaydet()
        {
            string dosya_yolu = @"vpn.status";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(ambiance_Label5.Text);
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
        private void teset()
        {

            try
            {
                Uri url = new Uri("https://www.wikipedia.org/");
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);

                ambiance_Label5.Text = "VPN sunucusuna bağlanıldı.";
                ipsorgula();

            }
            catch
            {
                MessageBox.Show("Bağlanırken hata oluştu");

                ambiance_Label5.Text = "VPN Bağlı değil.";


                ambiance_Label7.Text = "Bağlandığınız Sunucu  : "  ;
                ambiance_Label6.Text = "Kullanıcı Adı                 : ";
                ambiance_Label10.Text = "Şifre                              :" ;

            }




        }


        private void vpnbaglan()
        {
            string sunucudegeri = "0";
            if (txtHost.Text == "Avrupa1")
            {
                sunucudegeri = "euro217.vpnbook.com";
            }
            if (txtHost.Text == "Avrupa2")
            {
                sunucudegeri = "euro214.vpnbook.com";
            }
            if (txtHost.Text == "Amerika1")
            {
                sunucudegeri = "us1.vpnbook.com";
            }
            if (txtHost.Text == "Amerika2")
            {
                sunucudegeri = "us2.vpnbook.com";
            }
            if (txtHost.Text == "Kanada")
            {
                sunucudegeri = "ca1.vpnbook.com";
            }
            if (txtHost.Text == "Almanya")
            {
                sunucudegeri = "de233.vpnbook.com";
            }
            if (txtHost.Text == "Fransa")
            {
                sunucudegeri = "fr1.vpnbook.com";
            }
            ambiance_Label5.Text = "Durum : Sunucular kontrol ediliyor...";
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + sunucudegeri);
            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());
            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + "vpnbook" + " " + pass + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            ambiance_Label5.Text = "Durum : Bağlantı bekleniyor";
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
            ambiance_Label5.Text = "Durum :Bağlantı oluştu, son kontroller yapılıyor";


         
            ambiance_Label7.Text = "Bağlandığınız sunucu  : " + sunucudegeri;
            ambiance_Label6.Text = "Kullanıcı adı                 : vpnbook";
            ambiance_Label10.Text = "Şifre                              :" + pass;


            // 
            teset();

           




            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ipsorgula()
        {

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
                    iptxt.Text = (title.InnerText);
                    foreach (HtmlNode title2 in titles)
                    {
                       ambiance_Label11.Text = (title2.InnerText);
                    }



                }


            }

            catch (Exception)
            {

            }




           
            // 




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
            ambiance_Label5.Text = "VPN kapatıldı. Son kontroller yapılıyor";
            ipsorgula();


            try
            {
                Uri url = new Uri("https://www.wikipedia.org/");
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);
            }
            catch (Exception)
            {
                ambiance_Label5.Text = "VPN Sunucusu başarılı bir şekilde kapatıldı";

                ambiance_Label7.Text = "Bağlandığınız sunucu  : ";
                ambiance_Label6.Text = "Kullanıcı adı                 : ";
                ambiance_Label10.Text = "Şifre                              :";
            }
            sunucukaydet();
            passkaydet();
            kadikaydet();
            durumkaydet();



        }
        private void btnDisconnect_Click_1(object sender, EventArgs e)
        {
            disconnet();


              }

        private void iTalk_ChatBubble_L1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programla ilgili her türlü soru/görüş ve önerinizi yazilimoffical@gmail.com   adresine yollayınız.");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();

        }

      

        private void ambiance_Button_12_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void monoFlat_TrackBar2_ValueChanged()
        {
            
           
            if (monoFlat_TrackBar2.Value == 0 || monoFlat_TrackBar2.Value <10)
            {
                iTalk_ChatBubble_L2.Show();


            }
            else
            {
                iTalk_ChatBubble_L2.Hide();

            }
        }

        private void ambiance_Button_11_Click_1(object sender, EventArgs e)
        {

            try
            {
                Uri url = new Uri(ambiance_TextBox1.Text);
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);
                MessageBox.Show("Bu siteye bağlantınız var.");


            }
            catch (Exception)
            {
                MessageBox.Show("Bu siteye erişiminiz yok. Lütfen Vpn bağlantısını açınız.");


            
            }
            finally
            {

            }
     }

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();

        }

      

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ayarlarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void monoFlat_Button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnet();

            Application.Exit();

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void bağlantıyıKesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnet();

        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();

        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void ambiance_Label5_Click(object sender, EventArgs e)
        {

        }
    }
}