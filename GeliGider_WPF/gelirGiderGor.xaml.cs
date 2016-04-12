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
    /// Interaction logic for gelirGiderGor.xaml
    /// </summary>
    public partial class gelirGiderGor : Window
    {
        public gelirGiderGor()
        {
            InitializeComponent();
        }


        HesapProEntities1 ent = new HesapProEntities1();
        public string baslik, deger, kullaniciAdi;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = baslik + " - Kullanıcı : " + kullaniciAdi;

            Kullanicilar kl = new Kullanicilar();
            var verileriAl = (from c in ent.Kullanicilars
                              where c.kadi == kullaniciAdi
                              select c).ToList().FirstOrDefault();
            
            var kID = verileriAl.ID;

            if (deger == "Gelir")
            {
                if (verileriAl.Gelirlers.Count < 1)
                {
                    // gider çalışıyor aslında burası da çalışacak da başka bir sıkıntıdan dolayı bu form yükklenemiyor eci 
                    // Allah cezasını versin gelirlerin :D :D
                    // bu notda burda kalsın emi :D
                    // tamam :D

                    MessageBox.Show("Gelir kaydınız bulunmamaktadır.");
                    this.Close();
                }


                dataGrid.ItemsSource = "";

                var gelirleriGetir = (from g in ent.Gelirlers
                                      where g.KullaniciID == kID
                                      select new
                                      {
                                          Kullanici = g.Kullanicilar.adsoyad,
                                          GelirTipi = g.GelirTipleri.GelirTipi,
                                          GelenPara = g.GelenPara,
                                          GelirAciklama = g.GelirAciklama,
                                          GelirTarihi = g.GelirTarihi.Value
                                      }).ToList();

                dataGrid.ItemsSource = gelirleriGetir;
            }else
            {

                if (verileriAl.Giderlers.Count < 1)
                {
                    MessageBox.Show("Gider kaydınız bulunmamaktadır.");
                    this.Close();
                }

                dataGrid.ItemsSource = "";

                var giderleriGetir = (from g in ent.Giderlers
                                      where g.KullaniciID == kID
                                      select new
                                      {
                                          Kullanici = g.Kullanicilar.adsoyad,
                                          GiderTipi = g.GiderTipleri.GiderTipleri1,
                                          GidenPara = g.GidenPara,
                                          GiderAciklama = g.GiderAciklama,
                                          GiderTarihi = g.GiderTarihi.Value
                                      }).ToList();

                dataGrid.ItemsSource = giderleriGetir;
            }
        }
    }
}
