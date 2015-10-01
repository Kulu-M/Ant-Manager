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


namespace Antspace
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


        int wDaysPassed;
        int zDaysPassed;
        int pDaysPassed;


        DateTime wSavedDate = new DateTime(1990, 05, 05);
        DateTime zSavedDate = new DateTime(1990, 05, 05);
        DateTime pSavedDate = new DateTime(1990, 05, 05);


        String ColonyNameString = "";
        String ColonyRaceString = "";
        String ColonySettleDateString = "";
        String ColonyNoteString = "";




        //ZEIT

        //Request System Date
        DateTime thisDay = DateTime.Today;

        //3 Variables for 1, 2 or 3 days ago.
        //Kann wartscheinz weg
        /*DateTime oneday = DateTime.Today.AddDays(-1);
        DateTime twodays = DateTime.Today.AddDays(-2);
        DateTime threedays = DateTime.Today.AddDays(-3);
        */
        



        public KolonieOne()
        {
            InitializeComponent();

            LoadSettingsMethod();
        }


        

        public void LoadSettingsMethod()
        {
            //Daten laden

            LoadColonyData();

            LoadFoodData();  
        }


        public void LoadColonyData()
        {
            //Stammdaten

            //Vorübergehend so:
            /*Properties.Settings.Default.ColonyName = "Kolonie One";
            Properties.Settings.Default.ColonyRace = "Lasius Niger";
            Properties.Settings.Default.ColonySettleDate = "01.01.5002";
            Properties.Settings.Default.ColonyNote = "Schwarz und klein";
            */
            ColonyNameString = Properties.Settings.Default.ColonyName;
            ColonyRaceString = Properties.Settings.Default.ColonyRace;
            ColonySettleDateString = Properties.Settings.Default.ColonySettleDate;
            ColonyNoteString = Properties.Settings.Default.ColonyNote;

            ColonyName.Content = ColonyNameString;
            ColonyRace.Content = ColonyRaceString;
            ColonySettleDate.Content = ColonySettleDateString;
            ColonyNote.Content = ColonyNoteString;

        }


        public void LoadFoodData()
        {
            //Food
            wSavedDate = Properties.Settings.Default.wDateSaverSetting;
            zSavedDate = Properties.Settings.Default.zDateSaverSetting;
            pSavedDate = Properties.Settings.Default.pDateSaverSetting;

            wDaysGone();
            zDaysGone();
            pDaysGone();
/*
            wDaysGoneField.Content = wSavedDate;
            zDaysGoneField.Content = zSavedDate;
            pDaysGoneField.Content = pSavedDate;
 * */
        }


        private void dateispeichern(object sender, RoutedEventArgs e)
        {
            
        }

        private void dateioeffnen(object sender, RoutedEventArgs e)
        {
            
        }



        //WASSERBALKEN ----------------------------------------------------------
        private void wasserauf(object sender, RoutedEventArgs e)
        {
            //Pressing the button will raise the bar to 100% and insert todays date to the txt Field next to in
            wBar.Value = 100;
            wDaysGoneField.Content = thisDay.ToString("Vor weniger als 24 Stunden");

            Properties.Settings.Default.wDateSaverSetting = thisDay;
            Properties.Settings.Default.Save();

        }

        public void wDaysGone()
        {

            //Heute minus gespeichertes Datum = Anzahl vergangener Tage
            //Und die Ausgabe

            wDaysPassed = (thisDay - wSavedDate).Days;


            if (wDaysPassed == 0)
            {
                wDaysGoneField.Content = "Vor weniger als 24 Stunden";
                wBar.Value = 100;
            }
            else if (wDaysPassed == 1)
            {
                wDaysGoneField.Content = "Vor einem Tag";
                wBar.Value = 66;
            }
            else if (wDaysPassed == 2)
            {
                wDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                wBar.Value = 33;
            }
            else
            {
                wDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                wBar.Value = 0;
            }
        }

        private void progressbarwasser_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }



        //ZUCKERBALKEN ----------------------------------------------------------
        private void zuckerauf(object sender, RoutedEventArgs e)
        {
            //Pressing the button will raise the bar to 100% and insert todays date to the txt Field next to in
            zBar.Value = 100;
            zDaysGoneField.Content = ("Vor weniger als 24 Stunden");

            Properties.Settings.Default.zDateSaverSetting = thisDay;
            Properties.Settings.Default.Save();
        }

        public void zDaysGone()
        {

            //Heute minus gespeichertes Datum = Anzahl vergangener Tage
            //Und die Ausgabe

            zDaysPassed = (thisDay - zSavedDate).Days;


            if (zDaysPassed == 0)
            {
                zDaysGoneField.Content = "Vor weniger als 24 Stunden";
                zBar.Value = 100;
            }
            else if (zDaysPassed == 1)
            {
                zDaysGoneField.Content = "Vor einem Tag";
                zBar.Value = 66;
            }
            else if (zDaysPassed == 2)
            {
                zDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                zBar.Value = 33;
            }
            else
            {
                zDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                zBar.Value = 0;
            }
        }
        
        private void progressbarzucker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
        }



        //PROTEINBALKEN ----------------------------------------------------------
        private void fleischauf(object sender, RoutedEventArgs e)
        {
            //Pressing the button will raise the bar to 100% and insert todays date to the txt Field next to in
            pBar.Value = 100;
            pDaysGoneField.Content = thisDay.ToString("Vor weniger als 24 Stunden");

            Properties.Settings.Default.pDateSaverSetting = thisDay;
            Properties.Settings.Default.Save();
        }

        public void pDaysGone()
        {

            //Heute minus gespeichertes Datum = Anzahl vergangener Tage
            //Und die Ausgabe

            pDaysPassed = (thisDay - pSavedDate).Days;


            if (pDaysPassed == 0)
            {
                pDaysGoneField.Content = "Vor weniger als 24 Stunden";
                pBar.Value = 100;
            }
            else if (pDaysPassed == 1)
            {
                pDaysGoneField.Content = "Vor einem Tag";
                pBar.Value = 66;
            }
            else if (pDaysPassed == 2)
            {
                pDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                pBar.Value = 33;
            }
            else
            {
                pDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                pBar.Value = 0;
            }
        }

        private void progressbarfleisch_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }



        //--------------------------------------------------------------------------------------------------------------------------



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

        public void ColonyDataOpacityZero()
        {
            ColonyName.Opacity = 0;
            ColonyRace.Opacity = 0;
            ColonySettleDate.Opacity = 0;
            ColonyNote.Opacity = 0;
        }

        public void ColonyDataOpacityFull()
        {
            ColonyName.Opacity = 100;
            ColonyRace.Opacity = 100;
            ColonySettleDate.Opacity = 100;
            ColonyNote.Opacity = 100;
        }

        public void ColonyChangesOpacityZero()
        {
            ColonyNameChangeBox.Opacity = 0;
            ColonyRaceChangeBox.Opacity = 0;
            ColonySettleDateChangeBox.Opacity = 0;
            ColonyNoteChangeBox.Opacity = 0;
        }

        public void ColonyChangesOpacityFull()
        {
            ColonyNameChangeBox.Opacity = 100;
            ColonyRaceChangeBox.Opacity = 100;
            ColonySettleDateChangeBox.Opacity = 100;
            ColonyNoteChangeBox.Opacity = 100;
        }

        public void ResetChangeFieldstoTextFields()
        {
            ColonyNameChangeBox.Text = Properties.Settings.Default.ColonyName;
            ColonyRaceChangeBox.Text = Properties.Settings.Default.ColonyRace;
            ColonySettleDateChangeBox.Text = Properties.Settings.Default.ColonySettleDate;
            ColonyNoteChangeBox.Text = Properties.Settings.Default.ColonyNote;
        }

        private void ChangeColonyData(object sender, RoutedEventArgs e)
        {
            ResetChangeFieldstoTextFields();

            ColonyDataOpacityZero();
            ColonyChangesOpacityFull();

            //Show Buttons
            SaveColonyChanges.Opacity = 100;
            AbortColonyChanges.Opacity = 100;

            ChangeData.Opacity = 0.2;
            DeleteColony.Opacity = 0.2;
        }

        private void SaveColonyChanges_Click(object sender, RoutedEventArgs e)
        {
            //Neue Eingaben speichern
            Properties.Settings.Default.ColonyName = ColonyNameChangeBox.Text;
            Properties.Settings.Default.ColonyRace = ColonyRaceChangeBox.Text;
            Properties.Settings.Default.ColonySettleDate = ColonySettleDateChangeBox.Text;
            Properties.Settings.Default.ColonyNote = ColonyNoteChangeBox.Text;

            Properties.Settings.Default.Save();

            //Felder wieder anzeigen
            ColonyDataOpacityFull();
            ColonyChangesOpacityZero();

            ChangeData.Opacity = 100;
            DeleteColony.Opacity = 100;

            SaveColonyChanges.Opacity = 0;
            AbortColonyChanges.Opacity = 0;

            LoadColonyData();


        }

        private void AbortColonyChanges_Click(object sender, RoutedEventArgs e)
        {
            ColonyChangesOpacityZero();
            ColonyDataOpacityFull();

            ChangeData.Opacity = 100;
            DeleteColony.Opacity = 100;

            SaveColonyChanges.Opacity = 0;
            AbortColonyChanges.Opacity = 0;
        }


        /*
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
         * 
         * 
         * 
         */
        

    }
}

