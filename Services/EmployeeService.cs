using EmployeeManagementChallenge.DAL.Entities;
using EmployeeManagementChallenge.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using EmployeeManagementChallenge.Repository.IRepository;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq.Expressions;
using static DotVVM.Framework.Compilation.Javascript.MethodFindingHelper.Generic;
using DotVVM.Framework.Controls;

namespace EmployeeManagementChallenge.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISkillRepository _skillRepository;


        public EmployeeService(IEmployeeRepository employeeRepository, ISkillRepository skillRepository)
        {
            _employeeRepository = employeeRepository;
            _skillRepository = skillRepository;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employeesEntities = _employeeRepository.GetAll(orderBy: q => q.OrderBy(e => e.Lastname));

            var employees = employeesEntities.Select(s => new Employee
            {
                Id = s.Id,
                Firstname = s.Firstname,
                Lastname = s.Lastname,
                Skills = s.Skills
            }).ToList();
            return employees;
        }


        public async Task<Employee> GetEmployeeById(int? employeeId)
        {
            if (employeeId == null || employeeId == 0) return null;


            Employee employeeFromDb = _employeeRepository.Get(u => u.Id == employeeId);

            return employeeFromDb;
        }

        public async Task InsertEmployee(Employee employee)
        {
            {
                var entity = new Employee()
                {
                    Firstname = employee.Firstname,
                    Lastname = employee.Lastname,
                    Skills = employee.Skills
                };

                _employeeRepository.Add(entity);
                _employeeRepository.Save();
            }

        }

        public async Task UpdateEmployee(Employee employee)
        {

            Employee employeeFromDb = _employeeRepository.Get(s => s.Id == employee.Id);

            if (employeeFromDb != null)
            {
                employeeFromDb.Firstname = employee.Firstname;
                employeeFromDb.Lastname = employee.Lastname;
                if (String.IsNullOrEmpty(employee.Skills))
                {
                    employeeFromDb.Skills = null;
                }
                else
                {
                    employeeFromDb.Skills = employee.Skills;
                }


                _employeeRepository.Update(employeeFromDb);
                _employeeRepository.Save();
            }
        }

        public async Task DeleteEmployee(int? employeeId)
        {
            if (employeeId == null || employeeId == 0)
            {
                return;
            }

            Employee employeeFromDb = _employeeRepository.Get(s => s.Id == employeeId);

            if (employeeFromDb == null)
            {
                return;
            }
            _employeeRepository.Remove(employeeFromDb);
            _employeeRepository.Save();
        }
    }
}
