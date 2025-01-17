using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTask.Business.DTO;
using TestTask.Business.Implementations;
using TestTask.Services;
using TestTask.Web.Models;

namespace TestTask.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICsvParser _csvParser;
        private readonly IMapper _mapper;
        private readonly CitizenService _citizenService;

        public HomeController(ICsvParser csvParser, IMapper mapper, CitizenService citizenService)
        {
            _csvParser = csvParser;
            _mapper = mapper;
            _citizenService = citizenService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    ModelState.AddModelError("file", "File is required");
                    return View();
                }

                List<CsvRecordViewModel> records;

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;

                    records = await _csvParser.ParseCsvAsync<CsvRecordViewModel>(stream);
                }

                if (!records.Any())
                {
                    ModelState.AddModelError("file", "The uploaded file is empty or invalid");
                    return View();
                }

                var invalidRecords = records.Where(record =>
                {
                    var context = new ValidationContext(record, null, null);
                    return !Validator.TryValidateObject(record, context, new List<ValidationResult>(), true);
                }).ToList();

                if (invalidRecords.Any())
                {
                    ModelState.AddModelError("file", $"Invalid data found in {invalidRecords.Count} records");
                    return View();
                }

                foreach (var record in records)
                {
                    var citizenDTO = _mapper.Map<CitizenDTO>(record);
                    await _citizenService.Create(citizenDTO);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"POST: Citizen/Index error {ex.Message}");
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
