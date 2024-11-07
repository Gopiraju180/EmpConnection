namespace EmpConnection
{
    public interface IEmployeeServices
    {
        Task<List<EmployeeDto>> GetAllEmployee();
        Task<EmployeeDto> GetEmployeeByEmpid(int empid);
        Task<bool> AddEmployee(EmployeeDto empdetail);
        Task<bool> UpdateEmployee(EmployeeDto empdetail);
        Task<bool> DeleteEmployeeByEmpid(int empid);
    }
}
