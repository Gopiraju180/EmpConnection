using EmpConnection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)//constructor injection
        {
            _employeeServices= employeeServices;//assigning reference variables
        }

        [HttpPost]
        [Route("AddEmployee")]//routename describe here.
        public async Task<IActionResult> Post([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {//oldway:var result=obj.AddEmployee(empdto);
                    var employeeData = await _employeeServices.AddEmployee(empdto);
                    return StatusCode(StatusCodes.Status201Created, "employee added sucessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

        [HttpDelete]
        [Route("DeleteEmployeeByEmpid")]
        public async Task<IActionResult> delete(int empid)
        {
            if (empid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var res = await _employeeServices.DeleteEmployeeByEmpid(empid);
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "content deleted successfully");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

        [HttpPut]//update the data purpose we are used.
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var res = await _employeeServices.UpdateEmployee(empdto);
                    return StatusCode(StatusCodes.Status201Created, "employee updated sucessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var empdata = await _employeeServices.GetAllEmployee();
                if (empdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
