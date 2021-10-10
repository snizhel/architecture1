using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Employee> employees = new EmployBUS().GetAll();
            GrdEmploy.DataSource = employees;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<Employee> employees = new EmployBUS().Search(keyword);
            GrdEmploy.DataSource = employees;
        }

        private void GrdEmploy_SelectionChanged(object sender, EventArgs e)
        {
            if (GrdEmploy.SelectedRows.Count >0) {  
                int id=int.Parse(GrdEmploy.SelectedRows[0].Cells["ID"].Value.ToString()); 
                Employee emp=new EmployBUS().GetEmployee(id);
                if(emp != null) {
                    txtID.Text = emp.ID.ToString();
                    txtName.Text = emp.Name;
                    txtAddress.Text = emp.Address;
                    txtAge.Text = emp.Age.ToString();
                    txtSalary.Text = emp.Salary.ToString();
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                ID = 0,
                Name = txtName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Age = int.Parse(txtAge.Text.Trim()),
                Salary = int.Parse(txtSalary.Text.Trim()),

            };
            bool result=new EmployBUS().Add(employee);
            if(result)
            {
                List<Employee> list = new EmployBUS().GetAll();
                GrdEmploy.DataSource = list;

            }else
            {
                MessageBox.Show("no value");
            }    
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                ID = int.Parse(txtID.Text.Trim()),
                Name = txtName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Age = int.Parse(txtAge.Text.Trim()),
                Salary = int.Parse(txtSalary.Text.Trim()),

            };
            bool result = new EmployBUS().Update(employee);
            if (result)
            {
                List<Employee> list = new EmployBUS().GetAll();
                GrdEmploy.DataSource = list;

            }
            else
            {
                MessageBox.Show("no value");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?","CONFIRMATION",MessageBoxButtons.YesNo);
            if( result== DialogResult.Yes)
            {
                int ID=int.Parse(txtID.Text.Trim());
                bool res=new EmployBUS().Delete(ID);
                if (res)
                {
                    List<Employee> list = new EmployBUS().GetAll();
                    GrdEmploy.DataSource = list;

                }
                else
                {
                    MessageBox.Show("no value");
                }
            }
        }
    }
}
