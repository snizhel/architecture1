using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    class EmployBUS
    {
        public List<Employee> GetAll()
        {
            List<Employee> employees = new EmployDAO().SelectAll();
            return employees;
        }
    }
}
