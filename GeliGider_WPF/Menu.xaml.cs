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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        public MainWindow formMain;
        public string kadi;
        private void btn_GelirEkle_Click(object sender, RoutedEventArgs e)
        {
            GelirEkle acilanForm = new GelirEkle();
            acilanForm.kadi = this.txtveri.Text;
            acilanForm.ShowDialog(); 
        }

        private void btn_GiderEkle_Click(object sender, RoutedEventArgs e)
        {
            GiderEkle acilanForm = new GiderEkle();
            acilanForm.kadi = this.txtveri.Text;
            acilanForm.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BilgilerimiGuncelle acilanForm = new BilgilerimiGuncelle();
            acilanForm.txtveri.Text = this.txtveri.Text;
            acilanForm.ShowDialog();
        }

        private void btn_GelirGor_Click(object sender, RoutedEventArgs e)
        {
            gelirGiderGor acilanForm = new gelirGiderGor();
            acilanForm.baslik = "Gelirleri Göster";
            acilanForm.deger = "Gelir";
            acilanForm.kullaniciAdi = this.txtveri.Text;
            acilanForm.ShowDialog();
        }
        private void btn_GiderGor_Click(object sender, RoutedEventArgs e)
        {
            gelirGiderGor acilanForm = new gelirGiderGor();
            acilanForm.baslik = "Giderleri Göster";
            acilanForm.deger = "Gider";
            acilanForm.kullaniciAdi = this.txtveri.Text;
            acilanForm.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtveri.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
