using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using BETTER.BusinessLayer.Classes;

namespace BETTER.DataAccessLayer.Classes
{
    public class TitanDAL
    {
        string DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;

        DataTable dt = new DataTable();

        public void AddTitan(string TitanName, int ElementID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();

                using (SqlCommand command = sqlConnection.CreateCommand())
                {
                    var userManager = new UserManager();
                    command.CommandText = "INSERT INTO tblTitan (titanName, userID, elementID, experience, active, creationDate, imagePath) VALUES (@titanName, @userID, @elementID, @experience, @active, @creationDate, @imagePath)";

                    command.Parameters.AddWithValue("@titanName", TitanName);
                    command.Parameters.AddWithValue("@userID", userManager.GetUserID());
                    command.Parameters.AddWithValue("@elementID", ElementID);
                    command.Parameters.AddWithValue("@experience", 0);
                    command.Parameters.AddWithValue("@active", true);
                    command.Parameters.AddWithValue("@creationDate", DateTime.Today);
                    if (ElementID == 1)
                    {
                        command.Parameters.AddWithValue("@imagePath", "~/Images/water.jpg");
                    }
                    else if (ElementID == 2)
                    {
                        command.Parameters.AddWithValue("@imagePath", "~/Images/fire.png");
                    }
                    else if (ElementID == 3)
                    {
                        command.Parameters.AddWithValue("@imagePath", "~/Images/air.png");
                    }
                    else if (ElementID == 4)
                    {
                        command.Parameters.AddWithValue("@imagePath", "~/Images/earth.png");
                    }

                    int result = command.ExecuteNonQuery();
                }
            }
        }

