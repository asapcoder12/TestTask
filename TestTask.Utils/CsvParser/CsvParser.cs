using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace TestTask.Services
{
    public class CsvParser : ICsvParser
    {
        public async Task<List<T>> ParseCsvAsync<T>(Stream fileStream) where T : class
        {
            var records = new List<T>();

            try
            {
                using (var reader = new StreamReader(fileStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = new List<T>();
                    await foreach (var record in csv.GetRecordsAsync<T>())
                    {
                        records.Add(record);
                    }
                }
            }
            catch (HeaderValidationException ex)
            {
                Console.WriteLine($"Header validation error: {ex.Message}");
            }
            catch (TypeConverterException ex)
            {
                Console.WriteLine($"Type conversion error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing CSV: {ex.Message}");
            }

            return records;
        }
    }
}