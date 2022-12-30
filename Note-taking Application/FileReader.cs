using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_taking_Application
{
    class FileEditor
    {
        public string Path { get; }
        public NoteList noteList { get; set; }
        public int Count { get => noteList.Count; }

        public FileEditor(string path)
        {
            Path = path;
            noteList = new NoteList();
        }

        public void ReadFile()
        {
            try
            {
                StreamReader streamReader = new StreamReader(Path);
                string line = streamReader.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                    ReadNote(line);
                    line = streamReader.ReadLine();
                }

                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void WriteInFile(Note note)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(Path, true);
                streamWriter.WriteLine(FormatNoteForStoring(note));
                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void UpdateFile()
        {
            noteList.Clear();
            ReadFile();
        }

        public void ReadNote(string line) => AddNote(ReformatStringToNote(line));

        public Note ReformatStringToNote(string line)
        {
            string[] data = line.Split("||");

            int id = Int32.Parse(data[0]);
            string text = data[1].Trim();
            DateTime date = DateTime.Parse(data[2].Trim());

            return new Note(id, text, date);
        }

        public static ReadOnlySpan<char> FormatNoteForStoring(Note note)
        {
            if (note == null) throw new ArgumentNullException();

            return string.Format(note.Id + " || " + note.Text + " || " + note.Date);
        }

        // CRUD operations
        public void AddNote(string text)
        {
            int id = (noteList.Count != 0) ? noteList.notes.Select(x => x.Id).Max() + 1 : 1;
            DateTime date = DateTime.Now;
            Note note = new Note(id, text, date);

            WriteInFile(note);
        }

        public void AddNote(Note note)
        {
            Array.Resize(ref noteList.notes, Count + 1);
            noteList[Count - 1] = note;
        }

        public void DeleteNote(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException();
            if (id > Count - 1) Console.WriteLine($"There is no note with {id}. Please try again..");

            string[] lines = File.ReadAllLines(Path);
            StreamWriter writer = new StreamWriter(Path);
            for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                if (ReformatStringToNote(lines[currentLine - 1]).Id != id)
                    writer.WriteLine(lines[currentLine - 1]);

            writer.Close();
        }

        public void CrearFile()
        {
            StreamWriter writer = new StreamWriter(Path);
            writer.Write("");
            writer.Close();
        }
    }
}
