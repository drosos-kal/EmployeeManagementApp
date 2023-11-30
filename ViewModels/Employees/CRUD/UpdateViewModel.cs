using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using EmployeeManagementChallenge.DAL.Entities;
using EmployeeManagementChallenge.Services;

namespace EmployeeManagementChallenge.ViewModels.Employees.CRUD
{
    public class UpdateViewModel : MasterPageViewModel
    {
        private readonly EmployeeService employeeService;
        private readonly SkillService skillService;

        public UpdateViewModel(EmployeeService employeeService, SkillService skillService)
        {
            this.employeeService = employeeService;
            this.skillService = skillService;
        }

        public Employee employee { get; set; }
        public List<Skill> skillsAvailable { get; set; }
        public List<string> skillsKnown { get; set; }
        public List<Skill> skillsToLearn { get; set; } = new List<Skill>();

        [FromRoute("Id")]
        public int Id { get; set; }

        public override async Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                if (Id != 0)
                {
                    employee = await employeeService.GetEmployeeById(Id);
                    skillsAvailable = await skillService.GetAllSkills();

                    if (employee.Skills != null)
                    {
                        skillsKnown = employee.Skills.Split(',').ToList();

                        foreach (var id in skillsKnown)
                        {
                            int id_skill = Convert.ToInt32(id);
                            var skill = await skillService.GetSkillById(id_skill);
                            if (skill != null)
                            {
                                skillsToLearn.Add(new Skill
                                {
                                    Id = skill.Id,
                                    Name = skill?.Name,
                                });


                            }
                        }
                    }
                    skillsAvailable.RemoveAll(x => skillsToLearn.Any(y => y.Id == x.Id));
                }
            }

            await base.PreRender();
        }


        public void RemoveFromKnownSkills(Skill skill)
        {
            skillsToLearn.Remove(skill);
            skillsAvailable.Add(skill);
        }

        public void AddToKnownSkills(Skill skill)
        {
            skillsAvailable.Remove(skill);
            skillsToLearn.Add(skill);
        }

        public async Task UpdateEmployee()
        {
            var idValues = skillsToLearn.Select(skill => skill.Id);
            employee.Skills = string.Join(",", idValues);
            await employeeService.UpdateEmployee(employee);
            Context.RedirectToRoute("Employees_Employees");
        }

        public async Task DeleteEmployee()
        {
            await employeeService.DeleteEmployee(Id);
            Context.RedirectToRoute("Employees_Employees");
        }


    }
}

