using TestTask.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DataAccess.EF;
using TestTask.Entities;

namespace TestTask.DataAccess.Repositories.Implementations
{
    public class CitizenRepository : Repository<Citizen>
    {
        public CitizenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
