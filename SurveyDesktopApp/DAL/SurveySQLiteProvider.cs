using SurveyDesktopApp.BL.Classes;
using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Reflection;

namespace SurveyDesktopApp.DAL
{
    public class SurveySQLiteProvider : SurveyProviderBase
    {
        private string buildPath = Assembly.GetExecutingAssembly().ToString().Replace("SurveyDesktopApp.exe", "SurveyInfo.s3db; Version=3;");
        private string conStr = "Data Source=" + Assembly.GetExecutingAssembly().Location.Replace("SurveyDesktopApp.exe", "SurveyInfo.s3db; Version=3;");
        private SQLiteConnection sqlCon;

        public override int InsertSurvey(Survey survey)
        {
            int rc = 0;

            try
            {
                sqlCon = new SQLiteConnection(conStr);
                sqlCon.Open();

                string insertQuery = "INSERT INTO Survey([surname], [firstNames], [contactNumbers], [date], [age], [favFood], [eatOut], [movies], [tv], [radio]) VALUES(@surname, @firstNames, @contactNumbers, @date, @age, @favFood, @eatOut, @movies, @tv, @radio)";
                SQLiteCommand sqlCmd = new SQLiteCommand(insertQuery, sqlCon);
                sqlCmd.Parameters.AddWithValue("@surname", survey.Surname);
                sqlCmd.Parameters.AddWithValue("@firstNames", survey.FirstNames);
                sqlCmd.Parameters.AddWithValue("@contactNumbers", survey.ContactNumbers);
                sqlCmd.Parameters.AddWithValue("@date", survey.Date);
                sqlCmd.Parameters.AddWithValue("@age", survey.Age);
                sqlCmd.Parameters.AddWithValue("@favFood", survey.FavFood);
                sqlCmd.Parameters.AddWithValue("@eatOut", survey.EatOut);
                sqlCmd.Parameters.AddWithValue("@movies", survey.Movies);
                sqlCmd.Parameters.AddWithValue("@tv", survey.Tv);
                sqlCmd.Parameters.AddWithValue("@radio", survey.Radio);
                rc = sqlCmd.ExecuteNonQuery();

                if(rc == 0)
                {
                    rc = -1;
                }
                else
                {
                    rc = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return rc;
        }

        public override List<Survey> SelectAllSurveys()
        {
            List<Survey> surveys = null;

            try
            {
                surveys = new List<Survey>();

                sqlCon = new SQLiteConnection(conStr);
                sqlCon.Open();

                string selectQuery = "SELECT * FROM Survey";
                SQLiteCommand sqlCmd = new SQLiteCommand(selectQuery, sqlCon);
                SQLiteDataReader sqlDr = sqlCmd.ExecuteReader();

                while (sqlDr.Read())
                {
                    Survey survey = new Survey();
                    survey.Surname = Convert.ToString(sqlDr["surname"].ToString());
                    survey.FirstNames = Convert.ToString(sqlDr["firstNames"].ToString());
                    survey.ContactNumbers = Convert.ToString(sqlDr["contactNumbers"].ToString());
                    survey.Date = Convert.ToString(sqlDr["date"].ToString());
                    survey.Age = Convert.ToInt32(sqlDr["age"].ToString());
                    survey.FavFood = Convert.ToString(sqlDr["favFood"].ToString());
                    survey.EatOut = Convert.ToInt32(sqlDr["eatOut"].ToString());
                    survey.Movies = Convert.ToInt32(sqlDr["movies"].ToString());
                    survey.Tv = Convert.ToInt32(sqlDr["tv"].ToString());
                    survey.Radio = Convert.ToInt32(sqlDr["radio"].ToString());

                    surveys.Add(survey);
                }
                sqlDr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return surveys;
        }

        public override int SelectSurvey(string contactNumbers, ref Survey survey)
        {
            int rc = -1;

            try
            {
                sqlCon = new SQLiteConnection(conStr);
                sqlCon.Open();

                string selectQuery = string.Format("SELECT * FROM Survey WHERE [contactNumbers] = '{0}'", contactNumbers);
                SQLiteCommand sqlCmd = new SQLiteCommand(selectQuery, sqlCon);
                SQLiteDataReader sqlDr = sqlCmd.ExecuteReader();

                while (sqlDr.Read())
                {
                    rc = 0;

                    survey = new Survey();
                    survey.Surname = Convert.ToString(sqlDr["surname"].ToString());
                    survey.FirstNames = Convert.ToString(sqlDr["firstNames"].ToString());
                    survey.ContactNumbers = Convert.ToString(sqlDr["contactNumbers"].ToString());
                    survey.Date = Convert.ToString(sqlDr["date"].ToString());
                    survey.Age = Convert.ToInt32(sqlDr["age"].ToString());
                    survey.FavFood = Convert.ToString(sqlDr["favFood"].ToString());
                    survey.EatOut = Convert.ToInt32(sqlDr["eatOut"].ToString());
                    survey.Movies = Convert.ToInt32(sqlDr["movies"].ToString());
                    survey.Tv = Convert.ToInt32(sqlDr["tv"].ToString());
                    survey.Radio = Convert.ToInt32(sqlDr["radio"].ToString());
                }
                sqlDr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return rc;
        }

        public override int UpdateSurvey(Survey survey)
        {
            int rc = 0;

            try
            {
                sqlCon = new SQLiteConnection(conStr);
                sqlCon.Open();

                string updateQuery = string.Format("UPDATE Survey SET [surname]=@surname, [firstNames]=@firstNames, [date]=@date, [age]=@age, [favFood]=@favFood, [eatOut]=@eatOut, [movies]=@movies, [tv]=@tv, [radio]=@radio WHERE [contactNumbers] = '{0}'", survey.ContactNumbers);
                SQLiteCommand sqlCmd = new SQLiteCommand(updateQuery, sqlCon);
                sqlCmd.Parameters.AddWithValue("@surname", survey.Surname);
                sqlCmd.Parameters.AddWithValue("@firstNames", survey.FirstNames);
                sqlCmd.Parameters.AddWithValue("@date", survey.Date);
                sqlCmd.Parameters.AddWithValue("@age", survey.Age);
                sqlCmd.Parameters.AddWithValue("@favFood", survey.FavFood);
                sqlCmd.Parameters.AddWithValue("@eatOut", survey.EatOut);
                sqlCmd.Parameters.AddWithValue("@movies", survey.Movies);
                sqlCmd.Parameters.AddWithValue("@tv", survey.Tv);
                sqlCmd.Parameters.AddWithValue("@radio", survey.Radio);
                rc = sqlCmd.ExecuteNonQuery();

                if (rc == 0)
                {
                    rc = -1;
                }
                else
                {
                    rc = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return rc;
        }

        public override int DeleteSurvey(string contactNumbers)
        {
            int rc = -1;

            try
            {
                sqlCon = new SQLiteConnection(conStr);
                sqlCon.Open();

                string deleteQuery = string.Format("DELETE FROM Survey WHERE [contactNumbers] = '{0}'", contactNumbers);
                SQLiteCommand sqlCmd = new SQLiteCommand(deleteQuery, sqlCon);
                rc = sqlCmd.ExecuteNonQuery();

                if (rc == 0)
                {
                    rc = -1;
                }
                else
                {
                    rc = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return rc;
        }
    }
}
