using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace TechnicalChallenge.Tests
{
    public class SelectTests
    {
        private Table table;

        [SetUp]
        public void Setup()
        {
            Column column1 = new Column("column1");
            Column column2 = new Column("column2");
            Column column3 = new Column("column3");

            List<Column> columns = new List<Column> { column1, column2, column3 };

            table = new Table("test", columns, "alias");
        }

        [Test]
        public void SelectAll()
        {
            // selecting all columns from the table
            SQLselect sqlselect = new SQLselect(table).Select();
            Assert.That(sqlselect.toSQL(), Is.EqualTo("SELECT * FROM test"));
        }

        [Test]
        public void SelectOne()
        {
            // selecting one column from the table
            SQLselect sqlselect = new SQLselect(table).Select(table["column1"]);
            Assert.That(sqlselect.toSQL(), Is.EqualTo("SELECT test.column1 FROM test"));
        }

        [Test]
        public void SelectSome()
        {
            // selecting some columns from the table
            SQLselect sqlselect = new SQLselect(table).Select(new List<Column> { table["column1"], table["column2"] });
            Assert.That(sqlselect.toSQL(), Is.EqualTo("SELECT test.column1, test.column2 FROM test"));
        }
    }
}
