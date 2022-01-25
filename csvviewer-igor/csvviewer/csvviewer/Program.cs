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
                var lines = interactor.FirstPage(args);
                ui.Display(lines);
            }

            ui.MoveToFirst += () => {
                var records = interactor.FirstPage();
                ui.Display(records);
            };
            //ui.MovePrev += () => {
            //    var records = interactor.PrevPage();
            //    ui.Display(records);
            //};
            //ui.MoveNext += () => {
            //    var records = interactor.NextPage();
            //    ui.Display(records);
            //};
            //ui.MoveLast += () => {
            //    var records = interactor.LastPage();
            //    ui.Display(records);
            //};

            Start();
            ui.Run();
        }
    }
}
