using EmployeeManagementChallenge.DAL.Entities;

namespace EmployeeManagementChallenge.Repository.IRepository
{
    public interface ISkillRepository : IRepository<Skill>
    {
        void Update(Skill skill);
 
    }

    
}
