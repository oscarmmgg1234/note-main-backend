using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using note_main_backend.Models;
using note_main_backend.Data;

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
            using(var context = new NoteDBContext(_config))
            {
                var Entry = new LogEntry();
                Entry.ID = model.ID;
                Entry.Is_Archived = false;
                Entry.NoteID = Guid.NewGuid().ToString();
                Entry.Note_Body = model.Note_Body;
                Entry.Note_Header = model.Note_Header;
                Entry.Date_Added = DateTime.Now;

                context.Attach<LogEntry>(Entry);
                context.Add<LogEntry>(Entry);
                return Ok(context.SaveChanges());
            }
            
        }

        [HttpPost, Route("ArchiveEntry")]
        public IActionResult Archive_Entry([FromBody] ArchiveRequest model)
        {

            using (var context = new NoteDBContext(_config))
            {
                var logEntry = context.Logs.First(x => x.ID == model.ID && x.NoteID == model.NoteID);

                logEntry.Is_Archived = true;
                
                return Ok(context.SaveChanges());
            }

        }


        [HttpPost, Route("Update/Body")]
        public IActionResult NoteBodyUpdate([FromBody] NoteBodyUpdateRequest model)
        {

            using (var context = new NoteDBContext(_config))
            {
                var logEntry = context.Logs.First(x => x.ID == model.ID && x.NoteID == model.NoteID);

                logEntry.Note_Body = model.Note_Body;

                return Ok(context.SaveChanges());
            }

        }

    }
}
