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
    public class RulesDbm
    {
        private SQLiteConnection cnn;

        public void connect()
        {
            cnn = new SQLiteConnection("Data Source=SalaryRules.txt");
            cnn.Open();
        }

        public void disconnect()
        {
            cnn.Close();
        }

        public void pay(TextBox textBox1, TextBox textBox3, DataGridView dataGridView2)
        {
            double ndfl = Convert.ToInt32(textBox3.Text) * 0.13;
            SQLiteCommand command = cnn.CreateCommand();
            string date = "16.01.2023";
            command.CommandText = $"insert into Payments1 (emp_id, salary, ndfl, date) values ('{textBox1.Text}', '{textBox3.Text}', '{ndfl.ToString()}', '{date}')";
            command.ExecuteNonQuery();

            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, emp_id, salary, ndfl, date from Payments1", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

        }

        public void create_table()
        {
            SQLiteCommand command = cnn.CreateCommand();
            command.CommandText = "create table if not exists Rules(id integer primary key, post text not null, perhour integer not null);";
            command.ExecuteNonQuery();

            SQLiteCommand command1 = cnn.CreateCommand();
            command1.CommandText = "create table if not exists Payments1 (id integer primary key, emp_id text not null, salary integer not null, ndfl text not null, date text not null);";
            command1.ExecuteNonQuery();
        }

        public void insert_rule(TextBox textBox4, TextBox textBox5)
        {
            SQLiteCommand command = cnn.CreateCommand();
            command.CommandText = $"insert into Rules (post, perhour) values ('{textBox4.Text}', '{textBox5.Text}')";
            command.ExecuteNonQuery();
        }

        public void delete_rule(string id)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "delete from Rules where id = " + id, cnn);
            cmd.ExecuteNonQuery();
        }

        public void data_fill(DataGridView dataGridView1)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, post, perhour from Rules", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        public void SalaryCalculate(TextBox textbox1, TextBox textBox2, TextBox textBox3)
        {
            SQLiteCommand command = cnn.CreateCommand();
            command.CommandText = $"select post from Employees where id = {textbox1.Text}";

            SQLiteDataReader reader = command.ExecuteReader();

            string result = "";

            while (reader.Read())
            {
                result = reader["post"].ToString();
            }

            SQLiteCommand command1 = cnn.CreateCommand();
            command1.CommandText = $"select perhour from Rules where post = '{result}'";

            SQLiteDataReader reader1 = command1.ExecuteReader();

            int perhour = 0;

            while (reader1.Read())
            {
                perhour = Convert.ToInt32(reader1["perhour"]);
            }

            textBox3.Text = (perhour * Convert.ToInt32(textBox2.Text)).ToString();
        }
    }
}
