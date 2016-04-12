using GeliGider_WPF.DB;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GeliGider_WPF
{
    /// <summary>
    /// Interaction logic for SifremiUnuttum.xaml
    /// </summary>
    public partial class SifremiUnuttum : Window
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        public string email;
        HesapProEntities1 ent = new HesapProEntities1();
        private void btn_Guvenlik_Click(object sender, RoutedEventArgs e)
        {
            if (txtCevap.Text != "" && cmbGuvenlikSorusu.Text != "" && txbEmail.Text != "")
            {
                var kullaniciBilgileri = (from u in ent.Kullanicilars
                    where u.email == txbEmail.Text && u.g_soru == cmbGuvenlikSorusu.Text && u.g_cevabı==txtCevap.Text
                    select u.sifre
                    ).FirstOrDefault();
                try
                {
                    if (kullaniciBilgileri.Length > 0)
                    {
                        this.email = txbEmail.Text;
                        SifreGuncelle acilanForm = new SifreGuncelle();
                        acilanForm.txtVeri.Text = this.email;
                        acilanForm.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen bilgilerinizi kontrol edip tekrar deneyiniz.");
                }
                


            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            
        }

        private void btn_Email_Click(object sender, RoutedEventArgs e)
        {
            if (txbEmail.Text != "")
            {
                var kullaniciBilgileri = (from u in ent.Kullanicilars
                                          where u.email == txbEmail.Text
                                          select u
                    ).ToList();
                if (kullaniciBilgileri.Count > 0)
                {
                    try
                    {
                    MailMessage ePosta = new MailMessage();
                    ePosta.From = new MailAddress("Your Name", "HesapPro");
                    ePosta.To.Add(txbEmail.Text);

                    ePosta.Subject = "HesapProŞifre";
                    ePosta.Body = "Şifreniz: " + (from u in ent.Kullanicilars
                                   where u.email == txbEmail.Text
                                   select u.sifre).FirstOrDefault();
                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new System.Net.NetworkCredential("yourmail@adres", "yourPassword");
                    smtp.Port = 587;
                    smtp.Host = "smtp.live.com";
                    smtp.EnableSsl = true;
                    object userState = ePosta;


                        smtp.Send(ePosta);
                        MessageBox.Show("Şifreniz e-posta adresinize gönderilmiştir.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message +  @" |Mail Gönderme Hatası");
                    }
                }
                    
                else
                {
                    MessageBox.Show("Sistemde böyle bir mail adresi bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Email adresinizi boş geçmeyiniz.");
            }
    }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var SorulariCek = ent.Kullanicilars.Select(u=> u.g_soru).Distinct().ToList();
            cmbGuvenlikSorusu.ItemsSource = SorulariCek;
            btn_Email.Visibility = System.Windows.Visibility.Hidden;

        }

        private void rd1_Checked(object sender, RoutedEventArgs e)
        {
            btn_Email.Visibility = System.Windows.Visibility.Visible;
           
            lblCevap.Visibility = System.Windows.Visibility.Hidden;
            lblGuvenlik.Visibility = System.Windows.Visibility.Hidden;
            txtCevap.Visibility = System.Windows.Visibility.Hidden;
            cmbGuvenlikSorusu.Visibility = System.Windows.Visibility.Hidden;
            btn_Guvenlik.Visibility = System.Windows.Visibility.Hidden;
        }

        private void rd2_Checked(object sender, RoutedEventArgs e)
        {
            btn_Email.Visibility = System.Windows.Visibility.Hidden;

            lblCevap.Visibility = System.Windows.Visibility.Visible;
            lblGuvenlik.Visibility = System.Windows.Visibility.Visible;
            txtCevap.Visibility = System.Windows.Visibility.Visible;
            cmbGuvenlikSorusu.Visibility = System.Windows.Visibility.Visible;
            btn_Guvenlik.Visibility = System.Windows.Visibility.Visible;
        }

    }
}
