using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees
{
    internal interface IDBM
    {
        void connect();

        void disconnect();

        void create_table();

        void data_fill(DataGridView dataGridView1);

        void insert(System.Windows.Forms.TextBox textBox1,
            System.Windows.Forms.TextBox textBox2,
            System.Windows.Forms.TextBox textBox3,
            DateTimePicker dateTimePicker1,
            DateTimePicker dateTimePicker2,
            System.Windows.Forms.ComboBox comboBox1);
    }
}
