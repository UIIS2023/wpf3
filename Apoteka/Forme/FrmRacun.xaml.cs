using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Apoteka.Forme
{
    public partial class FrmRacun : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public FrmRacun()
        {
            InitializeComponent();
            try
            {
                konekcija.Open();

                //ProdajaID
                string vratiProdaju = @"select ProdajaID, ProdajaID from Prodaja "; //MOZDA BUDE PRAVILO PROBLEM
                DataTable dtProdajaID = new DataTable();
                SqlDataAdapter daProdajaID = new SqlDataAdapter(vratiProdaju, konekcija);
                daProdajaID.Fill(dtProdajaID);
                cbProdajaID.ItemsSource = dtProdajaID.DefaultView;

            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuće liste nisu popunjene!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

            cbProdajaID.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj != true)
                {

                    string insert = @"insert into Račun(ProdajaID, IznosRačuna, VremeIzdavanjaRačuna)
                               values('" + cbProdajaID.SelectedValue + "','" + txtIznosRacuna.Text + "','"
                               + txtVremeIzdavanjaRacuna.Text + "');";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocnired = null;
                }
                else
                {
                    DataRowView red = MainWindow.pomocnired;
                    string update = @"Update Račun 
                    set ProdajaID='" + cbProdajaID.SelectedValue + "',IznosRačuna='" + txtIznosRacuna.Text + "',VremeIzdavanjaRačuna='"
                   + txtVremeIzdavanjaRacuna.Text + 
                   "' Where RačunID=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(update, konekcija);
                    komanda.ExecuteNonQuery();

                }
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
