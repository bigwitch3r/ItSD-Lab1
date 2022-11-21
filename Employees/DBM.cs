using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public void insert(System.Windows.Forms.TextBox textBox1,
            System.Windows.Forms.TextBox textBox2,
            System.Windows.Forms.TextBox textBox3,
            DateTimePicker dateTimePicker1,
            DateTimePicker dateTimePicker2,
            System.Windows.Forms.ComboBox comboBox1) 
        {
            SQLiteCommand cmd = new SQLiteCommand(
                    "insert into Persons (lastname, firstname, middlename," +
            "birthdate, worksfrom, gender) values ('" +
            textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" +
            dateTimePicker1.Value.ToShortDateString() + "','" +
                    dateTimePicker2.Value.ToShortDateString() + "','" +
                    comboBox1.Text + "')", cnn);

            cmd.ExecuteNonQuery();
        }

        public void delete(string id)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "delete from Persons where id = " + id, cnn);
            cmd.ExecuteNonQuery();
        }

        public void update_table(string id,
            System.Windows.Forms.TextBox textBox1,
            System.Windows.Forms.TextBox textBox2,
            System.Windows.Forms.TextBox textBox3,
            DateTimePicker dateTimePicker1,
            DateTimePicker dateTimePicker2,
            System.Windows.Forms.ComboBox comboBox1)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "update Persons set lastname = '" + textBox1.Text + "'," +
                               "firstname = '" + textBox2.Text + "'," +
                               "middlename = '" + textBox3.Text + "'," +
                               "birthdate = '" + dateTimePicker1.Value.ToShortDateString() + "'," +
                               "worksfrom = '" + dateTimePicker2.Value.ToShortDateString() + "', " +
                               "gender = '" + comboBox1.Text + "' " +
                               "where id = " + id, cnn);
            cmd.ExecuteNonQuery();
        }
    }
}
