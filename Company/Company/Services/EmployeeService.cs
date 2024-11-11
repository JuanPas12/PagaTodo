using Company.Data;
using Company.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Company.Services
{
    public class EmployeeService (Context _context) : IEmployeeService
    {

        #region AddEmployee
        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employee">The employee entity to be added.</param>
        /// <returns>The added employee entity.</returns>
        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding employee: {ex.Message}");
            }
        }
        #endregion

        #region DeleteEmployee
        /// <summary>
        /// Deletes an employee with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>The deleted employee if found; otherwise, null.</returns>
        public async Task<Employee> DeleteEmployee(int id)
        {
            try
            {
                Employee employee = await _context.Employees.FindAsync(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting employee with ID {id}: {ex.Message}");
            }
        }
        #endregion

        #region GetEmployeeById
        /// <summary>
        /// Retrieves an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee.</param>
        /// <returns>The employee with the specified identifier.</returns>
        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                return await _context.Employees.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employee with ID {id}: {ex.Message}");
            }
        }
        #endregion

        #region GetAllEmployees
        /// <summary>
        /// Retrieves a list of all employees from the database.
        /// </summary>
        /// <returns>A list of employees.</returns>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving employees: {ex.Message}");
                throw new Exception($"Error retrieving employees: {ex.Message}");
            }
        }
        #endregion

        #region UpdateEmployee
        /// <summary>
        /// Updates an existing employee in the database.
        /// </summary>
        /// <param name="employee">The employee entity to update.</param>
        /// <returns>The updated employee entity.</returns>
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error updating employee with ID {employee.EmployeeId}: {ex.Message}");
                throw new Exception($"Error updating employee with ID {employee.EmployeeId}: {ex.Message}");
            }
        }
        #endregion
    }
}
