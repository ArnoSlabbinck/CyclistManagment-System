using r0678304_Examen_2021.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace r0678304_Examen_2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double getal = 0;
        private string soortMedewerker = string.Empty;

        private Wielrenner Wielrenner;
        private string error = string.Empty;

        private ProfWielrenner ProfWielrenner;

        private PloegMedewerker Medewerker = new PloegMedewerker();

        public List<PloegMedewerker> PloegMedewerkers;

        public PloegMedewerker PloegMedewerker = new PloegMedewerker("Arno Slabbinck", "Quickstep", 4);

        public List<string> Disciples;

        public MainWindow()
        {

            InitializeComponent();



            try
            {

                ToevoegenPloegmedewerkers();
                Medewerkers.ItemsSource = PloegMedewerkers;
                Medewerkers.SelectedItem = PloegMedewerker;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }

        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            CheckInputFieldsPloegmedewerker();

        }

        private void ToonDetail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sluiten_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your application will be closed");
            Window.GetWindow(this).Close();
        }

        private void ToevoegenPloegmedewerkers()
        {
            PloegMedewerkers = new List<PloegMedewerker>();
            PloegMedewerkers.Add(new PloegMedewerker("Arno Slabbinck", "QuickStep", 2));
            PloegMedewerkers.Add(new PloegMedewerker("Jan Vertonghen", "QuickStep", 4));
            PloegMedewerkers.Add(new PloegMedewerker("Dries Mertens", "QuickStep", 2));
            PloegMedewerkers.Add(new PloegMedewerker("Eden Hazard", "QuickStep", 5));
            PloegMedewerkers.Add(new Wielrenner("Sven Nys", "QuickStep", 4, 20.52));
            PloegMedewerkers.Add(new ProfWielrenner("Johan Boskamp", "QuickStep", 4, 20.52, 2000, "Timesprint"));
        }
        /// <summary>
        /// Find the file in current directory and writes content to that file
        /// </summary>
        public void WriteContentToFileGegevens()
        {
            FileInfo filepath = null;
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.Name == "gegevens.txt")
                {
                    filepath = file;
                }
            }

            try
            {
                using (var writer = new StreamWriter(filepath.FullName))
                {
                    writer.WriteLine("Arno Slabbinck");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


        private void Medewerkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void VulComboBox()
        {
            Disciples = new List<string>();
            Disciples.Add("Sprint");
            Disciples.Add("Tijdrit");
            Disciples.Add("Bergrit");
        }


        private bool ConvertStringToDouble(string number)
        {

            var startgeldGelukt = double.TryParse(number, out getal);
            if (startgeldGelukt == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Startgeld moet een getal met kommacijfers zijn");
                return false;
            }
        }

        private void CheckInputsFieldProfWielrenner(string naam,
            string ploeg,
            int wedstrijden,
            double startgeld)
        {
            ConvertStringToDouble(loon.Text);
            ProfWielrenner = new ProfWielrenner(naam,
                ploeg,
                wedstrijden,
                startgeld,
                getal,
                disciple.SelectedItem.ToString());
            try
            {
                
                if (Wielrenner.errorMessages.Count > 0)
                {
                    throw new Exception();
                }
                MessageBox.Show($"{naam} is toegevoegd");
                PloegMedewerkers.Add(ProfWielrenner);
            }
            catch (Exception)
            {
                MessageBox.Show(ProfWielrenner.errorMessages.Select(p => p).ToString());
            }

        }
        private void CheckInputFieldsWielrenner(string naam, string ploeg, int wedstrijden)
        {
            ConvertStringToDouble(startgeld.Text);
            Wielrenner = new Wielrenner(naam, ploeg, wedstrijden, getal);
            try
            {
                
                if (soortMedewerker == "profwielrenner")
                {
                    CheckInputsFieldProfWielrenner(naam, ploeg, wedstrijden, getal);
                }
                else
                {
                    if (Wielrenner.errorMessages.Count > 0)
                    {
                        throw new Exception();
                    }
                    MessageBox.Show($"{naam} is toegevoegd");
                    PloegMedewerkers.Add(Wielrenner);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Wielrenner.errorMessages.First().ToString());
            }

        }

        private void CheckInputFieldsPloegmedewerker()
        {
            int wedstrijdenGespeeld = 0;
            bool succesWedstrijden = int.TryParse(wedstrijden.Text, out wedstrijdenGespeeld);
            Medewerker = new PloegMedewerker(naam.Text, ploeg.Text, wedstrijdenGespeeld);
            
            try
            {
                
                if (succesWedstrijden == true)
                {
                    //Toevoegen Profwielrenner
                    if (soortMedewerker == "wielrenner"
                        || soortMedewerker == "profwielrenner")
                    {
                        CheckInputFieldsWielrenner(naam.Text, ploeg.Text, wedstrijdenGespeeld);

                    }
                    else
                    {

                        
                        if (Medewerker.errorMessages.Count > 0)
                        {
                            throw new Exception();
                        }

                        MessageBox.Show($"{naam.Text} is toegevoegd");
                        PloegMedewerkers.Add(Medewerker);
                    }


                }

                else
                    throw new Exception();

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(Medewerker.errorMessages.First().ToString());
            }




        }

        private void Check_Medewerker_Checked(object sender, RoutedEventArgs e)
        {
            var checkboxContent = sender as CheckBox;
            switch (checkboxContent.Content.ToString().ToLower())
            {
                case "prof":
                    SetProfWielrenner();
                    VulComboBox();
                    disciple.ItemsSource = Disciples;
                    soortMedewerker = "profwielrenner";
                    break;
                case "wielrenner":
                    SetWielrenner();
                    soortMedewerker = "wielrenner";
                    break;
                default:
                    SetPloegMedeWerker();
                    soortMedewerker = "ploegmedewerker";
                    break;
            }
        }

        private void SetProfWielrenner()
        {
            startgeldText.Visibility = Visibility.Visible;
            startgeld.Visibility = Visibility.Visible;
            loon.Visibility = Visibility.Visible;
            loonText.Visibility = Visibility.Visible;
            disciple.Visibility = Visibility.Visible;
            disciplineText.Visibility = Visibility.Visible;

        }

        private void SetWielrenner()
        {
            loon.Visibility = Visibility.Hidden;
            loonText.Visibility = Visibility.Hidden;
            disciple.Visibility = Visibility.Hidden;
            disciplineText.Visibility = Visibility.Hidden;

            startgeldText.Visibility = Visibility.Visible;
            startgeld.Visibility = Visibility.Visible;
        }

        private void SetPloegMedeWerker()
        {
            loon.Visibility = Visibility.Hidden;
            loonText.Visibility = Visibility.Hidden;
            disciple.Visibility = Visibility.Hidden;
            disciplineText.Visibility = Visibility.Hidden;

            startgeldText.Visibility = Visibility.Hidden;
            startgeld.Visibility = Visibility.Hidden;

        }
    }
}

