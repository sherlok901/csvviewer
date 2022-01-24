using NUnit.Framework;
using System.Linq;

namespace csvviewer.tests
{
    [TestFixture]
    internal class CsvTests
    {
        [Test]
        public void CreateRecords()
        {
            var lines = new[] { "line1", "line2" };
            var records = Csv.CreateRecords(lines);

            Assert.AreEqual(records.Count(), 2);
        }
    }
}
