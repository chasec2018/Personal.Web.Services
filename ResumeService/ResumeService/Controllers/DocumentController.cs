using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ResumeService.Controllers
{
    
    [ApiController]
    [Route("api/document/{action}")]
    public class DocumentController : ControllerBase
    {
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ILogger<DocumentController> Logger;

        public DocumentController(IWebHostEnvironment _WebHostEnvironment, ILogger<DocumentController> _Logger)
        {
            WebHostEnvironment = _WebHostEnvironment;
            Logger = _Logger;
        }

        [HttpGet]
        public async Task GetResumeDoc()
        {
            try
            {
                string doc = Path.Combine(WebHostEnvironment.WebRootPath, "docs\\Resume.pdf");

                if (System.IO.File.Exists(doc))
                {
                    HttpContext.Response.Clear();
                    HttpContext.Response.ContentType = "application/pdf";
                    HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=Resume.pdf");
                    await HttpContext.Response.SendFileAsync(doc);
                }
            }
            catch(Exception exception)
            {
                Logger.LogError("Resume Not Downloading", exception);
            }
        }
    }
}