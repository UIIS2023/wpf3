using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Apoteka.Forme;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Controls.Primitives;
using System;

namespace Apoteka
{
    
    public partial class MainWindow : Window
    {
        public static string ucitanaTabela;
        public static bool azuriraj;
        public static DataRowView pomocnired;

        static SqlConnection konekcija = Konekcija.KreirajKonekciju();

        #region Select upiti
        static string artikalSelect = @"select ArtikalID as ID, NazivArtikla as 'Naziv', NazivTipa as 'Oblik', NazivProizvodjača as 'Proizvodjač', NazivDobavljača as 'Dobavljač',Stanje 'Na stanju', Cena, PDV 
             from Artikal join TipArtikla on Artikal.TipArtiklaID=TipArtikla.TipArtiklaID 
			 join Proizvodjač on Artikal.ProizvodjačID=Proizvodjač.ProizvodjačID
			 join Dobavljač on Artikal.DobavljačID= Dobavljač.DobavljačID";
        static string proizvodjaciSelect = @"select ProizvodjačID as ID, NazivProizvodjača, AdresaProizvodjača,DržavaPorekla from Proizvodjač";
        static string dobavljaciSelect = @"select DobavljačID as ID, NazivDobavljača, AdresaDobavljača, MatičniBroj, PIB, ŽiroRačun from Dobavljač";
        static string tipArtiklaSelect = @"select TipArtiklaID as ID, NazivTipa from TipArtikla";
        static string zaposleniSelect = @"select ZaposleniID as ID, Ime, Prezime, JMBG, LBO from Zaposleni";
        static string kupciSelect = @"select KupacID as ID, BrojZdravstveneKnjižice, ImeKupca, PrezimeKupca from Kupac";
        static string receptSelect = @"select ReceptID as ID, DatumIzdavanja, ImeKupca+' '+PrezimeKupca as 'Pacijent'
             from Recept join Kupac on Recept.KupacID=Kupac.KupacID";
        static string racunSelect = @"select RačunID as ID, NazivArtikla as 'Artikal', IznosRačuna, VremeIzdavanjaRačuna
             from Račun join Prodaja on Račun.ProdajaID= Prodaja.ProdajaID join Artikal on Prodaja.ArtikalID=Artikal.ArtikalID";
        static string prodajaSelect = @"select ProdajaID as ID, NazivArtikla as 'Artikal', ReceptID, Ime+' '+Prezime as 'Zaposleni', DatumProdaje
             from Prodaja join Artikal on Prodaja.ArtikalID=Artikal.ArtikalID
		     join Zaposleni on Prodaja.ZaposleniID= Zaposleni.ZaposleniID";
        #endregion

        #region Select sa Uslovom
        string selectUslovArtikal = @"select* from Artikal where ArtikalID=";
        string selectUslovProizvodjaci = @"select* from Proizvodjač where  ProizvodjačID=";
        string selectUslovDobavljaci = @"select* from Dobavljač where  DobavljačID=";
        string selectUslovTipArtikla = @"select* from TipArtikla where  TipArtiklaID=";
        string selectUslovZaposleni = @"select* from Zaposleni where  ZaposleniID=";
        string selectUslovKupci = @"select* from Kupac where KupacID=";
        string selectUslovRecept = @"select* from Recept where  ReceptID=";
        string selectUslovRacun = @"select* from Račun where  RačunID=";
        string selectUslovProdaja = @"select* from Prodaja where  ProdajaID=";
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            UcitajPodatke(dataGridCentralni, artikalSelect);
        }

