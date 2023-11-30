using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using EmployeeManagementChallenge.DAL.Entities;
using EmployeeManagementChallenge.Data;
using EmployeeManagementChallenge.Repository;
using EmployeeManagementChallenge.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementChallenge.Services
{
    public class SkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            // Expression<Func<Skill, bool>> filter
            var skillsEntities = _skillRepository.GetAll();

            var skills = skillsEntities.Select(s => new Skill
            {
                Id = s.Id,
                Name = s.Name,
                Details = s.Details,
                TimeCreated = s.TimeCreated
            }).ToList();

            return skills;

        }

        public async Task<Skill> GetSkillById(int? skillId)
        {
            if (skillId == 0) return null;


            Skill skillFromDb = _skillRepository.Get(u => u.Id == skillId);

            return skillFromDb;
        }

        public async Task<Skill> GetSkillByName(string Name)
        {
            Skill? skillFromDb = _skillRepository.Get(s => s.Name == Name);

            return skillFromDb;

        }

        public async Task<Skill> InsertSkill(Skill skill)
        {

            var entity = new Skill()
            {
                Name = skill.Name,
                Details = skill.Details,
                TimeCreated = DateTime.Now
            };


            _skillRepository.Add(entity);
            _skillRepository.Save();

            return entity;
        }

        public async Task UpdateSkill(Skill skill)
        {

            Skill skillFromDb = _skillRepository.Get(s => s.Id == skill.Id);

            if (skillFromDb != null)
            {
                skillFromDb.Name = skill.Name;
                skillFromDb.Details = skill.Details;

                _skillRepository.Update(skillFromDb);
                _skillRepository.Save();
            }
        }

        public async Task DeleteSkill(int? skillId)
        {
            if (skillId == null || skillId == 0)
            {
                return;
            }

            Skill skillFromDb = _skillRepository.Get(s => s.Id == skillId);

            if (skillFromDb == null)
            {
                return;
            }
            _skillRepository.Remove(skillFromDb);
            _skillRepository.Save();
        }
    }
}
