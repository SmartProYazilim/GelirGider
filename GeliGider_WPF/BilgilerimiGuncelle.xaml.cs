using GeliGider_WPF.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for BilgilerimiGuncelle.xaml
    /// </summary>
    public partial class BilgilerimiGuncelle : Window
    {
        public BilgilerimiGuncelle()
        {
            InitializeComponent();
        }
        OpenFileDialog a = new OpenFileDialog();
        MainWindow mWindow = new MainWindow();
        HesapProEntities1 ent = new HesapProEntities1();
        private void btn_Kaydet_Click(object sender, RoutedEventArgs e)
        {
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
                else
                {

                    try
                    {
                        Random rnd = new Random();
                        // seçilen fotoyu bin klasörüne kopyala
                        var ResimYolu = a.SafeFileName;
                        var resimAdi = rnd.Next(1, 9999999) + "_" + ResimYolu.Split('/')[ResimYolu.Split('/').Length - 1];

                        Kullanicilar kl = new Kullanicilar();
                        var suankiKullanici = from b in ent.Kullanicilars
                                              where b.kadi == txtveri.Text
                                              select b;

                        var emailVarmi = (from k in ent.Kullanicilars
                                          where k.email == txb_Email.Text
                                          select k.email).Distinct().ToList();


                        if (emailVarmi.Count < 1)
                        {
                            suankiKullanici.FirstOrDefault().kadi = txbKadi.Text;
                            suankiKullanici.FirstOrDefault().sifre = txb_Sifre.Password;
                            suankiKullanici.FirstOrDefault().adsoyad = txbAdSoyad.Text;
                            suankiKullanici.FirstOrDefault().email = txb_Email.Text;
                            suankiKullanici.FirstOrDefault().g_soru = cmb_Guvenlik.Text;
                            suankiKullanici.FirstOrDefault().g_cevabı = txbCevap.Text;
                            suankiKullanici.FirstOrDefault().telefon = txbTelefon.Text;

                            if (a.FileName != "")
                            {
                                File.Copy(a.FileName, AppDomain.CurrentDomain.BaseDirectory + @"img\" + resimAdi);
                                suankiKullanici.FirstOrDefault().fotograf = @"img\" + resimAdi;
                            }

                            ent.SaveChanges();

                            MessageBox.Show("Kullanıcı Başarıyla Güncellendi, Program Kapatılıyor, Tekrar Giriş Yapınız.");

                            //Window win2 = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "Window Name");
                            //win2.Close();

                            foreach (Window win in Application.Current.Windows.OfType<Window>())
                            {
                                win.Close();
                            }

                        }
                        else
                        {
                            // burada şuanki kullanıcının maili ni girilen mail texboxıyla karşılaştıracağız.
                            if (suankiKullanici.FirstOrDefault().email == txb_Email.Text)
                            {
                                suankiKullanici.FirstOrDefault().kadi = txbKadi.Text;
                                suankiKullanici.FirstOrDefault().sifre = txb_Sifre.Password;
                                suankiKullanici.FirstOrDefault().adsoyad = txbAdSoyad.Text;
                                suankiKullanici.FirstOrDefault().email = txb_Email.Text;
                                suankiKullanici.FirstOrDefault().g_soru = cmb_Guvenlik.Text;
                                suankiKullanici.FirstOrDefault().g_cevabı = txbCevap.Text;
                                suankiKullanici.FirstOrDefault().telefon = txbTelefon.Text;

                                if (a.FileName != "")
                                {
                                    File.Copy(a.FileName, AppDomain.CurrentDomain.BaseDirectory + @"img\" + resimAdi);
                                    suankiKullanici.FirstOrDefault().fotograf = @"img\" + resimAdi;
                                }

                                ent.SaveChanges();

                                MessageBox.Show("Kullanıcı Başarıyla Güncellendi, Program Kapatılıyor, Tekrar Giriş Yapınız.");

                                //Window win2 = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "Window Name");
                                //win2.Close();

                                foreach (Window win in Application.Current.Windows.OfType<Window>())
                                {
                                    win.Close();
                                }

                            }
                            else
                            {
                                MessageBox.Show("bu maille bir kullanıcı zaten kayıtlı başka bir tane deneyin...");
                                return;
                            }
                            
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            txtveri.Visibility = System.Windows.Visibility.Hidden;

            Kullanicilar kl = new Kullanicilar();
            var suankiKullanici = from a in ent.Kullanicilars
                                  where a.kadi == txtveri.Text
                                  select a;

            txbKadi.Text = suankiKullanici.FirstOrDefault().kadi;
            txbAdSoyad.Text = suankiKullanici.FirstOrDefault().adsoyad;
            txb_Email.Text = suankiKullanici.FirstOrDefault().email;
            cmb_Guvenlik.Text = suankiKullanici.FirstOrDefault().g_soru;
            txbCevap.Text =  suankiKullanici.FirstOrDefault().g_cevabı;
            txbTelefon.Text = suankiKullanici.FirstOrDefault().telefon;

            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + suankiKullanici.FirstOrDefault().fotograf);
            img.EndInit();
            Resim.Source = img;
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


    }
}