        public static void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                grid.ItemsSource = dt.DefaultView;
                ucitanaTabela = selectUpit;
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspešno učitani podaci!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        private void btnArtikal_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, artikalSelect);
            
        }

        private void btnProizvodjaci_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, proizvodjaciSelect);

        }

        private void btnDobavljaci_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, dobavljaciSelect);

        }

        private void btnTipArtikla_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, tipArtiklaSelect);

        }

        private void btnZaposleni_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, zaposleniSelect);

        }

        private void btnKupci_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, kupciSelect);

        }

        private void btnRecept_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, receptSelect);

        }

        private void btnRacun_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, racunSelect);

        }

        private void btnProdaja_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, prodajaSelect);

        }


        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(artikalSelect))
            {
                prozor = new FrmArtikal();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, artikalSelect);
            }
            else if (ucitanaTabela.Equals(dobavljaciSelect))
            {
                prozor = new FrmDobavljac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, dobavljaciSelect);
            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                prozor = new FrmKupac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, kupciSelect);
            }
            else if (ucitanaTabela.Equals(prodajaSelect))
            {
                prozor = new FrmProdaja();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, prodajaSelect);
            }
            else if (ucitanaTabela.Equals(proizvodjaciSelect))
            {
                prozor = new FrmProizvodjac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, proizvodjaciSelect);
            }
            else if (ucitanaTabela.Equals(racunSelect))
            {
                prozor = new FrmRacun();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, racunSelect);
            }
            else if (ucitanaTabela.Equals(receptSelect))
            {
                prozor = new FrmRecept();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, receptSelect);
            }
            else if (ucitanaTabela.Equals(tipArtiklaSelect))
            {
                prozor = new FrmTipArtikla();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, tipArtiklaSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                prozor = new FrmZaposleni();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, zaposleniSelect);
            }
           

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(artikalSelect))
            {
                popuniFormu(dataGridCentralni, selectUslovArtikal);
                UcitajPodatke(dataGridCentralni, artikalSelect);
            }
            else if (ucitanaTabela.Equals(dobavljaciSelect))
            {
                popuniFormu(dataGridCentralni, selectUslovDobavljaci);
                UcitajPodatke(dataGridCentralni, dobavljaciSelect);
            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                popuniFormu(dataGridCentralni, selectUslovKupci);
                UcitajPodatke(dataGridCentralni, kupciSelect);
            }
            else if (ucitanaTabela.Equals(prodajaSelect))
            {
                popuniFormu(dataGridCentralni, selectUslovProdaja);
                UcitajPodatke(dataGridCentralni, prodajaSelect);
            }
            else if (ucitanaTabela.Equals(proizvodjaciSelect))
            {
                popuniFormu(dataGridCentralni, selectUslovProizvodjaci);
                UcitajPodatke(dataGridCentralni, proizvodjaciSelect);
            }
            else if (ucitanaTabela.Equals(racunSelect))
            {
                popuniFormu(dataGridCentralni, selectUslovRacun);
                UcitajPodatke(dataGridCentralni, racunSelect);
            }
            else if (ucitanaTabela.Equals(receptSelect))
            {
                popuniFormu(dataGridCentralni, selectUslovRecept);
                UcitajPodatke(dataGridCentralni, receptSelect);
            }
            else if (ucitanaTabela.Equals(tipArtiklaSelect))
            {
                popuniFormu(dataGridCentralni, selectUslovTipArtikla);
                UcitajPodatke(dataGridCentralni, tipArtiklaSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                popuniFormu(dataGridCentralni, selectUslovZaposleni);
                UcitajPodatke(dataGridCentralni, zaposleniSelect);
            }
        }

        static void popuniFormu(DataGrid grid, string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                pomocnired = red;
                string upit = selectUslov + red["ID"]; 
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    if (ucitanaTabela.Equals(artikalSelect))
                    {
                        FrmArtikal prozorArtikal = new FrmArtikal();
                        prozorArtikal.txtNazivArtikla.Text = citac["NazivArtikla"].ToString();
                        prozorArtikal.cbTipArtikla.SelectedValue = citac["TipArtiklaID"];
                        prozorArtikal.cbProizvodjac.SelectedValue = citac["ProizvodjačID"];
                        prozorArtikal.cbDobavljac.SelectedValue = citac["DobavljačID"];
                        prozorArtikal.txtStanje.Text = citac["Stanje"].ToString();
                        prozorArtikal.txtCena.Text = citac["Cena"].ToString();
                        prozorArtikal.txtPDV.Text = citac["PDV"].ToString();
                        prozorArtikal.ShowDialog();


                    }
                    else if (ucitanaTabela.Equals(dobavljaciSelect))
                    {
                        FrmDobavljac prozorDobavljac = new FrmDobavljac();
                        prozorDobavljac.txtNazivDobavljaca.Text = citac["NazivDobavljača"].ToString();
                        prozorDobavljac.txtAdresaDobavljaca.Text = citac["AdresaDobavljača"].ToString();
                        prozorDobavljac.txtMaticniBroj.Text = citac["MatičniBroj"].ToString();
                        prozorDobavljac.txtPIB.Text = citac["PIB"].ToString();
                        prozorDobavljac.txtZiroRacun.Text = citac["ŽiroRačun"].ToString();
                        prozorDobavljac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kupciSelect))
                    {
                        FrmKupac prozorKupac = new FrmKupac();
                        prozorKupac.txtBrojZdravstveneKnjizice.Text = citac["BrojZdravstveneKnjižice"].ToString();
                        prozorKupac.txtImeKupca.Text = citac["ImeKupca"].ToString();
                        prozorKupac.txtPrezimeKupca.Text = citac["PrezimeKupca"].ToString();
                        prozorKupac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(prodajaSelect))
                    {
                        FrmProdaja prozorProdaja = new FrmProdaja();
                        prozorProdaja.cbArtikalID.SelectedValue = citac["ArtikalID"];
                        prozorProdaja.cbReceptID.SelectedValue = citac["ReceptID"];
                        prozorProdaja.cbZaposleniID.SelectedValue = citac["ZaposleniID"];
                        prozorProdaja.dpDatumProdaje.SelectedDate = (DateTime)citac["DatumProdaje"];
                        prozorProdaja.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(proizvodjaciSelect))
                    {
                        FrmProizvodjac prozorProizvodjac = new FrmProizvodjac();
                        prozorProizvodjac.txtNazivProizvodjaca.Text = citac["NazivProizvodjača"].ToString();
                        prozorProizvodjac.txtAdresaProizvodjaca.Text = citac["AdresaProizvodjača"].ToString();
                        prozorProizvodjac.txtDržavaPorekla.Text = citac["DržavaPorekla"].ToString();
                        prozorProizvodjac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(racunSelect))
                    {
                        FrmRacun prozorRacun = new FrmRacun();
                        prozorRacun.cbProdajaID.SelectedValue = citac["ProdajaID"];
                        prozorRacun.txtIznosRacuna.Text = citac["IznosRačuna"].ToString();
                        prozorRacun.txtVremeIzdavanjaRacuna.Text = citac["VremeIzdavanjaRačuna"].ToString();
                        prozorRacun.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(receptSelect))
                    {
                        FrmRecept prozorRecept = new FrmRecept();
                        prozorRecept.dpDatumIzdavanjaRecepta.SelectedDate = (DateTime)citac["DatumIzdavanja"];
                        prozorRecept.cbKupacID.SelectedValue = citac["KupacID"];
                        prozorRecept.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(tipArtiklaSelect))
                    {
                        FrmTipArtikla prozorTipArtikla = new FrmTipArtikla();
                        prozorTipArtikla.txtNazivTipa.Text = citac["NazivTipa"].ToString();
                        prozorTipArtikla.ShowDialog();
                        
                    }
                    else if (ucitanaTabela.Equals(zaposleniSelect))
                    {
                        FrmZaposleni prozorZaposleni = new FrmZaposleni();
                        prozorZaposleni.txtIme.Text = citac["Ime"].ToString();
                        prozorZaposleni.txtPrezime.Text = citac["Prezime"].ToString();
                        prozorZaposleni.txtJMBG.Text = citac["JMBG"].ToString();
                        prozorZaposleni.txtLBO.Text = citac["LBO"].ToString();
                        prozorZaposleni.ShowDialog();
                        
                    }
                }

            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Niste selektovali red!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(artikalSelect))
            {
                obrisiZapis(deleteArtikal);
                UcitajPodatke(dataGridCentralni, artikalSelect);
            }
            else if (ucitanaTabela.Equals(dobavljaciSelect))
            {
                obrisiZapis(deleteDobavljaci);
                UcitajPodatke(dataGridCentralni, dobavljaciSelect);
            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                obrisiZapis(deleteKupci);
                UcitajPodatke(dataGridCentralni, kupciSelect);
            }
            else if (ucitanaTabela.Equals(prodajaSelect))
            {
                obrisiZapis(deleteProdaja);
                UcitajPodatke(dataGridCentralni, prodajaSelect);
            }
            else if (ucitanaTabela.Equals(proizvodjaciSelect))
            {
                obrisiZapis(deleteProizvodjaci);
                UcitajPodatke(dataGridCentralni, proizvodjaciSelect);
            }
            else if (ucitanaTabela.Equals(racunSelect))
            {
                obrisiZapis(deleteRacun);
                UcitajPodatke(dataGridCentralni, racunSelect);
            }
            else if (ucitanaTabela.Equals(receptSelect))
            {
                obrisiZapis(deleteRecept);
                UcitajPodatke(dataGridCentralni, receptSelect);
            }
            else if (ucitanaTabela.Equals(tipArtiklaSelect))
            {
                obrisiZapis(deleteTipArtikla);
                UcitajPodatke(dataGridCentralni, tipArtiklaSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                obrisiZapis(deleteZaposleni);
                UcitajPodatke(dataGridCentralni, zaposleniSelect);
            }
        }

        private void obrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                pomocnired = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = pomocnired["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Odabrani podaci se koriste u drugim tabelama!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        #region Delete upiti
        string deleteArtikal = @"delete from Artikal where ArtikalID=";
        string deleteProizvodjaci = @"delete from Proizvodjač where  ProizvodjačID=";
        string deleteDobavljaci = @"delete from Dobavljač where  DobavljačID=";
        string deleteTipArtikla = @"delete from TipArtikla where  TipArtiklaID=";
        string deleteZaposleni = @"delete from Zaposleni where  ZaposleniID=";
        string deleteKupci = @"delete from Kupac where KupacID=";
        string deleteRecept = @"delete from Recept where  ReceptID=";
        string deleteRacun = @"delete from Račun where  RačunID=";
        string deleteProdaja = @"delete from Prodaja where  ProdajaID=";
        #endregion
    }
}