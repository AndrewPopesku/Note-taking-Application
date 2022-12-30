using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_taking_Application
{
    class Note
    {
        public int Id { get; init; }
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public Note(string text) => Text = text;
        public Note(int id, string text) : this(text) => Id = id;
        public Note(int id, string text, DateTime date) : this(id, text) => Date = date;

        public override string ToString()
            => string.Format("| {0,-3} | {1,-80} | {2,-21} |", Id, Text, Date);
    }
}
