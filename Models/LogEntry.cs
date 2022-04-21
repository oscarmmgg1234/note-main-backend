using System;
namespace note_main_backend.Models
{
    public class LogEntry
    {

        public string ID { get; set; }

        public string NoteID { get; set; }

        public DateTime Date_Added { get; set; }

        public string Note_Header { get; set; }

        public string Note_Body { get; set; }

        public bool Is_Archived { get; set; }
    }
}
