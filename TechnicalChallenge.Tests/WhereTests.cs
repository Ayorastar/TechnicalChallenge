using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace TechnicalChallenge.Tests
{
    public class WhereTests
    {

        private Table table;

        [SetUp]
        public void Setup()
        {
            Column column1 = new Column("column1");
            Column column2 = new Column("column2");
            Column column3 = new Column("column3");

            List<Column> columns = new List<Column> { column1, column2 };

            table = new Table("test", columns, "alias");
        }

        [Test]
        public void WhereTestComparison1()
        {
            // where statement with number passed in
            SQLselect sqlwhere = new SQLselect(table).Select(new List<Column> { table["column1"], table["column2"] }).Where(table["column1"], Operator.GreaterThan, 5);
            Assert.That(sqlwhere.toSQL(), Is.EqualTo("SELECT test.column1, test.column2 FROM test WHERE test.column1 > 5"));
        }   

        [Test]
        public void WhereTestComparison2()
        {
            // where statement with number passed in
            //Column column1 = new Column("column1");
            //Column column2 = new Column("column2");
            SQLselect sqlwhere = new SQLselect(table).Select(new List<Column> { table["column2"], table["column3"] }).Where(table["column2"], Operator.Equals, "bob");
            Assert.That(sqlwhere.toSQL(), Is.EqualTo("SELECT test.column2, test.column3 FROM test WHERE test.column2 = 'bob'"));
        }
    }
}
