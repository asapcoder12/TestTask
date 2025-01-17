using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Web.Models
{
    public class CitizenViewModel
    {
        [Name("Name")]
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; } = null!;

        [Name("Date of birth")]
        [Required(ErrorMessage = "Date of birth field is required")]
        public DateTime DateOfBirth { get; set; }

        [Name("Married")]
        [Required(ErrorMessage = "Married field is required")]
        public bool IsMarried { get; set; }

        [Name("Phone")]
        [Required(ErrorMessage = "Phone field is required")]
        public string Phone { get; set; } = null!;

        [Name("Salary")]
        [Required(ErrorMessage = "Salary field is required")]
        public decimal Salary { get; set; }
    }
}
