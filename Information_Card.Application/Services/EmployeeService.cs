using Information_Card.Application.Interfaces;
using Information_Card.Core.Entities;
using Information_Card.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Information_Card.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                var jobs = await _employeeRepository.GetAllAsync();
                return jobs;
            }
            catch
            {
                return null;
            } 
        }

        public async Task<Employee> GetByIdAsync(Guid employeeId)
        {
            try
            { 
               return await _employeeRepository.GetByIdAsync(employeeId);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Employee> CreateAsunc(Employee employee)
        {
            try
            { 
              return await _employeeRepository.AddAsync(employee);
            }
            catch
            {
              return null;
            }
        }

        public async Task UpdateAsunc(Employee employee)
        {
            try
            {
                var model = await _employeeRepository.GetByIdAsync(employee.Id);
                if (model == null)
                    throw new ApplicationException($"Entity could not be loaded.");

                await _employeeRepository.UpdateAsync(employee);
            }
            catch
            {

            } 
        }

        public async Task DeleteAsunc(Guid employeeId)
        {
            try
            {
                var model = await _employeeRepository.GetByIdAsync(employeeId);
                if (model == null)
                    throw new ApplicationException($"Entity could not be loaded.");

                await _employeeRepository.DeleteAsync(model);
            }
            catch
            {

            } 
        }
    }
}
