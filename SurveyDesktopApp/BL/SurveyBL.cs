using System.Collections.Generic;
using SurveyDesktopApp.BL.Classes;
using SurveyDesktopApp.DAL;

namespace SurveyDesktopApp.BL
{
    public class SurveyBL
    {
        private SurveyProviderBase providerBase;

        public SurveyBL(string provider)
        {
            setupProviderBase(provider);
        }

        public List<Survey> SelectAllSurveys()
        {
            return providerBase.SelectAllSurveys();
        }

        public int SelectSurvey(string contactNumbers, ref Survey survey)
        {
            return providerBase.SelectSurvey(contactNumbers, ref survey);
        }

        public int InsertSurvey(Survey survey)
        {
            return providerBase.InsertSurvey(survey);
        }

        public int UpdateSurvey(Survey survey)
        {
            return providerBase.UpdateSurvey(survey);
        }

        public int DeleteSurvey(string contactNumbers)
        {
            return providerBase.DeleteSurvey(contactNumbers);
        }

        private void setupProviderBase(string Provider)
        {
            if (Provider == "SurveySQLiteProvider")
            {
                providerBase = new SurveySQLiteProvider();
            }
            //future database intializationz!
        }
    }
}
