using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITestService
    {
        Task<List<TestDTO>> GetTests(Guid id);
        Task<List<bool>> PassTest(PassTestDTO dto);
    }
}
