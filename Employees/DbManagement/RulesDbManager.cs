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

            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, post, perhour, oklad from Rules1", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Connection.Close();

            return ds.Tables[0];
        }

        public int GetRate(string post)
        {
            Connection.Open();

            int result = 0;

            int rate = 0;
            int oklad = 0;

            SQLiteCommand command = Connection.CreateCommand();
            command.CommandText = $"select perhour from Rules1 where post = '{post}'";

            SQLiteCommand command1 = Connection.CreateCommand();
            command1.CommandText = $"select oklad from Rules1 where post = '{post}'";

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                rate = Convert.ToInt32(reader["perhour"]);
            }

            SQLiteDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                oklad = Convert.ToInt32(reader1["oklad"]);
            }

            Connection.Close();

            if (oklad == 0)
            {
                result = rate;
            }
            else
            {
                result = oklad;
            }

            return result;
        }
    }
}
