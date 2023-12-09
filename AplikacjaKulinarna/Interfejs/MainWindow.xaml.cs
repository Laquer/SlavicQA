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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Interfejs.Pages;
using LogikaProgramu;

namespace Interfejs
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IInterfejs interfejs;

        public MainWindow()

        {
            InitializeComponent();
            Main.Content = new MenuPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new RecipeList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new FridgeComponents();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new MenuPage();
        }
    }
}
