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
    /// Interaction logic for GiderEkle.xaml
    /// </summary>
    public partial class GiderEkle : Window
    {
        public GiderEkle()
        {
            InitializeComponent();
        }

        HesapProEntities1 ent = new HesapProEntities1();
        public string kadi;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //ileri tarihi seçtirmeyi engellemek gerekiyor.
            if (txb_Miktar.Text != "" && txbAciklama.Text != "" && cmb_Kategori.Text != "" && dtTarih.Text != "")
            {

                Kullanicilar kl = new Kullanicilar();
                var verileriAl = (from c in ent.Kullanicilars
                                  where c.kadi == kadi
                                  select c).FirstOrDefault();

                Random rnd = new Random();
                Giderler gl = new Giderler();
                gl.ID = rnd.Next(1, 1000000);
                gl.KullaniciID = verileriAl.ID;
                gl.GidenPara = Convert.ToDecimal(txb_Miktar.Text);
                gl.GiderAciklama = txbAciklama.Text;
                gl.GiderTarihi = dtTarih.SelectedDate.Value;
                gl.GiderTipiID = cmb_Kategori.SelectedIndex + 1;
                ent.Giderlers.Add(gl);
                ent.SaveChanges();

                MessageBox.Show("Gider başarıyla eklendi.");
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurmalısınız !!!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var cmbTip = (from u in ent.GiderTipleris
                          orderby u.ID ascending
                          select u.GiderTipleri1).ToList();

            var cmbTipID = (from u in ent.GiderTipleris
                            select new
                            {
                                GiderID = u.ID
                            }).ToList();

            cmb_Kategori.ItemsSource = cmbTip;
        }
    }
}
