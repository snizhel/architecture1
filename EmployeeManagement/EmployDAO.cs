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
        //String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        MyDBDataContext db=new MyDBDataContext(ConfigurationManager.ConnectionStrings["strcon"].ConnectionString);
        public List<Employee> SelectAll()
        {
            //List<Employee> employees = new List<Employee>();
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open(); 
            //String strCom = "SELECT * FROM Employee";
            //SqlCommand com = new SqlCommand(strCom, con);
            //SqlDataReader dr = com.ExecuteReader();
            //while (dr.Read())
            //{
            //    Employee employee = new Employee()
            //    {
            //        ID = (int)dr["ID"],
            //        Name = (String)dr["Name"],
            //        Address = (String)dr["Address"],
            //        Salary = (int)dr["Salary"],
            //        Age = (int)dr["Age"],
            //    };
            //    employees.Add(employee);   
            //}
            //con.Close();
            //return employees;
            db.ObjectTrackingEnabled = false;
            List<Employee> employees =db.Employees.ToList();
            return employees;
        }
        public List<Employee> SelectByKeyword(String keyword)
        {
            //List<Employee> employees = new List<Employee>();
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "SELECT * FROM Employee WHERE Name LIKE @Keyword";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Keyword","%"+keyword+"%"));
            //SqlDataReader dr = com.ExecuteReader();
            //while (dr.Read())
            //{
            //    Employee emp = new Employee()
            //    {
            //        ID = (int)dr["ID"],
            //        Name = (String)dr["Name"],
            //        Address = (String)dr["Address"],
            //        Salary = (int)dr["Salary"],
            //        Age = (int)dr["Age"],
            //    };
            //    employees.Add(emp);
            //}
            //con.Close();
            //return employees;
            List<Employee> employees=db.Employees.Where(x=>x.Name.Contains(keyword)).ToList();
            return employees;
        }
         public Employee SelectByCode(int ID)
        {
            //Employee employee = null;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "SELECT * FROM Employee WHERE ID=@ID";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@ID", ID));
            //SqlDataReader dr=com.ExecuteReader();
            //if (dr.Read())
            //{
            //    employee = new Employee()
            //    {
            //        ID = (int)dr["ID"],
            //        Name = (String)dr["Name"],
            //        Address = (String)dr["Address"],
            //        Salary = (int)dr["Salary"],
            //        Age = (int)dr["Age"],
            //    };
            //}
            //con.Close();
            //return employee;
            Employee employee = db.Employees.SingleOrDefault(x => x.ID == ID);
            return employee;
        }
        public bool Insert(Employee emp)
        {
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "INSERT INTO Employee(Name,Address,Salary,Age) VALUES(@Name,@Address,@Salary,@Age)";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Name", emp.Name));
            //com.Parameters.Add(new SqlParameter("@Address", emp.Address));
            //com.Parameters.Add(new SqlParameter("@Salary", emp.Salary));
            //com.Parameters.Add(new SqlParameter("@Age", emp.Age));

            //try
            //{
            //    result = com.ExecuteNonQuery() > 0;
            //}
            //catch
            //{
            //    result = false;
            //}
            //con.Close();
            //return result;
            try { 
                db.Employees.InsertOnSubmit(emp);
                db.SubmitChanges();
                return true;
            } catch
            {
                return false;
            }
        }
        public bool Update(Employee emp)
        {
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom ="UPDATE Employee SET Name=@Name,Address=@Address,Salary=@Salary,Age=@Age WHERE ID=@ID";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("ID", emp.ID));
            //com.Parameters.Add(new SqlParameter("@Name", emp.Name));
            //com.Parameters.Add(new SqlParameter("@Address", emp.Address));
            //com.Parameters.Add(new SqlParameter("@Salary", emp.Salary));
            //com.Parameters.Add(new SqlParameter("@Age", emp.Age));
            //try
            //{
            //    result = com.ExecuteNonQuery() > 0;
            //}
            //catch
            //{
            //    result = false;
            //}
            //con.Close();
            //return result;
            Employee employee=db.Employees.SingleOrDefault(x=>x.ID == emp.ID);
            if (employee != null)
            {
                try
                {
                    employee.Name = emp.Name;
                    employee.Salary = emp.Salary;
                    employee.Address = emp.Address;
                    employee.Age = emp.Age;
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
               
            }
            return false;
        }
        public bool Delete(int id)
        {
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "DELETE FROM Employee WHERE ID=@ID";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("ID",id));
            //try
            //{
            //    result = com.ExecuteNonQuery() > 0;
            //}
            //catch
            //{
            //    result = false;
            //}
            //con.Close();
            //return result;
            Employee employee = db.Employees.SingleOrDefault(x => x.ID == id);
            if(employee != null)
            {
                try
                {
                    db.Employees.DeleteOnSubmit(employee);
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
