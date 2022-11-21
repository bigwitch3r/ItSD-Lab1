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

        void insert_emplyee(Employee employee);
    }
}
