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
        private readonly FileReader _fileReder = new FileReader();
        private readonly Paging _paging = new Paging();
        private readonly Formatter _formatter = new Formatter();

        public IEnumerable<string> FirstPage(string[] args)
        {
            var filename = _argParser.GetFilename(args);
            var pageLength = _argParser.GetPageLength(args);
            var lines = _fileReder.ReadFileContent(filename);
            var result = GetFirstRecords(pageLength, lines);
            return result;
        }
        
        public IEnumerable<string> FirstPage()
        {
            var pageLength = _argParser.GetPageLength();
            var lines = _fileReder.GetFileContent();
            var result = GetFirstRecords(pageLength, lines);
            return result;
        }

        private IEnumerable<string> GetFirstRecords(int pageLength, IEnumerable<string> lines)
        {
            var firstPage = _paging.ExtractFirstPage(lines, pageLength);
            var records = Csv.CreateRecords(firstPage);
             var result = _formatter.Format(records);
            return result;
        }
    }
}
