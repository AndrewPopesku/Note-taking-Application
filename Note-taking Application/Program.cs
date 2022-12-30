using System.Text;
using Note_taking_Application;

Console.WriteLine("-It's note-taking application-\n");

string path = @"D:\Programming\study\C# console apps\" +
              @"Note-taking Application\Note-taking Application\data.txt";
FileEditor fileReader = new FileEditor(path);
bool activeProgram = true;

while(activeProgram)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\nWhat do you want to do?");
    Console.Write("Press [A] to add note, [R] - read all, [D] - delete note(by id), [C] - clear file or [Q] - to quit: ");
    var key = Console.ReadKey().Key;
    Console.WriteLine();
    fileReader.ReadFile();
    Console.ResetColor();

    switch (key)
    {
        case ConsoleKey.A:
            fileReader.UpdateFile();
            Console.Write("\nWrite your note: ");
            string text = Console.ReadLine();
            fileReader.AddNote(text);
            break;

        case ConsoleKey.R:
            fileReader.UpdateFile();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('_', 114));
            Console.WriteLine("| #Id | Note " + new string(' ', 76) + "|     Date and time     |");
            foreach(var note in fileReader.noteList)
            {
                Console.WriteLine(new string('-', 114));
                Console.WriteLine(note);
            }
            Console.WriteLine(new string('_', 114));
            break;

        case ConsoleKey.D:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nEnter id of note you want to delele(id > 0) -> ");
            int id = Int32.Parse(Console.ReadLine());
            fileReader.DeleteNote(id);
            break;

        case ConsoleKey.C:
            Console.ForegroundColor = ConsoleColor.Red;
            fileReader.CrearFile();
            Console.WriteLine("\nThe file is cleared!");
            break;

        case ConsoleKey.Q:
            activeProgram = false;
            break;
    }

    Console.ResetColor();
}

