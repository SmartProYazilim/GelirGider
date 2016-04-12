using GeliGider_WPF.DB;
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
    /// Interaction logic for SifreGuncelle.xaml
    /// </summary>
    public partial class SifreGuncelle : Window
    {
        public SifreGuncelle()
        {
            InitializeComponent();
        }
        HesapProEntities1 ent = new HesapProEntities1();
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (pb_Sifre.Password != "" && pb_SifreOnay.Password!="")
            {
                if (pb_Sifre.Password == pb_SifreOnay.Password)
                {
                    Kullanicilar kl = new Kullanicilar();
                    var suankiKullanici = from a in ent.Kullanicilars
                                          where a.email == txtVeri.Text
                                          select a;
                    suankiKullanici.FirstOrDefault().sifre = pb_Sifre.Password;
                    ent.SaveChanges();
                    MessageBox.Show("Şifreniz başarı ile güncellenmiştir.");
                }
                else
                {
                    MessageBox.Show("Şifreler uyuşmuyor. Lütfen tekrar deneyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtVeri.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
