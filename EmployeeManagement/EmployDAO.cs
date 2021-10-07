using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    class EmployDAO
    {
        String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        public List<Employee> SelectAll()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open(); 
            String strCom = "SELECT * FROM Employee";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Employee employee = new Employee()
                {
                    ID = (int)dr["ID"],
                    Name = (String)dr["Name"],
                    Address = (String)dr["Address"],
                    Salary = (int)dr["Salary"],
                    Age = (int)dr["Age"],
                };
                employees.Add(employee);   
            }
            con.Close();
            return employees;
        }
    }
}
