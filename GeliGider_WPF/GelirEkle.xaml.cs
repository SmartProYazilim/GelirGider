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
    /// Interaction logic for GelirEkle.xaml
    /// </summary>
    public partial class GelirEkle : Window
    {
        public GelirEkle()
        {
            InitializeComponent();
        }
        HesapProEntities1 ent = new HesapProEntities1();
        public string kadi;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var cmbTip = (from u in ent.GelirTipleris
                          orderby u.ID ascending
                          select u.GelirTipi).ToList();

            var cmbTipID = (from u in ent.GelirTipleris
                          select new
                          {
                              GelirID = u.ID
                          }).ToList();

            cmb_Kategori.ItemsSource = cmbTip;

        }

        private void cmb_Kategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show((cmb_Kategori.SelectedIndex + 1).ToString());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (txb_Miktar.Text != "" && txbAciklama.Text != "" && cmb_Kategori.Text != "" && dtTarih.Text!="")
            {
                Kullanicilar kl = new Kullanicilar();
               var verileriAl = (from c in ent.Kullanicilars
                                where c.kadi == kadi
                                select c).FirstOrDefault();
                
                    Random rnd = new Random();
                    Gelirler gl = new Gelirler();
                    gl.ID = rnd.Next(1, 1000000);
                gl.KullaniciID = verileriAl.ID;
                gl.GelenPara = Convert.ToDecimal(txb_Miktar.Text);
                    gl.GelirAciklama = txbAciklama.Text;
                    gl.GelirTarihi = dtTarih.SelectedDate.Value;
                    gl.GelirTipiID = cmb_Kategori.SelectedIndex + 1;
                    
                    ent.Gelirlers.Add(gl);
                    ent.SaveChanges();
                        MessageBox.Show("Gelir başarıyla eklendi.");
                    

                    
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurmalısınız !!!");
            }
        }
    }
}
