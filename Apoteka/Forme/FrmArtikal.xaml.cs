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
    public partial class FrmArtikal : Window
    {
        SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public FrmArtikal()
        {
            InitializeComponent();
            try
            {
                konekcija.Open();

                //Tip artikla-oblik
                string vratiTipArtikla = @"select TipArtiklaID, NazivTipa as 'Oblik' from TipArtikla";
                DataTable dtTipArtikla = new DataTable();

                SqlDataAdapter daTipArtikla = new SqlDataAdapter(vratiTipArtikla, konekcija);
                daTipArtikla.Fill(dtTipArtikla);
                cbTipArtikla.ItemsSource = dtTipArtikla.DefaultView;

                //Proizvodjac
                string vratiProizvodjaca = @"select ProizvodjačID, NazivProizvodjača from Proizvodjač";
                DataTable dtProizvodjac = new DataTable();

                SqlDataAdapter daProizvodjac = new SqlDataAdapter(vratiProizvodjaca, konekcija);
                daProizvodjac.Fill(dtProizvodjac);
                cbProizvodjac.ItemsSource = dtProizvodjac.DefaultView;
                
                //Dobavljac
                string vratiDobavljaca = @"select DobavljačID, NazivDobavljača from Dobavljač";
                DataTable dtDobavljac = new DataTable();

                SqlDataAdapter daDobavljac = new SqlDataAdapter(vratiDobavljaca, konekcija);
                daDobavljac.Fill(dtDobavljac);
                cbDobavljac.ItemsSource = dtDobavljac.DefaultView;

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

            txtNazivArtikla.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj != true)   
                {

                    string insert = @"insert into Artikal(NazivArtikla, TipArtiklaID, ProizvodjačID, DobavljačID, Stanje, Cena, PDV)
                               values('" + txtNazivArtikla.Text + "','" + cbTipArtikla.SelectedValue + "','"
                               + cbProizvodjac.SelectedValue + "','" + cbDobavljac.SelectedValue + "','" + txtStanje.Text 
                               + "','" + txtCena.Text + "','" + txtPDV.Text + "');";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocnired = null;
                }
                else
                {
                    DataRowView red = MainWindow.pomocnired;
                    string update = @"Update Artikal
                    set  NazivArtikla='" + txtNazivArtikla.Text + "',TipArtiklaID='" + cbTipArtikla.SelectedValue +
                    "',ProizvodjačID='" + cbProizvodjac.SelectedValue + "',DobavljačID='" + cbDobavljac.SelectedValue + "',Stanje='"
                    + txtStanje.Text + "',Cena='" + txtCena.Text + "',PDV='" + txtPDV.Text +
                    "' Where ArtikalID=" + red["ID"];

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
