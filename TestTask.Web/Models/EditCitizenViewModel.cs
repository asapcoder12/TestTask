using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Web.Models
{
    public class EditCitizenViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Date of birth field is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Married field is required")]
        public bool IsMarried { get; set; }

        [Required(ErrorMessage = "Phone field is required")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Salary field is required")]
        public decimal Salary { get; set; }
    }
}
