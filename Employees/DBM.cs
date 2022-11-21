using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees
{
    internal class DBM : IDBM
    {
        private SQLiteConnection cnn;
        public void connect()
        {
            cnn = new SQLiteConnection("Data Source=Employees.sqlite3");
            cnn.Open();
        }

        public void disconnect()
        {
            cnn.Close();
        }

        public void create_table()
        {
            SQLiteCommand command = cnn.CreateCommand();
            command.CommandText = "create table if not exists Persons (id integer primary key, lastname text not null, firstname text not null, middlename text not null, birthdate text not null, worksfrom text not null, gender text not null);";
            command.ExecuteNonQuery();
        }

        public void data_fill(DataGridView dataGridView1)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, lastname, firstname, middlename,gender," +
                "birthdate, worksfrom from Persons", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        public void insert_employee(Employee employee) 
        {

        }
    }
}
