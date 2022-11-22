using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Employees
{
    internal class MySQL_DBM : IDBM
    {
        string connection_string = "server=localhost;user=root;database=people;password=0000;";
        private MySqlConnection conn;
        public void connect()
        {
            conn = new MySqlConnection(connection_string);
            conn.Open();
        }

        public void disconnect()
        {
            conn.Close();
        }

        public void create_table()
        {
            string sql = "create table if not exists Persons (id integer primary key, lastname text not null, firstname text not null, middlename text not null, birthdate text not null, worksfrom text not null, gender text not null);";
            MySqlCommand command = new MySqlCommand(sql, conn);
            string result = command.ExecuteScalar().ToString();
        }

        public void update_table(string id,
            System.Windows.Forms.TextBox textBox1,
            System.Windows.Forms.TextBox textBox2,
            System.Windows.Forms.TextBox textBox3,
            DateTimePicker dateTimePicker1,
            DateTimePicker dateTimePicker2,
            System.Windows.Forms.ComboBox comboBox1)
        {

        }

        public void data_fill(DataGridView dataGridView1)
        {

        }

        public void insert(System.Windows.Forms.TextBox textBox1,
            System.Windows.Forms.TextBox textBox2,
            System.Windows.Forms.TextBox textBox3,
            DateTimePicker dateTimePicker1,
            DateTimePicker dateTimePicker2,
            System.Windows.Forms.ComboBox comboBox1)
        {

        }

        public void delete(string id)
        {

        }
    }
}
