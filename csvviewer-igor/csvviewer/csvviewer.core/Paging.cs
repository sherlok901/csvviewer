using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvviewer.core
{
    public class Paging
    {
        private int _currentPageNo;

        public IEnumerable<string> ExtractFirstPage(IEnumerable<string> lines, int pageLength)
        {
            _currentPageNo = 1;
            return lines.Take(pageLength);
        }
    }
}
