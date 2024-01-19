using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Interfejs.Pages
{
    /// <summary>
    /// Interaction logic for FridgeComponents.xaml
    /// </summary>
    public partial class FridgeComponents : Page
    {
        private ObservableCollection<Skladniki> listaSkladnikow = new ObservableCollection<Skladniki>();
        private string sciezkaPliku = "plik.txt";

        public class Skladniki
        {
            public string Nazwa { get; set; }
            public int Ilosc { get; set; }
            public string Jednostka { get; set; }

            public Skladniki(string nazwa, int ilosc, string jednostka)
            {
                Nazwa = nazwa;
                Ilosc = ilosc;
                Jednostka = jednostka;
            }
        }

        public FridgeComponents()
        {
            InitializeComponent();
            if (!File.Exists(sciezkaPliku))
            {
                File.Create(sciezkaPliku).Close(); // Utwórz i zamknij plik, aby zwolnić zasoby.
            }
            else
            {
                var skladnikiZPliku = WczytajSkladnikiZPliku(sciezkaPliku);
                foreach (var skladnik in skladnikiZPliku)
                {
                    listaSkladnikow.Add(skladnik);
                }
            }
            LodówkaDataGrid.ItemsSource = listaSkladnikow;
            LodówkaDataGrid.CellEditEnding += LodówkaDataGrid_CellEditEnding;
        }

        private ObservableCollection<Skladniki> WczytajSkladnikiZPliku(string sciezkaPliku)
        {
            var skladniki = new ObservableCollection<Skladniki>();
            var linie = File.ReadAllLines(sciezkaPliku);
            foreach (var linia in linie)
            {
                var elementy = linia.Split(',');
                if (elementy.Length >= 3)
                {
                    skladniki.Add(new Skladniki(elementy[0], int.Parse(elementy[1]), elementy[2]));
                }
            }
            return skladniki;
        }

        private void ZapiszSkladnikiDoPliku(ObservableCollection<Skladniki> skladniki, string sciezkaPliku)
        {
            var linie = skladniki.Select(s => $"{s.Nazwa},{s.Ilosc},{s.Jednostka}");
            File.WriteAllLines(sciezkaPliku, linie);
        }

        private void LodówkaDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ZapiszSkladnikiDoPliku(listaSkladnikow, sciezkaPliku);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nowySkladnik = new Skladniki("", 0, ""); // Ustaw domyślne wartości dla nowego składnika.
            listaSkladnikow.Add(nowySkladnik); // Dodaj nowy składnik do kolekcji.
            LodówkaDataGrid.SelectedItem = nowySkladnik; // Opcjonalnie: zaznacz nowy wiersz.
            LodówkaDataGrid.ScrollIntoView(nowySkladnik); // Opcjonalnie: przewiń do nowego wiersza.
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            var selectedSkladnik = LodówkaDataGrid.SelectedItem as Skladniki;
            if (selectedSkladnik != null)
            {
                listaSkladnikow.Remove(selectedSkladnik);
                ZapiszSkladnikiDoPliku(listaSkladnikow, sciezkaPliku); // Opcjonalnie: od razu zapisz zmiany do pliku.
            }
        }

        }
}