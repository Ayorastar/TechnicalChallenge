using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace TechnicalChallenge.Tests
{
    public class AliasTests
    {
        private Table table;

        [SetUp]
        public void Setup()
        {
            Column column1 = new Column("column1");
            Column column2 = new Column("column2");
            Column column3 = new Column("column3");

            List<Column> columns = new List<Column> { column1, column2, column3 };

            table = new Table("test", columns);
        }

        [Test]
        public void TableAliases()
        {
            // using an alias for the table
            SQLobject sqlalias = new SQLselect(table, "alias").Select(table["column1"]).As("alias");
            Assert.That(sqlalias.toSQL(), Is.EqualTo("SELECT alias.column1 FROM test AS alias"));
        }
        [Test]
        public void ColumnAliases()
        {
            // using an alias for columns
            SQLobject sqlalias = new SQLselect(table, "alias2").Select(new List<Tuple<Column, string>> { new Tuple<Column, string>(table["column1"], "alias") }).As("alias2");
            Assert.That(sqlalias.toSQL(), Is.EqualTo("SELECT alias2.column1 AS alias FROM test AS alias2"));
        }
    }
}
