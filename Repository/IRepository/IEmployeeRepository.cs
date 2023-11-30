using EmployeeManagementChallenge.DAL.Entities;

namespace EmployeeManagementChallenge.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void Update(Employee employee);
    }
}
