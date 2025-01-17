using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;
using TestTask.Business.DTO;
using TestTask.Business.Implementations;
using TestTask.Entities;
using TestTask.Utils.Exceptions;
using TestTask.Web.Models;

namespace TestTask.Web.Controllers
{
    public class CitizenController : Controller
    {

        private readonly IMapper _mapper;
        private readonly CitizenService _citizenService;

        private static List<EditCitizenViewModel> citizens = new List<EditCitizenViewModel>
        {
            new EditCitizenViewModel { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1985, 5, 15), IsMarried = true, Phone = "1234567890", Salary = 50000 },
            new EditCitizenViewModel { Id = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1990, 8, 22), IsMarried = false, Phone = "0987654321", Salary = 60000 }
        };

        public CitizenController(IMapper mapper, CitizenService citizenService)
        {
            _mapper = mapper;
            _citizenService = citizenService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var citizens = await _citizenService.GetAll();
                var mappedCitizens = _mapper.Map<IEnumerable<EditCitizenViewModel>>(citizens);

                return View(mappedCitizens);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GET: [Citizen/Index error {ex.Message}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody]EditCitizenViewModel updatedCitizen)
        {
            if (updatedCitizen == null || id != updatedCitizen.Id)
            {
                return BadRequest("Invalid request data.");
            }

            try
            {
                var citizenDTO = _mapper.Map<CitizenDTO>(updatedCitizen);

                await _citizenService.Update(citizenDTO);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine($"PUT: Citizen/Update/{id} error {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PUT: Citizen/Update/{id} error {ex.Message}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _citizenService.Remove(id);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine($"DELETE: Citizen/Delete/{id} - {ex.Message}");
                return NotFound($"Citizen with ID {id} not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DELETE: Citizen/Delete/{id} error {ex.Message}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}