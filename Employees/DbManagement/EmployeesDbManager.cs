using System.Data;
using System.Data.SQLite;

namespace Employees
{
    public class EmployeesDbManager : IDbManager
    {
        public SQLiteConnection Connection;

        public EmployeesDbManager()
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

            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, lastname, firstname, middlename, gender," +
                "birthdate, worksfrom, post from Employees", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Connection.Close();

            return ds.Tables[0];
        }

        public string GetPost(int id)
        {
            Connection.Open();

            string post = "";

            SQLiteCommand command = Connection.CreateCommand();
            command.CommandText = $"select post from Employees where id = {id.ToString()}";

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                post = reader["post"].ToString();
            }

            Connection.Close();

            return post;
        }
    }
}
