using Microsoft.AspNetCore.Mvc;
using Snow.DataVisualizer.API.Repositories.Interface;
using Snow.DataVisualizer.API.Entities;
using Snow.DataVisualizer.API.Shared.Extensions;
using Snow.DataVisualizer.API.Validators;
using System.Text.Json;

namespace Snow.DataVisualizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase

    {
        private readonly IDataVisualizerRepository _dataVisualizerRepo;
        private readonly ILogger<FileUploadController> _logger;
        public FileUploadController(IDataVisualizerRepository dataVisualizerRepo
            , ILogger<FileUploadController> logger
            )
        {
            _dataVisualizerRepo = dataVisualizerRepo;
            _logger = logger;
        }

        [HttpPost("ImportFile")]
        public async Task<IActionResult> ImportFile([FromForm] IFormFile file)
        {
            List<FileOutputData> fileOutput = new List<FileOutputData>();
            const string inValidDataErrorMessage = "Data provided is not valid.";
            try
            {
                _logger.LogInformation("Import Started.");
                
                string name = file.FileName;
                string extension = Path.GetExtension(file.FileName);

                FileValidator fileValidator = new FileValidator();
                var fileValidationResult = fileValidator.Validate(file);
                if (!fileValidationResult.IsValid)
                {
                    const string inValidFileErrorMessage = "Uploaded file is either empty or in the wrong format.";
                    var Errors = JsonSerializer.Serialize(fileValidationResult.Errors);
                    _logger.LogError(Errors);
                    _logger.LogError(inValidFileErrorMessage);
                    return BadRequest(inValidFileErrorMessage);
                    
                }

                var dataByLine = file.GetFileDataByLine();

                foreach (var dataLine in dataByLine)
                {
                    string[] characters = dataLine.Split(':');
                    var fileUpload = new FileOutputData
                    {
                        Hastag = characters[0].Substring(0, 1).ToCharArray()[0],
                        Name = characters[0].Substring(1),
                        Color = characters[1],
                        Value = Int32.Parse(characters[2])
                    };

                    FileOutputDataValidator validator = new FileOutputDataValidator();
                    var dataValidationResult = validator.Validate(fileUpload);

                    if (!dataValidationResult.IsValid)
                    {
                       
                        var errors = JsonSerializer.Serialize(dataValidationResult.Errors);
                        _logger.LogError(errors);
                        _logger.LogError(inValidDataErrorMessage);
                        return BadRequest(inValidDataErrorMessage);
                    }
                    fileOutput.Add(fileUpload);
                    await _dataVisualizerRepo.DeleteAsync();
                    await _dataVisualizerRepo.AddAsync(fileUpload);
                    _logger.LogInformation("Import Completed Successfully.");
                }               
            }
            catch(Exception e) 
            {
                _logger.LogError(e, inValidDataErrorMessage);
                return BadRequest(inValidDataErrorMessage);
            }
            return Ok(fileOutput);
        }
        [HttpGet("DataRandomizer")]
        public async Task<IActionResult> DataRandomizer()
        {
            List<FileOutputData> fileOutput = new List<FileOutputData>();
            try
            {
                string[] Names = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
                string[] Colors = new string[] { "BLACK", "BLUE", "BROWN", "GREEN", "PINK", "RED", "ORANGE", "PURPLE", "GREY", "YELLOW" };
                int[] Values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                var random = new Random();
                var noOfDatas = random.Next(2, 10);
                
                for (int i = 0; i < noOfDatas; i++)
                {
                    var randomData = new FileOutputData
                    {
                        Hastag = '#',
                        Name = Names[random.Next(Names.Length - 1)],
                        Color = Colors[random.Next(Colors.Length - 1)],
                        Value = Values[random.Next(Values.Length - 1)],
                    };
                    fileOutput.Add(randomData);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal Server Error.");
                return BadRequest("Internal Server Error.");
            }
            return Ok(fileOutput);
        }
    }
}

