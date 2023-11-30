using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementChallenge.Services;
using DotVVM.Framework.ViewModel;

namespace EmployeeManagementChallenge.ViewModels.Employees
{
    public class EmployeesViewModel : MasterPageViewModel
    {
        private readonly EmployeeService employeeService;
        private readonly SkillService skillService;

        public EmployeesViewModel(EmployeeService employeeService, SkillService skillService)
        {
            this.employeeService = employeeService;
            this.skillService = skillService;
        }

        [Bind(Direction.ServerToClient)]
        public List<tableobj> tableview { get; set; } = new List<tableobj>();


        public override async Task PreRender()
        {
            var employees = await employeeService.GetAllEmployees();

            foreach (var em in employees)
            {

                tableobj t = new tableobj
                {
                    Firstname = em.Firstname,
                    Lastname = em.Lastname,
                    Id = em.Id,
                    Skills = new List<tableobj.Skill>()
                };

                if (em.Skills != null)
                {
                    List<string> xx = em.Skills.Split(',').ToList();

                    foreach (var id in xx)
                    {
                        int id_skill = Convert.ToInt32(id);
                        var skill = await skillService.GetSkillById(id_skill);
                        if (skill != null)
                        {
                            t.Skills.Add(new tableobj.Skill
                            {
                                Id = skill?.Id,
                                Name = skill?.Name,
                            });

                        }
                    }
                }


                tableview.Add(t);
            }
            await base.PreRender();
        }


        public class tableobj
        {
            public int Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public List<Skill> Skills { get; set; }
            public class Skill
            {
                public int? Id { get; set; }
                public string? Name { get; set; }
            }
        }
    }
}

