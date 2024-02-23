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
  
    public partial class FrmProdaja : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public FrmProdaja()
        {
            InitializeComponent();
            try
            {
                konekcija.Open();

                //ArtikalID
                string vratiArtikalID = @"select ArtikalID, NazivArtikla as 'Artikal' from Artikal";
                DataTable dtArtikalID = new DataTable();

                SqlDataAdapter daArtikalID = new SqlDataAdapter(vratiArtikalID, konekcija);
                daArtikalID.Fill(dtArtikalID);
                cbArtikalID.ItemsSource = dtArtikalID.DefaultView;

                //ReceptID
                string vratiReceptID= @"select ReceptID, ReceptID from Recept"; 
                DataTable dtRecept = new DataTable();

                SqlDataAdapter daRecept = new SqlDataAdapter(vratiReceptID, konekcija);
                daRecept.Fill(dtRecept);
                cbReceptID.ItemsSource = dtRecept.DefaultView;

                //ZaposleniID
                string vratiZaposleniID = @"select ZaposleniID, Ime+ ' ' + Prezime as 'Zaposleni' from Zaposleni";
                DataTable dtZaposleni = new DataTable();

                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposleniID, konekcija);
                daZaposleni.Fill(dtZaposleni);
                cbZaposleniID.ItemsSource = dtZaposleni.DefaultView;

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

            cbArtikalID.Focus();

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj != true)
                {
                    DateTime date = (DateTime)dpDatumProdaje.SelectedDate;
                    string datum = date.ToString("yyyy-MM-dd");
                    string insert = @"insert into Prodaja(ArtikalID, ReceptID, ZaposleniID, DatumProdaje)
                               values('" + cbArtikalID.SelectedValue + "','" + cbReceptID.SelectedValue + "','" + cbZaposleniID.SelectedValue + "','" + datum + "');";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocnired = null;
                }
                else
                {
                    DateTime date = (DateTime)dpDatumProdaje.SelectedDate;
                    string datum = date.ToString("yyyy-MM-dd");
                    DataRowView red = MainWindow.pomocnired;
                    string update = @"Update Prodaja
                    set ArtikalID='" + cbArtikalID.SelectedValue + "',ReceptID='" + cbReceptID.SelectedValue + "',ZaposleniID='" 
                    + cbZaposleniID.SelectedValue + "',DatumProdaje='"  + datum +
                    "' Where ProdajaID=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(update, konekcija);
                    komanda.ExecuteNonQuery();

                }
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
