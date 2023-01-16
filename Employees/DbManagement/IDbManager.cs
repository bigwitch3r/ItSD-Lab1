using System.Data;

namespace Employees
{
    internal interface IDbManager
    {
        DataTable QueryTable();
        void execCommand(string sql);
    }
}
