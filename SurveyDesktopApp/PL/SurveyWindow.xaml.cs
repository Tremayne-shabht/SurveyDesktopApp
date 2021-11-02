using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SurveyDesktopApp.BL;
using SurveyDesktopApp.BL.Classes;

namespace SurveyDesktopApp.PL
{
    /// <summary>
    /// Interaction logic for SurveyWindow.xaml
    /// </summary>
    public partial class SurveyWindow : Window
    {
        string surname, firstnames, numbers, date, favFood = "";
        int age, eatOut, movies, tv, radio;
        SurveyBL providerInfo;
        private string providerString;

        public SurveyWindow()
        {
            InitializeComponent();
            Initialise();
            dPDate.SelectedDate = DateTime.Now;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtSurname.Text) || string.IsNullOrEmpty(txtFirstNames.Text) || string.IsNullOrEmpty(txtNumbers.Text) || string.IsNullOrEmpty(dPDate.Text) || string.IsNullOrEmpty(txtAge.Text))
                {
                    MessageBox.Show("Enter all your personal information", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if(int.Parse(txtAge.Text) < 5 || int.Parse(txtAge.Text) > 120)
                {
                    MessageBox.Show("Enter valid age (5 years - 120 years)", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (string.IsNullOrEmpty(favFood))
                {
                    MessageBox.Show("Please select your favourite(s) Food", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if(GetEatOutSelection() == -1)
                {
                    MessageBox.Show("Please scale what you like (Strongly Agree to Strongly Disagree)", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (GetTVSelection() == -1)
                {
                    MessageBox.Show("Please scale what you like (Strongly Agree to Strongly Disagree)", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (GetMoviesSelection() == -1)
                {
                    MessageBox.Show("Please scale what you like (Strongly Agree to Strongly Disagree)", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (GetRadioSelection() == -1)
                {
                    MessageBox.Show("Please scale what you like (Strongly Agree to Strongly Disagree)", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    surname = txtSurname.Text.Trim();
                    firstnames = txtFirstNames.Text.Trim();
                    numbers = txtNumbers.Text.Trim();
                    date = dPDate.SelectedDate.ToString();
                    age = int.Parse(txtAge.Text.Trim());

                    eatOut = GetEatOutSelection();
                    movies = GetMoviesSelection();
                    tv = GetTVSelection();
                    radio = GetRadioSelection();

                    //Save To Database Function From Here On Out

                    Survey survey = new Survey();
                    survey.Surname = surname;
                    survey.FirstNames = firstnames;
                    survey.ContactNumbers = numbers;
                    survey.Date = date;
                    survey.Age = age;
                    survey.FavFood = favFood;
                    survey.EatOut = eatOut;
                    survey.Movies = movies;
                    survey.Tv = tv;
                    survey.Radio = radio;

                    int rc = providerInfo.InsertSurvey(survey);

                    if (rc == 0)
                    {
                        MessageBox.Show("Survey Successfully Recorded!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Survey Was Unsuccessfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ckBPizza_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                favFood += ",Pizza";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ckBPasta_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                favFood += ",Pasta";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ckBPap_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                favFood += ",Pap and Wors";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ckBChicken_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                favFood += ",Chicken stir fry";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ckBBeef_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                favFood += ",Beef stir fry";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ckBOther_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                favFood += ",Other";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int GetEatOutSelection()
        {
            int rc = -1;
            string selectedButton = "";

            List<RadioButton> radioButtons = myEatOut.Children.OfType<RadioButton>().ToList();
            
            var radios =
                from r in radioButtons
                where r.GroupName == "EatOut"
                select r;

            foreach(RadioButton item in radios)
            {
                if(item.IsChecked == true)
                {
                    selectedButton = item.Name.ToString();
                }
            }

            switch (selectedButton)
            {
                case "rBtnSAEat":
                    rc = 1;
                    break;
                case "rBtnAEat":
                    rc = 2;
                    break;
                case "rBtnNEat":
                    rc = 3;
                    break;
                case "rBtnDEat":
                    rc = 4;
                    break;
                case "rBtnSDEat":
                    rc = 5;
                    break;
            }

            return rc;
        }
        private int GetMoviesSelection()
        {
            int rc = -1;
            string selectedButton = "";

            List<RadioButton> radioButtons = myMovies.Children.OfType<RadioButton>().ToList();

            var radios =
                from r in radioButtons
                where r.GroupName == "Movies"
                select r;

            foreach (RadioButton item in radios)
            {
                if (item.IsChecked == true)
                {
                    selectedButton = item.Name.ToString();
                }
            }

            switch (selectedButton)
            {
                case "rBtnSAMovies":
                    rc = 1;
                    break;
                case "rBtnAMovies":
                    rc = 2;
                    break;
                case "rBtnNMovies":
                    rc = 3;
                    break;
                case "rBtnDMovies":
                    rc = 4;
                    break;
                case "rBtnSDMovies":
                    rc = 5;
                    break;
            }

            return rc;
        }
        private int GetTVSelection()
        {
            int rc = -1;
            string selectedButton = "";

            List<RadioButton> radioButtons = myTV.Children.OfType<RadioButton>().ToList();

            var radios =
                from r in radioButtons
                where r.GroupName == "TV"
                select r;

            foreach (RadioButton item in radios)
            {
                if (item.IsChecked == true)
                {
                    selectedButton = item.Name.ToString();
                }
            }

            switch (selectedButton)
            {
                case "rBtnSATV":
                    rc = 1;
                    break;
                case "rBtnATV":
                    rc = 2;
                    break;
                case "rBtnNTV":
                    rc = 3;
                    break;
                case "rBtnDTV":
                    rc = 4;
                    break;
                case "rBtnSDTV":
                    rc = 5;
                    break;
            }

            return rc;
        }
        private int GetRadioSelection()
        {
            int rc = -1;
            string selectedButton = "";

            List<RadioButton> radioButtons = myRadio.Children.OfType<RadioButton>().ToList();

            var radios =
                from r in radioButtons
                where r.GroupName == "Radio"
                select r;

            foreach (RadioButton item in radios)
            {
                if (item.IsChecked == true)
                {
                    selectedButton = item.Name.ToString();
                }
            }

            switch (selectedButton)
            {
                case "rBtnSARadio":
                    rc = 1;
                    break;
                case "rBtnARadio":
                    rc = 2;
                    break;
                case "rBtnNRadio":
                    rc = 3;
                    break;
                case "rBtnDRadio":
                    rc = 4;
                    break;
                case "rBtnSDRadio":
                    rc = 5;
                    break;
            }

            return rc;
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
