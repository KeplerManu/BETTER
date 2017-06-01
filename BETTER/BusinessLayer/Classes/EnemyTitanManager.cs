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
    public class EnemyTitanManager
    {
        string DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;

        public int GetEnemyTitanID(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT titanId FROM tblTitan t, tblUser u WHERE titanName=@titanName AND u.userID = t.userID AND userName!=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public int GetEnemyTitanName(string TitanID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT titanName FROM tblTitan t, tblUser u WHERE titanId=@titanId AND u.userID = t.userID AND userName!=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanId", TitanID);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public int GetEnemyElementID(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT elementId FROM tblTitan t, tblUser u WHERE titanName=@titanName AND u.userID = t.userID AND userName!=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public string GetEnemyElementName(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("; WITH cte AS(SELECT el.elementName, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u, tblElement el WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName != @userName) SELECT* FROM cte WHERE rn = 1", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public string GetEnemyTitanImagePath(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT imagePath FROM tblTitan t, tblUser u WHERE titanName=@titanName AND u.userID = t.userID AND userName!=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public int GetEnemyTitanBattles(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*)  FROM(SELECT COUNT(*) AS counts FROM tblBattle b, tblTitan t, tblUser u WHERE (b.battler1=@titanId) OR (b.battler2=@titanId) AND titanName=@titanName AND t.userID=u.userID AND userName!=@userName GROUP BY battleId HAVING COUNT(*) > 1) AS counts", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanID", GetEnemyTitanID(TitanName));
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return result;
                }
            }
        }

        public int GetEnemyTitanWins(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM tblBattle b, tblTitan t, tblUser u WHERE (b.battler1=@titanID AND battleWinner='true') OR (b.battler2=@titanID AND battleWinner='false') AND titanName=@titanName AND t.userID=u.userID AND userName!=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanID", GetEnemyTitanID(TitanName));
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return result;
                }
            }
        }

        public int GetEnemyTitanLosses(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM tblBattle b, tblTitan t, tblUser u WHERE (b.battler1=@titanID AND battleWinner='false') OR (b.battler2=@titanID AND battleWinner='true') AND titanName=@titanName AND t.userID=u.userID AND userName!=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanID", GetEnemyTitanID(TitanName));
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return result;
                }
            }
        }

        public string GetEnemyTitanLevel(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(";WITH cte AS(SELECT lvl, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName != @userName AND titanName=@titanName) SELECT* FROM cte WHERE rn = 1", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public int GetEnemyTitanStep(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(";WITH cte AS(SELECT step, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName != @userName AND titanName=@titanName) SELECT* FROM cte WHERE rn = 1", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return result;
                }
            }
        }

        public int GetEnemyTitanExperience(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT experience FROM  tblTitan t, tblUser u WHERE titanName=@titanName AND u.userID = t.userID AND u.userName!=@userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    int result = (int)sqlCommand.ExecuteScalar();
                    return result;
                }
            }
        }

        public int GetEnemyTitanMaxLevelExperience(string TitanName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(";WITH cte AS(SELECT expMax, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName != @userName AND titanName=@titanName) SELECT* FROM cte WHERE rn = 1", sqlConnection))
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
                    sqlCommand.Parameters.AddWithValue("@titanID", System.Web.HttpContext.Current.Session["EnemyChampID"]);
                    string result = sqlCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
        }

        public void UpdateEnemyTitanExperience(string TitanName, int experience)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE tblTitan SET experience = experience + @experience FROM tblTitan AS t INNER JOIN tblUser AS u ON t.userid = u.userid WHERE t.titanName = @titanName AND userName != @userName", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@titanName", TitanName);
                    sqlCommand.Parameters.AddWithValue("@experience", experience);
                    sqlCommand.Parameters.AddWithValue("@userName", System.Web.HttpContext.Current.Session["UserName"]);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}