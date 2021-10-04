using System.Collections.Generic;

namespace TestPro.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password {  get; set; }

        public List<Test> Tests { get; set; }
    }
}
