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
 
    public partial class FrmRecept : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public FrmRecept()
        {
            InitializeComponent();

            try
            {
                konekcija.Open();

                string vratiKupca = @"select KupacID, ImeKupca + ' ' + PrezimeKupca as 'Pacijent' from Kupac ";
                DataTable dtKupac = new DataTable();

                SqlDataAdapter daKupac = new SqlDataAdapter(vratiKupca, konekcija);
                daKupac.Fill(dtKupac);
                cbKupacID.ItemsSource = dtKupac.DefaultView;
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
            dpDatumIzdavanjaRecepta.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj != true)
                {
                    DateTime date = (DateTime)dpDatumIzdavanjaRecepta.SelectedDate;
                    string datum = date.ToString("yyyy-MM-dd");
                    string insert = @"insert into Recept(DatumIzdavanja, KupacID)
                               values('" + datum + "','" + cbKupacID.SelectedValue + "');";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocnired = null;
                }
                else
                {
                    DataRowView red = MainWindow.pomocnired;
                    DateTime date = (DateTime)dpDatumIzdavanjaRecepta.SelectedDate;
                    string datum = date.ToString("yyyy-MM-dd");
                    string update = @"Update Recept
                                    set DatumIzdavanja = '" + datum + "',KupacID='" + cbKupacID.SelectedValue +
                                    "' Where ReceptID=" + red["ID"];
                    SqlCommand komanda = new SqlCommand(update, konekcija);
                    komanda.ExecuteNonQuery();
                }
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti vrednosti nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
