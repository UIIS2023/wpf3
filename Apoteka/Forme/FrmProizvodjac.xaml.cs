using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace Apoteka.Forme
{
    /// <summary>
    /// Interaction logic for FrmProizvodjac.xaml
    /// </summary>
    public partial class FrmProizvodjac : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public FrmProizvodjac()
        {
            InitializeComponent(); 
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj != true)
                {  
                    string insert = @"insert into Proizvodjač (NazivProizvodjača,AdresaProizvodjača,DržavaPorekla)
                               values('" + txtNazivProizvodjaca.Text + "','" + txtAdresaProizvodjaca.Text + "','" 
                               + txtDržavaPorekla.Text + "');";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocnired = null;
                }
                else
                {
                    DataRowView red = MainWindow.pomocnired;
                    string update = @"Update Proizvodjač
                    set NazivProizvodjača='" + txtNazivProizvodjaca.Text + "',AdresaProizvodjača='" + txtAdresaProizvodjaca.Text +
                    "',DržavaPorekla='" + txtDržavaPorekla.Text + "' Where ProizvodjačID=" + red["ID"]; //pitaj Viktora sta je ovo na kraju
                    SqlCommand cmd = new SqlCommand(update, konekcija); //
                    cmd.ExecuteNonQuery();///////////////////////////////////////////////////
                }
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos neke od vrednosti nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
