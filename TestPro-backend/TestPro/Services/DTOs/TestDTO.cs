using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class TestDTO
    {
        public string Id { get; set; }
        public string Desсription { get; set; }  
        public List<Ques> Questions { get; set; } 
    }

    public class Ques
    {
        public string Title { get; set; }
        public List<string> Answers { get; set; }
    }
}
