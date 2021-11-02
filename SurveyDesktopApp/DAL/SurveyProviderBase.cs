using System.Collections.Generic;
using SurveyDesktopApp.BL.Classes;

namespace SurveyDesktopApp.DAL
{
    public abstract class SurveyProviderBase
    {
        public abstract List<Survey> SelectAllSurveys();

        public abstract int SelectSurvey(string contactNumbers, ref Survey survey);

        public abstract int InsertSurvey(Survey survey);

        public abstract int UpdateSurvey(Survey survey);

        public abstract int DeleteSurvey(string contactNumbers);
    }
}
