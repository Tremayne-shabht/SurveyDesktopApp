using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyDesktopApp.BL.Classes
{
    public class Survey
    {
        private string surname;
        private string firstNames;
        private string contactNumbers;
        private string date;
        private int age;
        private string favFood;
        private int eatOut;
        private int movies;
        private int tv;
        private int radio;

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        public string FirstNames
        {
            get
            {
                return firstNames;
            }
            set
            {
                firstNames = value;
            }
        }
        public string ContactNumbers { get => contactNumbers; set => contactNumbers = value; }
        public string Date { get => date; set => date = value; }
        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                if(age < 5 && age > 120)
                {
                    throw new Exception("Age must not be less than 5 or greater than 120");
                }
                else
                {
                    age = value;
                }
            }
        }
        public string FavFood { get => favFood; set => favFood = value; }
        public int EatOut { get => eatOut; set => eatOut = value; }
        public int Movies { get => movies; set => movies = value; }
        public int Tv { get => tv; set => tv = value; }
        public int Radio { get => radio; set => radio = value; }
    }
}
