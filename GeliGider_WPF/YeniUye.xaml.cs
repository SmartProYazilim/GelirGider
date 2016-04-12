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
using GeliGider_WPF.DB;
using Microsoft.Win32;
using System.Windows.Navigation;
using System.IO;
using System.Text.RegularExpressions;

namespace GeliGider_WPF
{
    /// <summary>
    /// Interaction logic for YeniUye.xaml
    /// </summary>
    public partial class YeniUye : Window
    {
        public YeniUye()
        {
            InitializeComponent();
        }
        OpenFileDialog a = new OpenFileDialog();
        Random rnd = new Random();
        private void btn_Kaydet_Click(object sender, RoutedEventArgs e)
        {
            HesapProEntities1 ent = new HesapProEntities1();
            if (txbKadi.Text != "" && txbAdSoyad.Text != "" && txb_Email.Text != "" && txbCevap.Text != "" && txbTelefon.Text != "" && cmb_Guvenlik.Text != "" && txb_Sifre.Password != "" && txb_SifreOnay.Password != "")
            {
                if (txb_SifreOnay.Password != txb_Sifre.Password)
                {
                    MessageBox.Show("şifre onay kısmıyla şifre uyuşmuyor");
                    return;
                }
                else if (!(Regex.IsMatch(txb_Email.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)))
                {
                    MessageBox.Show("Geçersiz bir email adresi girdiniz, Tekrar deneyin");
                    return;
                }
                else{

                        try
                        {
                            Random rnd = new Random();
                            // seçilen fotoyu bin klasörüne kopyala
                            var ResimYolu = a.SafeFileName;
                            var resimAdi = rnd.Next(1,9999999) + "_" + ResimYolu.Split('/')[ResimYolu.Split('/').Length - 1];


                            var emailVarmi = (from k in ent.Kullanicilars
                                              where k.email == txb_Email.Text
                                              select k.email).Distinct().ToList();
                            var kullaniciVarmi = (from k in ent.Kullanicilars
                                                  where k.kadi == txbKadi.Text
                                                  select k.kadi).Distinct().ToList();


                            if (emailVarmi.Count < 1 && kullaniciVarmi.Count < 1)
                            {
                                Kullanicilar kl = new Kullanicilar();
                                kl.ID = rnd.Next(1, 1000000);
                                kl.kadi = txbKadi.Text;
                                kl.sifre = txb_Sifre.Password;
                                kl.adsoyad = txbAdSoyad.Text;
                                kl.email = txb_Email.Text;
                                kl.g_soru = cmb_Guvenlik.Text;
                                kl.g_cevabı = txbCevap.Text;
                                kl.telefon = txbTelefon.Text;

                                if (a.FileName == "")
                                {
                                    kl.fotograf = @"img\fotograf.png";
                                }
                                else
                                {
                                    File.Copy(a.FileName, AppDomain.CurrentDomain.BaseDirectory + @"img\" + resimAdi);
                                    kl.fotograf = @"img\" + resimAdi;
                                }
                                
                                ent.Kullanicilars.Add(kl);
                                ent.SaveChanges();

                                MessageBox.Show("Kullanıcı Başarıyla Kaydedildi.");
                            }
                            else
                            {
                                MessageBox.Show("Bu maille veya bu kullanıcı adıyla bir kullanıcı bulunuyor. Başka bir mail veya kullanıcı adı deneyiniz.");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                            return;
                        }
	                
                }
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurmalısınız !!!");
            }
        }

        private void btn_Fotograf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                a.ShowDialog();
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(a.FileName);
                img.EndInit();
                Resim.Source = img;
            }
            catch (Exception)
            {
                return;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
