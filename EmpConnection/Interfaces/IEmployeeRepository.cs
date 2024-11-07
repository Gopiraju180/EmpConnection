

namespace EmpConnection
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployee();
        Task<Employee> GetEmployeeByEmpid(int empid);
        Task<bool> AddEmployee(Employee empdetail);
        Task<bool> UpdateEmployee(Employee empdetail);
        Task<bool> DeleteEmployeeByEmpid(int empid);
    }
}
