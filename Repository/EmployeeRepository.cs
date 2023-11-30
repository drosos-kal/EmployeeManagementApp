using EmployeeManagementChallenge.DAL.Entities;
using EmployeeManagementChallenge.Data;
using EmployeeManagementChallenge.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementChallenge.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        private ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Employee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
        }
    }
}
