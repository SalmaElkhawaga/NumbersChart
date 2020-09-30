using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayNumbersChart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArrayNumberController : ControllerBase
    {
        private static readonly ArrayNumber[] Numbers = new ArrayNumber[] { };

        private readonly ILogger<ArrayNumberController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string DataPath = string.Empty;

        public ArrayNumberController(ILogger<ArrayNumberController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            DataPath = configuration["DataPath"];
        }

        [HttpGet]
        public IEnumerable<ArrayNumber> GetAllData()
        {
            string fileData = ReadFromJsonFile();
            return JsonConvert.DeserializeObject<ArrayNumber[]>(fileData);
        }

        private string ReadFromJsonFile()
        {
            string jsonResult = string.Empty;
            using (StreamReader streamReader = new StreamReader(DataPath))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }

        //private void RandomData()
        //{
        //    ArrayNumber[] tempArr = new ArrayNumber[25];
        //    Random rnd = new Random();
        //    DateTime tempCreationTime = DateTime.Now;

        //    for (int i = 0; i < 25; i++)
        //    {
        //        tempArr[i] = new ArrayNumber { CreationDate = tempCreationTime, Number = rnd.Next(0, 26) };
        //        tempCreationTime = tempCreationTime.AddMinutes(1);
        //    }
        //    string data = JsonConvert.SerializeObject(tempArr);
        //}
    }
}
