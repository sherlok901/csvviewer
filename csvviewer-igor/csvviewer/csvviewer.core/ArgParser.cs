using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvviewer.core
{
    internal class ArgParser
    {
        private int _pageLength;

        public string GetFilename(string[] args)
        {
            return args.FirstOrDefault();
        }

        public int GetPageLength(string[] args)
        {
            _pageLength = args.Length > 1 ? int.Parse(args[1]) : 10;
            return _pageLength;
        }

        public int GetPageLength() => _pageLength;
    }
}
