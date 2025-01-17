using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Entities
{
    public class Citizen
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool IsMarried { get; set; }
        public string Phone { get; set; } = null!;
        public decimal Salary { get; set; }
    }
}
