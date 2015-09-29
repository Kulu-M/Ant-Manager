using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for KolonieOne.xaml
    /// </summary>
    public partial class KolonieOne : Page
    {


        //VARIABLES
        int eierzahl = 0;
        int larvenzahl = 0;
        int puppenzahl = 0;
        int arbeiterzahl = 0;


        String larvenstr = "";
        String puppenstr = "";
        String arbeiterstr = "";


        DateTime wSavedDate;
        DateTime zSavedDate;
        DateTime pSavedDate;



        //ZEIT

        //Request System Date
        DateTime thisDay = DateTime.Today;

        //3 Variables for 1, 2 or 3 days ago.
        DateTime oneday = DateTime.Today.AddDays(-1);
        DateTime twodays = DateTime.Today.AddDays(-2);
        DateTime threedays = DateTime.Today.AddDays(-3);

        



        public KolonieOne()
        {
            InitializeComponent();


            LoadSettingsMethod();         
        }


        public void LoadSettingsMethod()
        {
            //Daten laden
            wSavedDate = Properties.Settings.Default.wDateSaverSetting;
            zSavedDate = Properties.Settings.Default.zDateSaverSetting;
            pSavedDate = Properties.Settings.Default.pDateSaverSetting;
        }




        private void dateispeichern(object sender, RoutedEventArgs e)
        {
            
        }

        private void dateioeffnen(object sender, RoutedEventArgs e)
        {

            
        }

        private void wasserauf(object sender, RoutedEventArgs e)
        {
            //Pressing the button will raise the bar to 100% and insert todays date to the txt Field next to in
            progressbarwasser.Value = 100;
            wasserdatum.Content = thisDay.ToString("D");  
        }

        private void progressbarwasser_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void progressbarzucker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
        }

        private void zuckerauf(object sender, RoutedEventArgs e)
        {
            //Pressing the button will raise the bar to 100% and insert todays date to the txt Field next to in
            progressbarzucker.Value = 100;
            zuckerdatum.Content = thisDay.ToString("D");

            Properties.Settings.Default.zDateSaverSetting = thisDay;
            Properties.Settings.Default.Save();
        }

        private void progressbarfleisch_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void fleischauf(object sender, RoutedEventArgs e)
        {
            //Pressing the button will raise the bar to 100% and insert todays date to the txt Field next to in
            progressbarfleisch.Value = 100;
            proteindatum.Content = thisDay.ToString("D");
        }

        private void textboxsoldaten_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void checkboxsoldaten2(object sender, RoutedEventArgs e)
        {
            
        }

        private void gyneplus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gyneminus_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBoxGynen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try { 
                //Beide Zahlen zu int konvertieren
                eierzahl = Convert.ToInt32(eiertxt.Text);
                larvenzahl = Convert.ToInt32(larventxt.Text);

                //Addieren und zweite Zahl zu String konvertieren
                larvenzahl = larvenzahl + eierzahl;
                larvenstr = Convert.ToString(larvenzahl);

                //Ergebnis als String einsetzen; Erstes Feld auf null setzen
                larventxt.Text = larvenstr;
                eiertxt.Text = "0";
                }
            catch (FormatException)
            {
                MessageBox.Show("FormatException. Im entsprechenden Feld steht keine Zahl.");
            }
        }

        private void sendtoPuppen_Click(object sender, RoutedEventArgs e)
        {
            try {
                //Beide Zahlen zu int konvertieren
                larvenzahl = Convert.ToInt32(larventxt.Text);
                puppenzahl = Convert.ToInt32(puppentxt.Text);

                //Addieren und zweite Zahl zu String konvertieren
                puppenzahl = puppenzahl + larvenzahl;
                puppenstr = Convert.ToString(puppenzahl);

                //Ergebnis als String einsetzen; Erstes Feld auf null setzen
                puppentxt.Text = puppenstr;
                larventxt.Text = "0";
            }
            catch (FormatException)
            {
                MessageBox.Show("FormatException. Im entsprechenden Feld steht keine Zahl.");
            }
        }

        private void geschluepft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Convert both strings to integers
                arbeiterzahl = Convert.ToInt32(TextBoxArbeiter.Text);
                puppenzahl = Convert.ToInt32(puppentxt.Text);

                //Add and convert 2nd int to string
                arbeiterzahl = puppenzahl + arbeiterzahl;
                arbeiterstr = Convert.ToString(arbeiterzahl);

                //Insert String into txtfield and set "sending" txtfield to zero
                TextBoxArbeiter.Text = arbeiterstr;
                puppentxt.Text = "0";
            }
            catch (FormatException)
            {
                MessageBox.Show("FormatException. Im entsprechenden Feld steht keine Zahl.");
            }
            
        

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog DialogSpeichern = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result1 = DialogSpeichern.ShowDialog();

            if (result1 == true)
            {
                using (Stream s = File.Open(DialogSpeichern.FileName, FileMode.OpenOrCreate))
                using (StreamWriter sw = new StreamWriter(s))
                {

                    //Following TXT will be written to designated *.txt File
                    sw.Write("ONLY CHANGE IF YOU KNOW WHAT YOU ARE DOING.");
                    sw.WriteLine();
                    sw.Write("-------------------------------------------");

                    sw.WriteLine();
                    sw.Write("TextBoxGynen: ");
                    sw.WriteLine();
                    sw.Write(TextBoxGynen.Text);        //Zeile 4

                    sw.WriteLine();
                    sw.Write("TextBoxArbeiter: ");
                    sw.WriteLine();
                    sw.Write(TextBoxArbeiter.Text);     //Zeile 6

                    sw.WriteLine();
                    sw.Write("eiertxt: ");
                    sw.WriteLine();
                    sw.Write(eiertxt.Text);             //Zeile 8

                    sw.WriteLine();
                    sw.Write("larventxt: ");
                    sw.WriteLine();
                    sw.Write(larventxt.Text);           //Zeile 10

                    sw.WriteLine();
                    sw.Write("puppentxt: ");
                    sw.WriteLine();
                    sw.Write(puppentxt.Text);           //Zeile 12

                    sw.WriteLine();
                    sw.Write("-------------------------------------------");

                    sw.WriteLine();
                    sw.Write("wasserdatum: ");
                    sw.WriteLine();
                    sw.Write(wasserdatum.Content);           //Zeile 15

                    sw.WriteLine();
                    sw.Write("zuckerdatum: ");
                    sw.WriteLine();
                    sw.Write(zuckerdatum.Content);           //Zeile 17

                    sw.WriteLine();
                    sw.Write("proteindatum: ");
                    sw.WriteLine();
                    sw.Write(proteindatum.Content);           //Zeile 19

                    sw.WriteLine();
                    sw.Write("-------------------------------------------");
                    //End of TXT
                }

            }
            
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog DialogOffnen = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result2 = DialogOffnen.ShowDialog();

            if (result2 == true)
            {
                string pfadderdatei = DialogOffnen.FileName;
                string textausderdatei = File.ReadAllText(pfadderdatei);
                //MessageBox.Show("Diese Datei wurde gewählt: " + textausderdatei);

                TextBoxGynen.Text = GetLine(textausderdatei, 4);
                TextBoxArbeiter.Text = GetLine(textausderdatei, 6);
                eiertxt.Text = GetLine(textausderdatei, 8);
                larventxt.Text = GetLine(textausderdatei, 10);
                puppentxt.Text = GetLine(textausderdatei, 12);

                wasserdatum.Content = GetLine(textausderdatei, 15);
                zuckerdatum.Content = GetLine(textausderdatei, 17);
                proteindatum.Content = GetLine(textausderdatei, 19); 
            }
        }

        string GetLine(string text, int lineNo)
        {
            string[] lines = text.Replace("\r", "").Split('\n');
            return lines.Length >= lineNo ? lines[lineNo - 1] : null;
        }
        

    }
}

