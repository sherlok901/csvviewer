using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvviewer
{
    public class Ui
    {
        public event Action MoveFirst;
        public event Action MovePrev;
        public event Action MoveNext;
        public event Action MoveLast;

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
                        MoveFirst();
                        break;
                    case "P":
                        MovePrev();
                        break;
                    case "N":
                        MoveNext();
                        break;
                    case "L":
                        MoveLast();
                        break;
                }
            } while (!exit);
        }
    }
}
