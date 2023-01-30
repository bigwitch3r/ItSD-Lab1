using PrtScDisable;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PrtScDisable;

namespace Employees
{
    public partial class Payments : Form
    {
        RulesDbManager rulesDbManager = new RulesDbManager();
        EmployeesDbManager employeesDbManager = new EmployeesDbManager();
        PaymentsDbManager paymentsDbManager = new PaymentsDbManager();

        Calculator calculator = new Calculator();

        public Payments()
        {
            InitializeComponent();
            string rulesCreate = "create table if not exists Rules1(id integer primary key, post text not null, perhour integer not null, oklad integer not null);";
            rulesDbManager.execCommand(rulesCreate);

            string paymentsCreate = "create table if not exists Payments1 (id integer primary key, emp_id text not null, salary integer not null, ndfl text not null, date text not null);";
            paymentsDbManager.execCommand(paymentsCreate);

            dataGridView1.DataSource = rulesDbManager.QueryTable();
            dataGridView2.DataSource = paymentsDbManager.QueryTable();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string post = employeesDbManager.GetPost(Convert.ToInt32(textBox1.Text));
            int rate = rulesDbManager.GetRate(post);

            int hours = Convert.ToInt32(textBox2.Text);

            if (rate > 9999)
            {
                double coefficient = Convert.ToDouble(textBox7.Text) / Convert.ToDouble(textBox8.Text);
                double salary = rate * coefficient;
                textBox3.Text = salary.ToString();
            }
            else
            {
                int salary = calculator.SalaryCalculation(hours, rate);
                textBox3.Text = salary.ToString();
            }

            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string addRule = $"insert into Rules1 (post, perhour, oklad) values ('{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}')";
            rulesDbManager.execCommand(addRule);

            dataGridView1.DataSource = rulesDbManager.QueryTable();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string deleteRule = $"delete from Rules1 where id = {id.ToString()}";
            rulesDbManager.execCommand(deleteRule);

            dataGridView1.DataSource = rulesDbManager.QueryTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int salary = Convert.ToInt32(Math.Round(Convert.ToDouble(textBox3.Text)));
            double ndfl = calculator.NdflCalculation(salary);

            DateTime dateTime = DateTime.Today;
            string date = dateTime.ToShortDateString();

            string makePayment = $"insert into Payments1 (emp_id, salary, ndfl, date) values ('{textBox1.Text}', '{salary.ToString()}', '{ndfl.ToString()}', '{date}')";
            paymentsDbManager.execCommand(makePayment);

            dataGridView2.DataSource = paymentsDbManager.QueryTable();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
