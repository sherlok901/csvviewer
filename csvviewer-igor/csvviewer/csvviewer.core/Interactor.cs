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
            var result = GetLines(pageLength, lines, _paging.ExtractFirstPage);
            return result;
        }
        
        //TODO: when file names not specified show message, check the file existness
        public IEnumerable<string> FirstPage()
        {
            var result = GetLines(_argParser.PageLength, _fileReder, _paging.ExtractFirstPage);
            return result;
        }

        public IEnumerable<string> PrevPage()
        {
            var result = GetLines(_argParser.PageLength, _fileReder, _paging.ExtractPrevPage);
            return result;
        }

        public IEnumerable<string> NextPage()
        {
            var result = GetLines(_argParser.PageLength, _fileReder, _paging.ExtractNextPage);
            return result;
        }

        public IEnumerable<string> LastPage()
        {
            var result = GetLines(_argParser.PageLength, _fileReder, _paging.ExtractLastPage);
            return result;
        }

        private IEnumerable<string> GetLines(int pageLength, IEnumerable<string> lines, Func<IEnumerable<string>, int, IEnumerable<string>> func)
        {
            var firstPage = func(lines, pageLength);
            var records = Csv.CreateRecords(firstPage);
            var result = _formatter.Format(records);
            return result;
        }

        private IEnumerable<string> GetLines(int pageLength, FileReader fileReder, Func<IEnumerable<string>, int, IEnumerable<string>> func)
        {
            var lines = fileReder.GetFileContent();
            var result = GetLines(pageLength, lines, func);
            return result;
        }
    }
}
