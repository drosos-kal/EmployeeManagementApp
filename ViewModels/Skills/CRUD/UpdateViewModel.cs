using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using EmployeeManagementChallenge.Services;
using EmployeeManagementChallenge.DAL.Entities;

namespace EmployeeManagementChallenge.ViewModels.Skills.CRUD
{
    public class UpdateViewModel : MasterPageViewModel
    {
        private readonly SkillService skillService;

        public UpdateViewModel(SkillService skillService)
        {
            this.skillService = skillService;
        }

        public Skill Skill { get; set; }


        [FromRoute("Id")]
        public int Id { get; private set; }

        public override async Task PreRender()
        {
            if (Id != 0)
            {
                Skill = await skillService.GetSkillById(Id);
            }
            await base.PreRender();
        }

        public async Task UpdateSkill()
        {
            await skillService.UpdateSkill(Skill);
            Context.RedirectToRoute("Skills_Skills");
        }

        public async Task DeleteSkill()
        {
            await skillService.DeleteSkill(Id);
            Context.RedirectToRoute("Skills_Skills");
        }

    }
}

