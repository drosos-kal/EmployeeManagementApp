using EmployeeManagementChallenge.DAL.Entities;
using EmployeeManagementChallenge.Data;
using EmployeeManagementChallenge.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementChallenge.Repository
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {

        private ApplicationDbContext _db;

        public SkillRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Skill skill)
        {
            _db.Entry(skill).State = EntityState.Modified;
        }



    }
}
