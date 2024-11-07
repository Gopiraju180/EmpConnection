
namespace EmpConnection
{
    public class EmployeeServices : IEmployeeServices
    {
        //by using interfaces we can implement loosely copuled architecture
        IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)//here inject IEmployeeRepository
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> AddEmployee(EmployeeDto empdetail)
        {
            Employee empobj=new Employee();
            empobj.empid = empdetail.empid;
            empobj.empname= empdetail.empname;
            empobj.empsalary= empdetail.empsalary;
            await _employeeRepository.AddEmployee(empobj);
            return true;
        }

        public async Task<bool> DeleteEmployeeByEmpid(int empid)
        {
            await _employeeRepository.DeleteEmployeeByEmpid(empid);
            return true;
        }

        public async Task<List<EmployeeDto>> GetAllEmployee()
        {
            List<EmployeeDto> listempdto = new List<EmployeeDto>();
            var emp=await _employeeRepository.GetAllEmployee();
            foreach(Employee empobj in emp)
            {
                EmployeeDto empdto=new EmployeeDto();
                empdto.empid=empobj.empid;
                empdto.empname= empobj.empname;
                empdto.empsalary = empobj.empsalary;
                listempdto.Add(empdto);
            }
            return listempdto;
        }

        public async  Task<EmployeeDto> GetEmployeeByEmpid(int empid)
        {
            var empobj = await _employeeRepository.GetEmployeeByEmpid(empid);
            EmployeeDto empdto=new EmployeeDto();
            empdto.empid = empobj.empid;
            empdto.empname = empobj.empname;
            empdto.empsalary=empobj.empsalary;
            return empdto;
        }

        public async Task<bool> UpdateEmployee(EmployeeDto empdetail)
        {
            Employee empobj=new Employee();
            empobj.empid = empdetail.empid;
            empobj.empname = empdetail.empname;
            empobj.empsalary= empdetail.empsalary;
            await _employeeRepository.UpdateEmployee(empobj);
            return true;
        }
    }
}
