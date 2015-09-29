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


namespace Antspace
{
    /// <summary>
    /// Interaction logic for AntWelcome.xaml
    /// </summary>
    public partial class AntWelcome : Page
    {
        public AntWelcome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            What2Do What2Do = new What2Do();
            this.NavigationService.Navigate(What2Do);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AntAbout AntAbout = new AntAbout();
            this.NavigationService.Navigate(AntAbout);

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            KolonieNeu KolonieNeu = new KolonieNeu();
            this.NavigationService.Navigate(KolonieNeu);
            
       
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AntSettings AntSettings = new AntSettings();
            this.NavigationService.Navigate(AntSettings);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ColonyChooser ColonyChooser = new ColonyChooser();
            this.NavigationService.Navigate(ColonyChooser);
        }

        


        //KolonieOne KolonieOne = new KolonieOne();
        //this.NavigationService.Navigate(KolonieOne);
        //this.NavigationService.Navigate(AntMenu);
        

    }

}
