
namespace EmpConnection.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        IEmployeeRepository _employeerepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeerepository = employeeRepository;
        }
        public async Task<bool> AddEmployee(EmployeeDto empdetail)
        {
            Employee empobj = new Employee();
            empobj.empid = empdetail.empid;
            empobj.empname = empdetail.empname;
            empobj.empsalary = empdetail.empsalary;
            await _employeerepository.AddEmployee(empobj);
            return true;
        }

        public async Task<bool> DeleteEmployeeByEmpid(int empid)
        {
            await _employeerepository.DeleteEmployeeByEmpid(empid);
            return true;
        }

        public async  Task<List<EmployeeDto>> GetAllEmployee()
        {
            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            var emp = await _employeerepository.GetAllEmployee();
            foreach (Employee empobj in emp)
            {
                EmployeeDto empdto = new EmployeeDto();
                empdto.empid = empobj.empid;
                empdto.empname = empobj.empname;
                empdto.empsalary = empobj.empsalary;
                lstempdto.Add(empdto);
            }
            return lstempdto;
        }

        public async  Task<EmployeeDto> GetEmployeeByEmpid(int empid)
        {
            var empobj = await _employeerepository.GetEmployeeByEmpid(empid);
            EmployeeDto empdto = new EmployeeDto();
            empdto.empid = empobj.empid;
            empdto.empname = empobj.empname;
            empdto.empsalary = empobj.empsalary;
            return empdto;

        }

        public async Task<bool> UpdateEmployee(EmployeeDto empdetail)
        {
            Employee empobj = new Employee();
            empobj.empid = empdetail.empid;
            empobj.empname = empdetail.empname;
            empobj.empsalary = empdetail.empsalary;
            await _employeerepository.UpdateEmployee(empobj);
            return true;
        }
    }
}
