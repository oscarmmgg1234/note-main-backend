using System;
namespace note_main_backend.Models
{
    public class NoteBodyUpdateRequest
    {
        public string Note_Body { get; set; }

        public string ID { get; set; }

        public string NoteID { get; set; }
    }
}
