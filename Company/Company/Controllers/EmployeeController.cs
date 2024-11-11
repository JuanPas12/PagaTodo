using Company.Data.Models;
using Company.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController (IEmployeeRepository _iEmployeeRepository): ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _iEmployeeRepository.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _iEmployeeRepository.GetEmployeeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            return Ok(await _iEmployeeRepository.AddEmployee(employee));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            return Ok(await _iEmployeeRepository.UpdateEmployee(employee));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return Ok(await _iEmployeeRepository.DeleteEmployee(id));
        }
    }
}
