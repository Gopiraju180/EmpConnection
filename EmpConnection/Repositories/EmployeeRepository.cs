
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmpConnection
{
    public class EmployeeRepository : IEmployeeRepository
    {
        string connectionString = "data source=DESKTOP-LNEME22;integrated security=yes;Encrypt=True;TrustServerCertificate=True;initial catalog=hotelmanagement";
        public async Task<bool> AddEmployee(Employee empdetail)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_AddEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empname", empdetail.empname);
                cmd.Parameters.AddWithValue("@empsalary", empdetail.empsalary);
                conn.Open();//we must open the connection manually
                await cmd.ExecuteNonQueryAsync();
                conn.Close();//we mus close the connection
            }
            return true;
        }

        public async Task<bool> DeleteEmployeeByEmpid(int empid)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_DeleteEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }
            return true;
               
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            List<Employee> lstemp = new List<Employee>();
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetEmployee", conn);
                    cmd.CommandType= CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.empid = Convert.ToInt32(reader["empid"]);
                        emp.empname = Convert.ToString(reader["empname"]);
                        emp.empsalary = Convert.ToInt32(reader["empsalary"]);
                        lstemp.Add(emp);
                    }
                    conn.Close();
                    
                }
                return lstemp;
            }   
        }

        public async Task<Employee> GetEmployeeByEmpid(int empid)
        {
           Employee emp=new Employee();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Usp_GetEmployeeId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.empid = Convert.ToInt32(dr["empid"]);
                    emp.empname = Convert.ToString(dr["empname"]);
                    emp.empsalary = Convert.ToInt32(dr["empsalary"]);
                }
                conn.Close();
            }
            return emp;
        }

        public async Task<bool> UpdateEmployee(Employee empdetail)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
               
                SqlCommand cmd = new SqlCommand("Usp_UpdateEmployee", conn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid",empdetail.empid);
                cmd.Parameters.AddWithValue("@empname", empdetail.empname);
                cmd.Parameters.AddWithValue("@empsalary", empdetail.empsalary);
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }
            return true;
        }
    }
}
