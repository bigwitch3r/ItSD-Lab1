using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees.Forms
{
    public partial class Ndfl : Form
    {
        PaymentsDbManager paymentsDbManager = new PaymentsDbManager();
        public Ndfl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double result = paymentsDbManager.CalculateNdfl(Convert.ToInt32(textBox1.Text));
            textBox2 .Text = result.ToString();
        }
    }
}
