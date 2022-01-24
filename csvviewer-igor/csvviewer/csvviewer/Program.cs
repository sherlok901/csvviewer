using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvviewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ui = new Ui();
            var interactor = new Interactor();

            void Start()
            {
                var records = interactor.Start(args);
                //ui.Display(records);
            }

            Start();
            ui.Run();
        }
    }
}
