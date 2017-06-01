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
    public class BattleDAL
    {
       
        string DBConn = ConfigurationManager.ConnectionStrings["udbBetterConnectionString"].ConnectionString;

        DataTable dt = new DataTable();

        public void AddBattle(string TitanName1, string TitanName2, bool battleWinner)
        {
            var titan = new TitanManager();
            var enemyTitan = new EnemyTitanManager();
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();

                using (SqlCommand command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO tblBattle (battler1, battler2, battleTime, battleWinner) VALUES (@battler1, @battler2, @battleTime, @battleWinner)";

                    command.Parameters.AddWithValue("@battler1", titan.GetTitanID(TitanName1));
                    command.Parameters.AddWithValue("@battler2", enemyTitan.GetEnemyTitanID(TitanName2));
                    command.Parameters.AddWithValue("@battleWinner", battleWinner);
                    command.Parameters.AddWithValue("@battleTime", DateTime.Today);

                    command.ExecuteNonQuery();
                }
            }
        }
        
    }
}