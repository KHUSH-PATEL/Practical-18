using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemoCore.Data;
using WebApiDemoCore.Models;

namespace WebApiDemoCore.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IMapper _mapper;

        public EmployeeService(EmployeeDbContext employeeDbContext, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _mapper = mapper;
        }
        public void AddEmployee([FromBody] EmployeeDto empDto)
        {
            var emp = _mapper.Map<Employee>(empDto);
            _employeeDbContext.Employees.Add(emp);
            _employeeDbContext.SaveChanges();
        }

        public Employee DeleteEmployee(int id)
        {
            var data = _employeeDbContext.Employees.Find(id);
            if(data != null)
            {
                _employeeDbContext.Employees.Remove(data);
                _employeeDbContext.SaveChanges();
                return data;
            }
            else
            {
                return data;
            }
        }

        public Employee? EditEmployee(int id, EmployeeDto emp)
        {
            var result = _employeeDbContext.Employees.Find(id);
            if(result == null)
            {
                return result;
            }
            else
            {
                result.Name = emp.Name;
                result.Gender = emp.Gender;
                result.Salary = emp.Salary;
                result.DepartmentId = emp.DepartmentId;
                _employeeDbContext.Entry(result).State = EntityState.Modified;
                //_employeeDbContext.Update(employee);
                _employeeDbContext.SaveChanges();
                return result;
            }
        }

        public List<EmployeeDto> GetEmployee()
        {
            var data = _employeeDbContext.Employees.ToList();
            var employeeDto = _mapper.Map<List<EmployeeDto>>(data);
            return employeeDto;
        }

        public EmployeeDto GetEmployee(int id)
        {
            var data = _employeeDbContext.Employees.FirstOrDefault(x => x.Id == id);
            var employeeDto = _mapper.Map<EmployeeDto>(data);
            return employeeDto;
        }
    }
}
