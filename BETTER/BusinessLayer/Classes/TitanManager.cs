using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BETTER.DataAccessLayer.Classes;
using System.Data.SqlClient;
using System.Configuration;

namespace BETTER.BusinessLayer.Classes
{
    public class TitanManager
    {
        string DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;

        public DataTable GetTitansByUserName(string userName)
        {
            try
            {
                TitanDAL obj = new TitanDAL();
                return obj.TitanList(userName);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetWaterTitansByUserName(string userName)
        {
            try
            {
                TitanDAL obj = new TitanDAL();
                return obj.TitanListWater(userName);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetFireTitansByUserName(string userName)
        {
            try
            {
                TitanDAL obj = new TitanDAL();
                return obj.TitanListFire(userName);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetAirTitansByUserName(string userName)
        {
            try
            {
                TitanDAL obj = new TitanDAL();
                return obj.TitanListAir(userName);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetEarthTitansByUserName(string userName)
        {
            try
            {
                TitanDAL obj = new TitanDAL();
                return obj.TitanListEarth(userName);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetActiveTitansByUserName(string userName)
        {
            try
            {
                TitanDAL obj = new TitanDAL();
                return obj.TitanListActive(userName);
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetEnemyTitans(string userName, string titanName)
        {
            try
            {
                TitanDAL obj = new TitanDAL();
                return obj.EnemyTitanList(userName, titanName);
            }
            catch
            {
                throw;
            }
        }

        public int GetTitanID(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT titanId FROM tblTitan t, tblUser u WHERE titanName=@titanName AND u.userID = t.userID AND userName=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public int GetTitanName(string TitanID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT titanName FROM tblTitan t, tblUser u WHERE titanId=@titanId AND u.userID = t.userID AND userName=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanID", TitanID);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public int GetElementID(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT elementId FROM tblTitan t, tblUser u WHERE titanName=@titanName AND u.userID = t.userID AND userName=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public string GetElementName(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("; WITH cte AS(SELECT el.elementName, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u, tblElement el WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName) SELECT* FROM cte WHERE rn = 1", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public string GetTitanImagePath(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT imagePath FROM tblTitan t, tblUser u WHERE titanName=@titanName AND u.userID = t.userID AND userName=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public int GetTitanBattles(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM(SELECT COUNT(*) AS counts FROM tblBattle b, tblTitan t, tblUser u WHERE(b.battler1 = @titanId) OR(b.battler2 = @titanId) AND titanName = @titanName AND t.userID = u.userID AND userName = @userName GROUP BY battleId HAVING COUNT(*) > 1) AS counts", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanID", GetTitanID(TitanName));
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return result;
                }
            }
        }

        public int GetTitanWins(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM(SELECT COUNT(*) AS counts FROM tblBattle b, tblTitan t, tblUser u WHERE (b.battler1=@titanID AND battleWinner='true') OR (b.battler2=@titanID AND battleWinner='false') AND titanName=@titanName AND t.userID=u.userID AND userName=@userName GROUP BY battleId HAVING COUNT(*) > 1) AS counts", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanID", GetTitanID(TitanName));
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return result;
                }
            }
        }

        public int GetTitanLosses(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM(SELECT COUNT(*) AS counts FROM tblBattle b, tblTitan t, tblUser u WHERE (b.battler1=@titanID AND battleWinner='false') OR (b.battler2=@titanID AND battleWinner='true') AND titanName=@titanName AND t.userID=u.userID AND userName=@userName GROUP BY battleId HAVING COUNT(*) > 1) AS counts", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanID", GetTitanID(TitanName));
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return result;
                }
            }
        }

        public string GetTitanLevel(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(";WITH cte AS(SELECT lvl, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName AND titanName=@titanName) SELECT* FROM cte WHERE rn = 1", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public int GetTitanStep(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(";WITH cte AS(SELECT step, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName AND titanName=@titanName) SELECT* FROM cte WHERE rn = 1", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return result;
                }
            }
        }

        public int GetTitanExperience(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT experience FROM  tblTitan t, tblUser u WHERE titanName=@titanName AND u.userID = t.userID AND u.userName=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public int GetTitanMaxLevelExperience(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(";WITH cte AS(SELECT expMax, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName AND titanName=@titanName) SELECT* FROM cte WHERE rn = 1", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public string GetUserNameByTitanID(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(";WITH cte AS(SELECT u.userName, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND titanID=@titanID) SELECT* FROM cte WHERE rn = 1", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanID", System.Web.HttpContext.Current.Session["ChampID"]);
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public void UpdateTitanExperience(string TitanName, int experience)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE tblTitan SET experience = experience + @experience FROM tblTitan AS t INNER JOIN tblUser AS u ON t.userid = u.userid WHERE t.titanName = @titanName AND userName = @userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@experience", experience);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void DeactivateTitan(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE tblTitan SET active = @active FROM tblTitan AS t INNER JOIN tblUser AS u ON t.userid = u.userid WHERE t.titanName = @titanName AND userName = @userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@active", false);
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void ActivateTitan(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE tblTitan SET active=@active FROM tblTitan AS t INNER JOIN tblUser AS u ON t.userid = u.userid WHERE t.titanName = @titanName AND userName=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@active", true);
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public bool ValidateActiveTitan(int elementID, string titanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM tblTitan t, tblUser u WHERE t.userId=u.userId AND userName=@userName AND elementID=@elementID AND t.active=@active", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@username", System.Web.HttpContext.Current.Session["UserName"]);
                    sqlCommand.Parameters.AddWithValue("@elementID", elementID);
                    sqlCommand.Parameters.AddWithValue("@active", true);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool NameExists(string titanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM tblTitan t, tblUser u WHERE u.userID=t.userID AND userName=@userName AND titanName=@titanName", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    sqlCommand.Parameters.AddWithValue("@titanName", titanName);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void RenameTitan(string newTitanName, string titanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE tblTitan SET titanName=@newTitanName FROM tblTitan AS t INNER JOIN tblUser AS u ON t.userid = u.userid WHERE t.titanName = @titanName AND userName = @userName", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@newTitanName", newTitanName);
                    sqlCommand.Parameters.AddWithValue("@titanName", titanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

    }
}