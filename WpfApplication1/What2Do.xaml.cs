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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ColonyChooser.xaml
    /// </summary>
    public partial class What2Do : Page
    {
        public What2Do()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KolonieNeu KolonieNeu = new KolonieNeu();
            this.NavigationService.Navigate(KolonieNeu);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ColonyChooser ColonyChooser = new ColonyChooser();
            this.NavigationService.Navigate(ColonyChooser);
        }
    }
}
