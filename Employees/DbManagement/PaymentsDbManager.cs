using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal class PaymentsDbManager : IDbManager
    {
        public SQLiteConnection Connection;
        public PaymentsDbManager() 
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

            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, emp_id, salary, ndfl, date from Payments1", Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Connection.Close();

            return ds.Tables[0];
        }
    }
}
