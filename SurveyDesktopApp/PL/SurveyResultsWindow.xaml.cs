using SurveyDesktopApp.BL;
using SurveyDesktopApp.BL.Classes;
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
using System.Windows.Shapes;

namespace SurveyDesktopApp.PL
{
    /// <summary>
    /// Interaction logic for SurveyResultsWindow.xaml
    /// </summary>
    public partial class SurveyResultsWindow : Window
    {
        SurveyBL providerInfo;
        private string providerString;
        List<Survey> surveys;

        public SurveyResultsWindow()
        {
            InitializeComponent();

            try
            {
                Initialise();

                surveys = new List<Survey>();
                surveys = providerInfo.SelectAllSurveys();

                if (surveys != null)
                {
                    lblSurveys.Content = surveys.Count;
                }

                //Survey Info
                lblAvgAge.Content = CalculateAverageAge();
                lblOldest.Content = OldestPerson();
                lblYoungest.Content = YoungestPerson();

                //Favourite Food
                lblPizza.Content = CalculatePercentageOfPizza() + "%";
                lblPasta.Content = CalculatePercentageOfPasta() + "%";
                lblPapAndWors.Content = CalculatePercentageOfPapAndWors() + "%";

                //Agree or DisAgree
                lblEatOut.Content = CalculateNumOfPeopleEatOut();
                lblMovies.Content = CalculateNumOfMovies();
                lblTV.Content = CalculateNumOfTV();
                lblRadio.Content = CalculateNumOfRadio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double CalculateNumOfRadio()
        {
            double numOfPeople = 0;
            double average = 0;

            foreach (Survey survey in surveys)
            {
                if (survey.Radio > 0 && survey.Radio <= 3)
                {
                    numOfPeople++;
                }
            }

            average = numOfPeople / surveys.Count;

            return Math.Round(average, 1);
        }

        private double CalculateNumOfTV()
        {
            double numOfPeople = 0;
            double average = 0;

            foreach (Survey survey in surveys)
            {
                if (survey.Tv > 0 && survey.Tv <= 3)
                {
                    numOfPeople++;
                }
            }

            average = numOfPeople / surveys.Count;

            return Math.Round(average, 1);
        }

        private double CalculateNumOfMovies()
        {
            double numOfPeople = 0;
            double average = 0;

            foreach (Survey survey in surveys)
            {
                if (survey.Movies > 0 && survey.Movies <= 3)
                {
                    numOfPeople++;
                }
            }

            average = numOfPeople / surveys.Count;

            return Math.Round(average, 1);
        }

        private double CalculateNumOfPeopleEatOut()
        {
            double numOfPeople = 0;
            double average = 0;

            foreach(Survey survey in surveys)
            {
                if(survey.EatOut > 0 && survey.EatOut <= 3)
                {
                    numOfPeople++;
                }
            }

            average = numOfPeople / surveys.Count;

            return Math.Round(average, 1);
        }

        private double CalculatePercentageOfPapAndWors()
        {
            double numOfPeople = 0;
            double percentage;

            foreach (Survey survey in surveys)
            {
                if (survey.FavFood.Contains("Pap and Wors"))
                {
                    numOfPeople++;
                }
            }

            percentage = (numOfPeople / surveys.Count) * 100;

            return Math.Round(percentage, 1);
        }

        private double CalculatePercentageOfPasta()
        {
            double numOfPeople = 0;
            double percentage;

            foreach(Survey survey in surveys)
            {
                if(survey.FavFood.Contains("Pasta"))
                {
                    numOfPeople++;
                }
            }

            percentage = (numOfPeople / surveys.Count) * 100;

            return Math.Round(percentage, 1);
        }

        private double CalculatePercentageOfPizza()
        {
            double numOfPeople = 0;
            double percentage = 0.0;

            foreach(Survey item in surveys)
            {
                if(item.FavFood.Contains("Pizza"))
                {
                    numOfPeople++;
                }
            }

            percentage += (numOfPeople / surveys.Count) * 100;
            
            return Math.Round(percentage, 1);
        }

        private int YoungestPerson()
        {
            return surveys.Min(x => x.Age);
        }

        private int OldestPerson()
        {
            return surveys.Max(x => x.Age);
        }

        private int CalculateAverageAge()
        {
            int ages = 0;
            int average; 

            foreach (Survey survey in surveys)
            {
                if (survey != null)
                {
                    ages += survey.Age;
                }
            }

            average = ages / surveys.Count;
            return average;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Initialise()
        {
            try
            {
                providerString = "SurveySQLiteProvider";
                providerInfo = new SurveyBL(providerString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
