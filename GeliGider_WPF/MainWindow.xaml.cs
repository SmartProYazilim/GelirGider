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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GeliGider_WPF.DB;

namespace GeliGider_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        HesapProEntities1 ent = new HesapProEntities1();
        private void btn_YeniUye_Click(object sender, RoutedEventArgs e)
        {
            YeniUye yeniUye = new YeniUye();
            yeniUye.Show();


        }

        private void btn_SifremiUnuttum_Click(object sender, RoutedEventArgs e)
        {
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.Show();
        }


        public string kadi;
        private void btn_Giris_Click(object sender, RoutedEventArgs e)
        {
            if (tb_KullaniciAdi.Text != "" && tb_Sifre.Password != "")
            {
                Kullanicilar kl = new Kullanicilar();
                kl.kadi = tb_KullaniciAdi.Text;
                kl.sifre = tb_Sifre.Password;

                var kullanici = (from c in ent.Kullanicilars
                                where c.kadi == tb_KullaniciAdi.Text && c.sifre == tb_Sifre.Password
                                select c).ToList();
                
                if (kullanici.Count > 0)
                {
                    MessageBox.Show("Giriş Başarılı Hoşgeldiniz : " + tb_KullaniciAdi.Text);
                    kadi = tb_KullaniciAdi.Text;
                    this.Hide();

                    Menu acilanForm = new Menu();
                    acilanForm.txtveri.Text = this.kadi; 
                    acilanForm.Show();
                }
                else
                {
                    MessageBox.Show("Böyle bir kullanıcı bulunmuyor !");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Tüm alanları doldurmalısınız !!!");
            }
            
        }
    }
}
