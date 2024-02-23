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

namespace Apoteka.Forme
{
    /// <summary>
    /// Interaction logic for FrmDobavljac.xaml
    /// </summary>
    public partial class FrmDobavljac : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public FrmDobavljac()
        {
            InitializeComponent();
            txtNazivDobavljaca.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj != true)
                {

                    string insert = @"insert into Dobavljač(NazivDobavljača,AdresaDobavljača,MatičniBroj,PIB,ŽiroRačun)
                               values('" + txtNazivDobavljaca.Text + "','" + txtAdresaDobavljaca.Text + "','" + txtMaticniBroj.Text +
                                   "','" + txtPIB.Text + "','" + txtZiroRacun.Text + "');";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocnired = null;
                }
                else
                {
                    DataRowView red = MainWindow.pomocnired;
                    string update = @"Update Dobavljač
                    set NazivDobavljača='" + txtNazivDobavljaca.Text + "',AdresaDobavljača='" + txtAdresaDobavljaca.Text +
                    "',MatičniBroj='" + txtMaticniBroj.Text + "',PIB='" + txtPIB.Text + "',ŽiroRačun='" + txtZiroRacun.Text + 
                    "' Where DobavljačID=" + red["ID"]; //pitaj Viktora sta je ovo na kraju
                    SqlCommand cmd = new SqlCommand(update, konekcija); //
                    cmd.ExecuteNonQuery();///////////////////////////////////////////////////
                }
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos neke od vrednosti nije validan! OVO JE U DOB", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
