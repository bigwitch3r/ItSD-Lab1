using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class RulesDbManager : IDbManager
    {
        public SQLiteConnection Connection;

        public RulesDbManager() 
        {
            Connection = new SQLiteConnection("Data Source=SalaryRules.txt");
        }

        public void execCommand(string sql)
        {
            Connection.Open();

            SQLiteCommand command = Connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            Connection.Close();
        }

        public DataTable QueryTable()
        {
            Connection.Open();

            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, post, perhour from Rules", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Connection.Close();

            return ds.Tables[0];
        }

        public int GetRate(string post)
        {
            Connection.Open();

            int rate = 0;

            SQLiteCommand command = Connection.CreateCommand();
            command.CommandText = $"select perhour from Rules where post = '{post}'";

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                rate = Convert.ToInt32(reader["perhour"]);
            }

            Connection.Close();

            return rate;
        }
    }
}
