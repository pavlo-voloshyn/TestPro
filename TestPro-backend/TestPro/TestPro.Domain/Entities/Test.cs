using System;
using System.Collections.Generic;

namespace TestPro.Domain.Entities
{
    public class Test : EntityBase
    {
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
        public bool IsPassed { get; set; }

        public User User {  get; set; } 
        public Guid UserId {  get; set; }
    }
}
