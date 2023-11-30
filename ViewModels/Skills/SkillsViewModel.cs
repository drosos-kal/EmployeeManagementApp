using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using EmployeeManagementChallenge.DAL.Entities;
using EmployeeManagementChallenge.Services;

namespace EmployeeManagementChallenge.ViewModels.Skills
{
    public class SkillsViewModel : MasterPageViewModel
    {
        private readonly SkillService skillService;

        public SkillsViewModel(SkillService skillService)
        {
            this.skillService = skillService;
        }

        [Bind(Direction.ServerToClient)]
        public List<Skill> Skills { get; set; }



        public override async Task PreRender()
        {
            Skills = await skillService.GetAllSkills();

            await base.PreRender();
        }


    }
}
