using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using EmployeeManagementChallenge.Services;
using EmployeeManagementChallenge.DAL.Entities;

namespace EmployeeManagementChallenge.ViewModels.Employees.CRUD
{
    public class CreateViewModel : MasterPageViewModel
    {
        private readonly EmployeeService employeeService;
        private readonly SkillService skillService;

        public CreateViewModel(EmployeeService employeeService, SkillService skillService)
        {
            this.employeeService = employeeService;
            this.skillService = skillService;
        }

        public Employee employee { get; set; } = new Employee();
        public Skill skill { get; set; } = new Skill();
        StringBuilder sb = new StringBuilder();


        public async Task AddEmployee()
        {
            var skillToCheck = await skillService.GetSkillByName(skill.Name);


            if (skillToCheck != null)
            {
                sb.Append(skillToCheck.Id);
                employee.Skills = sb.ToString();
            }
            else
            {
                var skillToRelate = skillService.InsertSkill(skill);
                employee.Skills = skillToRelate.Id.ToString();
            }

            await employeeService.InsertEmployee(employee);
            Context.RedirectToRoute("Employees_Employees");

        }
    }
}

