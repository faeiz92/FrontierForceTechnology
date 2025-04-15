using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using System.IO;
using ProjectB.DTO;
using System.Text.Json;

namespace ProjectB.Utilities
{
    public class FilePathService
    {
        private readonly IHostEnvironment _env;

        public FilePathService(IHostEnvironment env)
        {
            _env = env;
        }

        public string  ReadFile()
        {
            // Get the root path of the application
            var rootPath = _env.ContentRootPath;

            // Construct the path dynamically relative to the root
            var filePath = Path.Combine(rootPath, "Utilities", "Countries.json");

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all content from the file
                var content = File.ReadAllText(filePath);
                // Do something with the content
                System.Console.WriteLine(content);
                return content;
            }
            else
            {
                System.Console.WriteLine("File not found.");
                return null;
            }
        }

        public List<CountryDTO> GetCountriesFromJson()
        {
            try
            {
                // Read the JSON file from the given file path
                string json = ReadFile();

                // Deserialize the JSON into a list of Country objects
                var countries = System.Text.Json.JsonSerializer.Deserialize<CountriesResponse>(json);

                return countries?.Countries;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return null;
            }
        }
    }
}