        public int GetTitanExperience(string TitanName)
        {
            TitanManager obj = new TitanManager();

            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT experience FROM tblTitan WHERE userId=@userId AND titanId=@titanId", sqlConnection))
                {
                    var userManager = new UserManager();
                    sqlCommand.Parameters.AddWithValue("@userId", obj.GetTitanID(TitanName));
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return result;
                }
            }
        }

        public DataTable TitanList(string userName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                string sqlGetTitans = ";WITH cte AS(SELECT e.*, t.*, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName) SELECT* FROM cte WHERE rn = 1";
                SqlCommand cmdGetTitans = new SqlCommand(sqlGetTitans, sqlConnection);

                cmdGetTitans.Parameters.AddWithValue("@userName", userName);
                try
                {
                    SqlDataReader rd = cmdGetTitans.ExecuteReader();
                    dt.Load(rd);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }



        public DataTable TitanListWater(string userName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                string sqlGetTitans = ";WITH cte AS(SELECT e.*, t.*, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName AND elementID=1) SELECT* FROM cte WHERE rn = 1";
                SqlCommand cmdGetTitans = new SqlCommand(sqlGetTitans, sqlConnection);

                cmdGetTitans.Parameters.AddWithValue("@userName", userName);
                try
                {
                    SqlDataReader rd = cmdGetTitans.ExecuteReader();
                    dt.Load(rd);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }

        public DataTable TitanListFire(string userName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                string sqlGetTitans = ";WITH cte AS(SELECT e.*, t.*, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName AND elementID=2) SELECT* FROM cte WHERE rn = 1";
                SqlCommand cmdGetTitans = new SqlCommand(sqlGetTitans, sqlConnection);

                cmdGetTitans.Parameters.AddWithValue("@userName", userName);
                try
                {
                    SqlDataReader rd = cmdGetTitans.ExecuteReader();
                    dt.Load(rd);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }

        public DataTable TitanListAir(string userName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                string sqlGetTitans = ";WITH cte AS(SELECT e.*, t.*, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName AND elementID=3) SELECT* FROM cte WHERE rn = 1";
                SqlCommand cmdGetTitans = new SqlCommand(sqlGetTitans, sqlConnection);

                cmdGetTitans.Parameters.AddWithValue("@userName", userName);
                try
                {
                    SqlDataReader rd = cmdGetTitans.ExecuteReader();
                    dt.Load(rd);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }

        public DataTable TitanListEarth(string userName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                string sqlGetTitans = ";WITH cte AS(SELECT e.*, t.*, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName AND elementID=4) SELECT* FROM cte WHERE rn = 1";
                SqlCommand cmdGetTitans = new SqlCommand(sqlGetTitans, sqlConnection);

                cmdGetTitans.Parameters.AddWithValue("@userName", userName);
                try
                {
                    SqlDataReader rd = cmdGetTitans.ExecuteReader();
                    dt.Load(rd);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }

        public DataTable TitanListActive(string userName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                string sqlGetTitans = ";WITH cte AS(SELECT e.*, t.*, el.elementName, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u, tblElement el WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName = @userName AND t.active=@active AND el.elementID = t.elementID) SELECT* FROM cte WHERE rn = 1";
                SqlCommand cmdGetTitans = new SqlCommand(sqlGetTitans, sqlConnection);

                cmdGetTitans.Parameters.AddWithValue("@userName", userName);
                cmdGetTitans.Parameters.AddWithValue("@active", true);
                try
                {
                    SqlDataReader rd = cmdGetTitans.ExecuteReader();
                    dt.Load(rd);
                    return dt;               
                }
                catch
                {
                    throw;
                }
            }
        }

        public DataTable EnemyTitanList(string userName, string titanName)
        {
            var titanManager = new TitanManager();
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                string sqlGetTitans = ";WITH cte AS(SELECT t.*, e.*, el.elementName, u.userName, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn FROM tblExperience e, tblTitan t, tblUser u, tblElement el WHERE t.experience <= e.expMax AND u.username !=@userName AND u.userid = t.userid AND t.active = @active), test AS (SELECT * FROM(SELECT TOP 3 * FROM tblExperience WHERE @experience <= expMax ORDER BY expMax ASC) AS A1 UNION ALL SELECT * FROM(SELECT TOP 1 * FROM tblExperience WHERE @experience >= expMax ORDER BY expMax DESC) AS A2) SELECT TOP 4 * FROM cte INNER JOIN test ON cte.expId = test.expId WHERE rn = 1 ORDER BY cte.expId ASC;";
                SqlCommand cmdGetTitans = new SqlCommand(sqlGetTitans, sqlConnection);

                cmdGetTitans.Parameters.AddWithValue("@userName", userName);
                cmdGetTitans.Parameters.AddWithValue("@active", true);
                cmdGetTitans.Parameters.AddWithValue("@experience", titanManager.GetTitanExperience(titanName));
                try
                {
                    SqlDataReader rd = cmdGetTitans.ExecuteReader();
                    dt.Load(rd);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }

        public DataTable MatchHistoryTitanList(string userName, string titanName, int titanID)
        {
            var titanManager = new TitanManager();
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();
                string sqlGetTitans = ";WITH cte AS( SELECT e.*, t.*, el.elementName, u.userName, ROW_NUMBER() OVER(PARTITION BY t.titanID ORDER BY e.expMax, t.titanID ASC) AS rn  FROM tblExperience e, tblTitan t, tblUser u, tblElement el WHERE t.experience <= e.expMax AND u.userID = t.userID AND u.userName != @userName AND el.elementID = t.elementID),test AS (SELECT b.battleID, b.battler1, b.battler2, b.battleWinner FROM tblUser u, tblBattle b, tblElement el, tblTitan t WHERE u.userID = t.userID AND b.battler1=@titanID AND el.elementID = t.elementID AND (b.battler1=@titanID) OR (b.battler2=@titanID) AND titanName=@titanName GROUP BY battleId, battler1, battler2, battleWinner) SELECT*  FROM cte RIGHT JOIN test ON cte.titanId = test.battler2 OR cte.titanId = test.battler1 WHERE rn = 1 ORDER BY battleId";
                SqlCommand cmdGetTitans = new SqlCommand(sqlGetTitans, sqlConnection);

                cmdGetTitans.Parameters.AddWithValue("@titanName", titanName);
                cmdGetTitans.Parameters.AddWithValue("@userName", userName);
                cmdGetTitans.Parameters.AddWithValue("@titanID", titanID);
                try
                {
                    SqlDataReader rd = cmdGetTitans.ExecuteReader();
                    dt.Load(rd);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }


    }
}