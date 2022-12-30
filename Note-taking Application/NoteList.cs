using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_taking_Application
{
    class NoteList : IEnumerable, IEnumerator
    {
        public Note[] notes = new Note[0];

        int position = -1;

        public int Count { get => notes.Length; }

        public object Current => notes[position];

        public Note this[int index]
        {
            get => notes[index];
            set => notes[index] = value;
        }

        public bool MoveNext()
        {
            if(position < Count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset() => position = -1;

        public IEnumerator GetEnumerator() => notes.GetEnumerator();

        public void Clear() => notes = new Note[0];
    }
}
