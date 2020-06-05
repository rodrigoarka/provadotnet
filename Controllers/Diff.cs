using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DiffController : ControllerBase
    {


        private readonly ILogger<DiffController> _logger;

        public DiffController(ILogger<DiffController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<String>> Get()
        {
            var left = System.IO.File.ReadAllText(@"./json/left.json");
            var right = System.IO.File.ReadAllText(@"./json/right.json");
            var leftJObject = JObject.Parse(left);
            var rightJObject = JObject.Parse(right);
            
            var identicos = "false";
            var tamanho = "false";
            var arquivos = "";
            if (left == right)
            {
                identicos = "true";
            }
            if (left.Length == right.Length)
            {
                tamanho = "true";
            }

            if (tamanho == "true" && identicos =="false")
            {
                arquivos+= ", \"arquivos\": {\"left\":"+left+", \"right\":"+right+"}";

            }

            
            var resultado = JObject.Parse("{\"identicos\": "+identicos+", \"mesmo tamanho\":"+tamanho+" "+arquivos+"}");
            // Console.WriteLine(leftJObject.SelectToken("MyStringProperty").Value<string>());
            return Ok(resultado);
        }
        [HttpPost("left")]
        public  JObject saveLeft(JObject jsonString)
        {
            
            string templateName = (string)jsonString.SelectToken("templateName");
            string filePathAndName = "./json/left.json";
            using (System.IO.StreamWriter file = System.IO.File.CreateText(@filePathAndName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, jsonString);
            }
            System.Console.Write("Json: ");
            System.Console.Write(jsonString);
            
            return jsonString;
        }


        [HttpPost("right")]
        public  JObject saveRight(JObject jsonString)
        {
            
            string templateName = (string)jsonString.SelectToken("templateName");
            string filePathAndName = "./json/right.json";
            using (System.IO.StreamWriter file = System.IO.File.CreateText(@filePathAndName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, jsonString);
            }
            System.Console.Write("Json: ");
            System.Console.Write(jsonString);
            
            return jsonString;
        }    
    }
}
