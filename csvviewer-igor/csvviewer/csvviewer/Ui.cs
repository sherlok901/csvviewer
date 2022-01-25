using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
    public class Ui
    {
        public event Action MoveToFirst;
        public event Action MoveToPrev;
        public event Action MoveToNext;
        public event Action MoveToLast;

        public void Run()
        {
            var exit = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("F)irst, P)rev, N)ext, L)ast, E)xit");

                var key = Console.ReadKey().KeyChar.ToString().ToUpper();
                Console.WriteLine();

                switch (key)
                {
                    case "E":
                        exit = true;
                        break;
                    case "F":
                        MoveToFirst();
                        break;
                    case "P":
                        MoveToPrev();
                        break;
                    case "N":
                        MoveToNext();
                        break;
                    case "L":
                        MoveToLast();
                        break;
                }
            } while (!exit);
        }

        public void Display(IEnumerable<string> lines)
        {
            lines.ToList().ForEach(Console.WriteLine);
        }
    }
}
