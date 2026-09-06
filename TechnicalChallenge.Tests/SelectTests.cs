using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace TechnicalChallenge.Tests
{
    public class SelectTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SelectTest1()
        {
            Column column1 = new Column("column1");
            Column column2 = new Column("column2");

            List<Column> columns = new List<Column> { column1, column2 };

            Table table = new Table("test", columns, "alias");

            SQLselect sqlselect = new SQLselect (table).Select();
            Assert.That(sqlselect.toSQL(), Is.EqualTo("SELECT * FROM test"));
        }
    }
}
