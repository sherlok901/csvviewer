using csvviewer.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static csvviewer.core.ArgsValidator;

namespace csvviewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var validator = new ArgsValidator();
            if(validator.Validate(args) == ValidationResult.NoFilePath)
            {
                Console.WriteLine("Specify file path");
                return;
            }

            var ui = new Ui();
            var interactor = new Interactor();

            void Start()
            {
                var lines = interactor.FirstPage(args);
                ui.Display(lines);
            }

            ui.MoveToFirst += () => {
                var records = interactor.FirstPage();
                ui.Display(records);
            };
            ui.MoveToPrev += () =>
            {
                var records = interactor.PrevPage();
                ui.Display(records);
            };
            ui.MoveToNext += () =>
            {
                var records = interactor.NextPage();
                ui.Display(records);
            };
            ui.MoveToLast += () =>
            {
                var records = interactor.LastPage();
                ui.Display(records);
            };

            Start();
            ui.Run();
        }
    }
}
