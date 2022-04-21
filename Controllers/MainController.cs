using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using note_main_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace note_main_backend.Controllers
{
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        IConfiguration _config;
        public MainController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost, Route("LogEntry/Post")]
        public IActionResult PostLogEntry([FromBody] LogEntryModel model)
        {
            
            return Ok();
        }

        [HttpPost, Route("ArchiveEntry")]
        public IActionResult Archive_Entry([FromBody] ArchiveRequest model)
        {
            
            return Ok();
        }

    }
}
