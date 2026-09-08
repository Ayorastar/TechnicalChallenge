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

            table = new Table("test", columns);
        }

        [Test]
        public void WhereTestComparisonNumber()
        {
            // where statement with number passed in
            SQLselect sqlwhere = new SQLselect(table).Select(new List<Column> { table["column1"], table["column2"] }).Where(table["column1"], Operator.GreaterThan, 5);
            Assert.That(sqlwhere.toSQL(), Is.EqualTo("SELECT test.column1, test.column2 FROM test WHERE test.column1 > 5"));
        }   

        [Test]
        public void WhereTestComparisonString()
        {
            // where statement with string passed in
            SQLselect sqlwhere = new SQLselect(table).Select(new List<Column> { table["column2"], table["column3"] }).Where(table["column2"], Operator.Equals, "bob");
            Assert.That(sqlwhere.toSQL(), Is.EqualTo("SELECT test.column2, test.column3 FROM test WHERE test.column2 = 'bob'"));
        }

        [Test]
        public void WhereTestComparisonBetweenInt()
        {
            // where statement with between operator
            SQLselect sqlwhere = new SQLselect(table).Select(new List<Column> { table["column1"], table["column3"] }).Where(table["column1"], Operator.Between, 5, 10);
            Assert.That(sqlwhere.toSQL(), Is.EqualTo("SELECT test.column1, test.column3 FROM test WHERE test.column1 BETWEEN 5 AND 10"));
        }

        [Test]
        public void WhereTestComparisonBetweenFloat()
        {
            // where statement with between operator
            SQLselect sqlwhere = new SQLselect(table).Select(new List<Column> { table["column1"], table["column3"] }).Where(table["column1"], Operator.Between, 5.5f, 10.5f);
            Assert.That(sqlwhere.toSQL(), Is.EqualTo("SELECT test.column1, test.column3 FROM test WHERE test.column1 BETWEEN 5.5 AND 10.5"));
        }

        [Test]
        public void WhereTestComparisonInInt()
        {
            // where statement with in operator
            SQLselect sqlwhere = new SQLselect(table).Select(new List<Column> { table["column1"], table["column3"] }).Where(table["column1"], Operator.In, new int[] { 5, 10, 15 });
            Assert.That(sqlwhere.toSQL(), Is.EqualTo("SELECT test.column1, test.column3 FROM test WHERE test.column1 IN (5, 10, 15)"));
        }

        [Test]
        public void WhereTestComparisonInDouble()
        {
            // where statement with in operator
            SQLselect sqlwhere = new SQLselect(table).Select(new List<Column> { table["column1"], table["column3"] }).Where(table["column1"], Operator.In, new double[] { 5.5, 10.5, 15.5 });
            Assert.That(sqlwhere.toSQL(), Is.EqualTo("SELECT test.column1, test.column3 FROM test WHERE test.column1 IN (5.5, 10.5, 15.5)"));
        }

        [Test]
        public void WhereTestComparisonInString()
        {
            // where statement with in operator
            SQLselect sqlwhere = new SQLselect(table).Select(new List<Column> { table["column1"], table["column3"] }).Where(table["column1"], Operator.In, new string[] { "bob", "alice", "charlie" });
            Assert.That(sqlwhere.toSQL(), Is.EqualTo("SELECT test.column1, test.column3 FROM test WHERE test.column1 IN ('bob', 'alice', 'charlie')"));
        }
    }
}
