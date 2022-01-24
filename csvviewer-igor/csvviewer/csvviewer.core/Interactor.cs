using csvviewer.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvviewer
{
    public class Interactor
    {
        private readonly ArgParser _argParser = new ArgParser();

        public IEnumerable<Record> Start(string[] args)
        {
            var filename = _argParser.GetFilename(args);

            return new Record[] { };
        }
    }
}
