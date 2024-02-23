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
using static System.Net.Mime.MediaTypeNames;

namespace Apoteka.Forme
{
    /// <summary>
    /// Interaction logic for FrmZaposleni.xaml
    /// </summary>
    public partial class FrmZaposleni : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public FrmZaposleni()
        {
            InitializeComponent();
            txtIme.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj != true)
                {
                   
                    string insert = @"insert into Zaposleni (Ime, Prezime,JMBG,LBO)
                               values('" + txtIme.Text + "','" + txtPrezime.Text + "','" + txtJMBG.Text +
                                   "','" + txtLBO.Text + "');";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocnired = null;
                }
                else
                {
                    DataRowView red = MainWindow.pomocnired;
                    string update = @"Update Zaposleni
                    set Ime='" + txtIme.Text + "',Prezime='" + txtPrezime.Text + "',JMBG='" + txtJMBG.Text + "',LBO='" + txtLBO.Text +
                    "' Where ZaposleniID=" + red["ID"]; //pitaj Viktora sta je ovo na kraju
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

