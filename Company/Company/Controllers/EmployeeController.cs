using Company.Data.Models;
using Company.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService _iEmployeeService) : ControllerBase
    {
        #region GetAllEmployees
        /// <summary>
        /// Retrieves a list of all employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                IEnumerable<Employee> employees = await _iEmployeeService.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving employees: {ex.Message}");
            }
        }
        #endregion

        #region GetEmployeeById
        /// <summary>
        /// Retrieves a specific employee by their unique identifier.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                Employee employee = await _iEmployeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound("Employee not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving employee with ID {id}: {ex.Message}");
            }
        }
        #endregion

        #region AddEmployee
        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee.</returns>
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                Employee addedEmployee = await _iEmployeeService.AddEmployee(employee);
                return Ok(addedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding employee: {ex.Message}");
            }
        }
        #endregion

        #region UpdateEmployee
        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="employee">The employee to update.</param>
        /// <returns>The updated employee.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                Employee updatedEmployee = await _iEmployeeService.UpdateEmployee(employee);
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating employee with ID {employee.EmployeeId}: {ex.Message}");
            }
        }
        #endregion

        #region DeleteEmployee
        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>The deleted employee.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                Employee deletedEmployee = await _iEmployeeService.DeleteEmployee(id);
                if (deletedEmployee == null)
                {
                    return NotFound("Employee not found.");
                }
                return Ok(deletedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting employee with ID {id}: {ex.Message}");
            }
        }
        #endregion
    }
}
