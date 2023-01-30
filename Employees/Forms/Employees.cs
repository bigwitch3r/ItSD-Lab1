using System;
using System.Data;
using System.Data.Entity;
using System.Windows.Forms;
using Employees.Forms;

namespace Employees
{
    public partial class Employees : Form
    {
        EmployeesDbManager employeesDbManager = new EmployeesDbManager();

        public Employees()
        {
            InitializeComponent();

            string command = "create table if not exists Employees (id integer primary key, lastname text not null, firstname text not null, middlename text not null, birthdate text not null, worksfrom text not null, gender text not null, post text not null);";
            employeesDbManager.execCommand(command);

            dataGridView1.DataSource = employeesDbManager.QueryTable();

            using (EmployeeDb db = new EmployeeDb())
            {
                Employee employee = new Employee 
                { 
                    LastName = "Гончаров", 
                    FirstName = "Данил", 
                    MiddleName = "Алексеевич", 
                    Birthdate = "10.10.2001", 
                    WorksFrom = "10.10.2020", 
                    Gender = "М", 
                    Post = "Студент"
                };

                db.Employees.Add(employee);
                db.SaveChanges();

                dataGridView1.DataSource = db.Employees.Local.ToBindingList();
            }

            form_setting();
        }

        private int time_validation()
        {
            TimeSpan ts = dateTimePicker2.Value - dateTimePicker1.Value;

            if ((ts.TotalDays / 365) < 14 || dateTimePicker1.Value.Year < 1900
                || dateTimePicker2.Value > DateTime.Now)
            {
                MessageBox.Show("Неправильно введены даты!");
                return 0;
            }
            return 1;
        }

        private void form_setting()
        {
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].Width = 40;
            dataGridView1.Columns[4].HeaderText = "Пол";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[5].HeaderText = "Д.р.";
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[6].HeaderText = "С";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[6].HeaderText = "Должность";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            int valid = time_validation();

            if (valid == 1)
            {
                string command = "insert into Employees (lastname, firstname, middlename," +
                    "birthdate, worksfrom, gender, post) values ('" +
                    textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" +
                    dateTimePicker1.Value.ToShortDateString() + "','" +
                    dateTimePicker2.Value.ToShortDateString() + "','" +
                    comboBox1.Text + "','" + textBox4.Text + "')";

                employeesDbManager.execCommand(command);
                dataGridView1.DataSource = employeesDbManager.QueryTable();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string command = $"delete from Employees where id = {id}";
            employeesDbManager.execCommand(command);

            dataGridView1.DataSource = employeesDbManager.QueryTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Проверка правильности дат
            TimeSpan ts = dateTimePicker2.Value - dateTimePicker1.Value;
            if ((ts.TotalDays / 365) < 14 || dateTimePicker1.Value.Year < 1900
                || dateTimePicker2.Value > DateTime.Now)
            {
                MessageBox.Show("Неправильно введены даты !");
                return;
            }

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string command = "update Employees set lastname = '" + textBox1.Text + "'," +
                "firstname = '" + textBox2.Text + "'," +
                "middlename = '" + textBox3.Text + "'," +
                "birthdate = '" + dateTimePicker1.Value.ToShortDateString() + "'," +
                "post = '" + textBox4.Text + "'," +
                "worksfrom = '" + dateTimePicker2.Value.ToShortDateString() + "', " +
                "gender = '" + comboBox1.Text + "' " +
                "where id = " + id;
            employeesDbManager.execCommand(command);

            dataGridView1.DataSource = employeesDbManager.QueryTable();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch { };
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DateTime now = DateTime.Now;
            DateTime born = DateTime.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            DateTime from = DateTime.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            Boolean man = dataGridView1.CurrentRow.Cells[4].Value.ToString() == "М";
            DateTime toPens;
            if (man)
                toPens = born.AddYears(60);
            else
                toPens = born.AddYears(55);
            MessageBox.Show("Возраст : " + 
                (Convert.ToInt32((now - born).TotalDays / 365)).ToString() +
                "\nВыход на пенсию : " + toPens.ToShortDateString() +
                "\nСтаж работы (лет) : " + 
                (Convert.ToInt32((now - from).TotalDays / 365)).ToString() + 
                "\n" + (now > toPens ? "На" : "До") + " пенсии (лет) : " + 
                (Convert.ToInt32((now > toPens ? (now - toPens) :
                    (toPens - now)).TotalDays / 365)).ToString(), 
                dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " +
                dataGridView1.CurrentRow.Cells[2].Value.ToString().Substring(0,1)+"." +
                dataGridView1.CurrentRow.Cells[3].Value.ToString().Substring(0,1)+".");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Statistics frm = new Statistics();
            frm.dt = (DataTable)dataGridView1.DataSource;
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Payments form3 = new Payments();
            form3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ndfl ndfl = new Ndfl();
            ndfl.Show();
        }
    }
}
