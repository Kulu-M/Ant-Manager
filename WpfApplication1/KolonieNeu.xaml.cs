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
using Xceed.Wpf.DataGrid;

namespace Antspace
{
    /// <summary>
    /// Interaction logic for KolonieNeu.xaml
    /// </summary>
    public partial class KolonieNeu : Page
    {
        public KolonieNeu()
        {
            InitializeComponent();

            


        }

        public class Colony {

            public string Cname, Cnote;
            public object Cart, Cgdatummonth, Cgdatumyear, Agynen, Aworker, Asoldiers;
            

        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_ClickSave(object sender, RoutedEventArgs e)
        {

            //WIP
            string CartBox = ArtBox.Get//...
            string Comboselectedmonth = DateBoxMonth.SelectedItem.ToString();
            string Comboselectedyear = DateBoxYear.SelectedItem.ToString();
            string Agynentxt = GyneBox.Text.ToString();
            string Aworkertxt = WorkerBox.Text.ToString();
            string Asoldiertxt = SoldierBox.Text.ToString();



            Colony ColonyOne = new Colony();
            ColonyOne.Cname = NameBox.Text;
            ColonyOne.Cart = CartBox;
            ColonyOne.Cnote = NoteBox.Text;

            ColonyOne.Cgdatummonth = Comboselectedmonth;
            ColonyOne.Cgdatumyear = Comboselectedyear;


            ColonyOne.Agynen = Agynentxt;
            ColonyOne.Aworker = Aworkertxt;
            ColonyOne.Asoldiers = Asoldiertxt;





            //nn to check if folder exists, "System.IO.Directory.CreateDirectory" does that for us
            string mydocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            System.IO.Directory.CreateDirectory(mydocs + "/AntManager");

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Colony));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/AntManager/AntManagerSaveFile.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, ColonyOne);
            file.Close();
        }
    }
}
