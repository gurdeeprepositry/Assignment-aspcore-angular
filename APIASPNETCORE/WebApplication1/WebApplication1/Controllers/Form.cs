using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using WebApplication1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Form : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Form(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // POST api/Form
        [HttpPost]
        public ActionResult Post([FromBody] FormModel form)
        {
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string folderPath = Path.Combine(contentRootPath, "json");
            bool exists = Directory.Exists(folderPath);
            if (!exists)
                Directory.CreateDirectory(folderPath);

            long timeStamp = DateTime.Now.ToFileTime();
            string fileName = $"{timeStamp}.json";
            string filePath = Path.Combine(folderPath, fileName);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(form, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath, json);
            return Ok();
        }

    }
}
