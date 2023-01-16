using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees
{
    public class SalaryDbm : IDBM
    {
        private SQLiteConnection cnn;
        public void connect()
        {
            cnn = new SQLiteConnection("Data Source=SalaryRules.txt");
            cnn.Open();
        }

        public void create_table()
        {
            SQLiteCommand command = cnn.CreateCommand();
            command.CommandText = "create table if not exists Employees (id integer primary key, lastname text not null, firstname text not null, middlename text not null, birthdate text not null, worksfrom text not null, gender text not null, post text not null);";
            command.ExecuteNonQuery();
        }

        public void data_fill(DataGridView dataGridView1)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, lastname, firstname, middlename, gender," +
                "birthdate, worksfrom, post from Employees", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        public void delete(string id)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "delete from Employees where id = " + id, cnn);
            cmd.ExecuteNonQuery();
        }

        public void disconnect()
        {
            cnn.Close();
        }

        public void insert(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, DateTimePicker dateTimePicker1, DateTimePicker dateTimePicker2, ComboBox comboBox1)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                    "insert into Employees (lastname, firstname, middlename," +
            "birthdate, worksfrom, gender, post) values ('" +
            textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" +
            dateTimePicker1.Value.ToShortDateString() + "','" +
                    dateTimePicker2.Value.ToShortDateString() + "','" +
                    comboBox1.Text + "','" + textBox4.Text + "')", cnn);

            cmd.ExecuteNonQuery();
        }

        public void update_table(string id, TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, DateTimePicker dateTimePicker1, DateTimePicker dateTimePicker2, ComboBox comboBox1)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "update Employees set lastname = '" + textBox1.Text + "'," +
                               "firstname = '" + textBox2.Text + "'," +
                               "middlename = '" + textBox3.Text + "'," +
                               "birthdate = '" + dateTimePicker1.Value.ToShortDateString() + "'," +
                               "post = '" + textBox4.Text + "'," +
                               "worksfrom = '" + dateTimePicker2.Value.ToShortDateString() + "', " +
                               "gender = '" + comboBox1.Text + "' " +
                               "where id = " + id, cnn);
            cmd.ExecuteNonQuery();
        }
    }
}
