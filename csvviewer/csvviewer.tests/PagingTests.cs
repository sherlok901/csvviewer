using NUnit.Framework;
using System.Linq;

namespace csvviewer.tests
{
    [TestFixture]
    public class PagingTests
    {
        [Test]
        public void ExtractLastPage_1()
        {
            var p = new Paging();
            var lines = new[] { "line1", "line2"};
            var result = p.ExtractLastPage(lines, 2);

            Assert.AreEqual(lines[1], result.First());
        }
    }
}
