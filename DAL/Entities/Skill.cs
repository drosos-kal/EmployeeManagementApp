using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace EmployeeManagementChallenge.DAL.Entities
{
    public class Skill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public DateTime TimeCreated { get; set; }

    }
}
