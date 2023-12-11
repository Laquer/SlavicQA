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
using PolaczenieZbaza.Models;
using PolaczenieZbaza;

namespace Interfejs.Pages
{
    /// <summary>
    /// Interaction logic for FridgeComponents.xaml
    /// </summary>
    public partial class FridgeComponents : Page
    {
        public FridgeComponents()
        {
            InitializeComponent();

            LodówkaAppContext context = new LodówkaAppContext();
            LodówkaDataGrid.ItemsSource = context.Lodowkis.ToList();   



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
