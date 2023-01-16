using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees
{
    public partial class Form3 : Form
    {
        RulesDbm dbm = new RulesDbm();
        public Form3()
        {
            InitializeComponent();
            dbm.connect();
            dbm.create_table();
            dbm.data_fill(dataGridView1);
            dbm.disconnect();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbm.connect();

            dbm.SalaryCalculate(textBox1, textBox2, textBox3);

            dbm.disconnect();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbm.connect();
            dbm.insert_rule(textBox4, textBox5);
            dbm.data_fill(dataGridView1);
            dbm.disconnect();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            dbm.connect();
            dbm.delete_rule(id);
            dbm.data_fill(dataGridView1);
            dbm.disconnect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbm.connect();
            dbm.pay(textBox1, textBox3, dataGridView2);
            dbm.disconnect();
        }
    }
}
