using Company.Data;
using Company.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employee">The employee entity to be added.</param>
        /// <returns>The added employee entity.</returns>
        /// <remarks>
        /// This method asynchronously adds the provided employee entity to the Employees DbSet
        /// and saves the changes to the database.
        public async Task<Employee> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        /// <summary>
        /// Deletes an employee with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the deleted employee if found; otherwise, null.
        /// </returns>
        public async Task<Employee> DeleteEmployee(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        /// <summary>
        /// Retrieves an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the employee with the specified identifier.</returns>

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
    
        /// <summary>
        /// Asynchronously retrieves a list of all employees from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an IEnumerable of Emplo
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        /// <summary>
        /// Updates an existing employee in the database.
        /// </summary>
        /// <param name="employee">The employee entity to update.</param>
        /// <returns>The updated employee entity.</returns>
        /// <remarks>
        /// This method updates the provided employee entity in the database and saves the changes asynchronously.
        /// </remarks>
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
