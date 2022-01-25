using System.Collections.Generic;
using System.Linq;

namespace csvviewer.core
{
    public class Formatter
    {
        public IEnumerable<string> Format(IEnumerable<Record> records)
        {
            var columnWidths = CalculateMaxColumnWidths(records);
            var paddedRecords = PadRecords(records, columnWidths);
            var lines = FormatValues(paddedRecords);
            return lines;
        }

        private int[] CalculateMaxColumnWidths(IEnumerable<Record> records)
        {
            var noOfColumns = records.First().Values.Length;
            var result = new int[noOfColumns];

            for (var i = 0; i < noOfColumns; i++)
            {
                var max = records.Select(record => record.Values[i]).Max(value => value.Length);
                if (max > result[i])
                    result[i] = max;
            }

            return result;
        }

        private IEnumerable<Record> PadRecords(IEnumerable<Record> records, int[] columnWidths)
        {
            var result = records.ToArray();
            foreach (var record in result)
            {
                for (var i = 0; i < record.Values.Length; i++)
                {
                    record.Values[i] = record.Values[i].PadRight(columnWidths[i]);
                }
            }
            return result;
        }

        private IEnumerable<string> FormatValues(IEnumerable<Record> paddedRecords)
        {
            return paddedRecords.Select(record => string.Join("|", record.Values));
        }
    }
}
