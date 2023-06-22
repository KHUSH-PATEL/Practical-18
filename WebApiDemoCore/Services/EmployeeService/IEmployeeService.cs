using Microsoft.AspNetCore.Mvc;
using WebApiDemoCore.Models;

namespace WebApiDemoCore.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetEmployee();
        EmployeeDto GetEmployee(int id);
        void AddEmployee([FromBody] EmployeeDto empDto);
        Employee? EditEmployee(int id, [FromBody] EmployeeDto empDto);
        Employee DeleteEmployee(int id);
    }
}
