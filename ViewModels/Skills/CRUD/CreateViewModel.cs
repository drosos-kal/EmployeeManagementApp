using System.Threading.Tasks;
using EmployeeManagementChallenge.Services;
using EmployeeManagementChallenge.DAL.Entities;
using DotVVM.Framework.ViewModel;


namespace EmployeeManagementChallenge.ViewModels.Skills.CRUD
{
    public class CreateViewModel : MasterPageViewModel
    {
        private readonly SkillService skillService;

        public Skill skill { get; set; } = new Skill();

        public CreateViewModel(SkillService skillService)
        {
            this.skillService = skillService;
        }

        public async Task AddSkill()
        {
            await skillService.InsertSkill(skill);
            Context.RedirectToRoute("Skills_Skills");
        }
    }
}

