using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class PassTestDTO
    {
        public Guid Id { get; set; }
        public List<string> Answers {  get; set; } 
    }
}
