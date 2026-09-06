using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalChallenge.Tests
{
    public class ColumnTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ColumnTest()
        {
            Column column = new Column("test");
            Assert.That(column.Name, Is.EqualTo("test"));
        }
    }
}
