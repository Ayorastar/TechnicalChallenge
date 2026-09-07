using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace TechnicalChallenge.Tests
{
    public class JoinTests
    {

        private Table table1;
        private Table table2;

        [SetUp]
        public void Setup()
        {
            Column column1 = new Column("column1");
            Column column2 = new Column("column2");
            Column column3 = new Column("column3");




            List<Column> columns1 = new List<Column> { column1, column2 };
            List<Column> columns2 = new List<Column> { column2, column3 };

            table1 = new Table("test1", columns1, "alias1");
            table2 = new Table("test2", columns2, "alias2");
        }

        [Test]
        public void InnerJoin()
        {
            // where statement with number passed in
            SQLselect sqljoin = new SQLselect(table1).Select(table1["column1"]).InnerJoin(table2, table1["column2"], table2["column2"]);
            Assert.That(sqljoin.toSQL(), Is.EqualTo("SELECT test1.column1, test2.column2 FROM test1 INNER JOIN test2 ON test1.column2 = test2.column2"));
        }

        [Test]
        public void LeftJoin()
        {
            // where statement with number passed in
            SQLselect sqljoin = new SQLselect(table1).Select(table1["column1"]).LeftJoin(table2, table1["column2"], table2["column2"]);
            Assert.That(sqljoin.toSQL(), Is.EqualTo("SELECT test1.column1, test2.column2 FROM test1 LEFT JOIN test2 ON test1.column2 = test2.column2"));
        }

        [Test]
        public void RightJoin()
        {
            // where statement with number passed in
            SQLselect sqljoin = new SQLselect(table1).Select(table1["column1"]).RightJoin(table2, table1["column2"], table2["column2"]);
            Assert.That(sqljoin.toSQL(), Is.EqualTo("SELECT test1.column1, test2.column2 FROM test1 RIGHT JOIN test2 ON test1.column2 = test2.column2"));
        }

        [Test]
        public void FullJoin()
        {
            // where statement with number passed in
            SQLselect sqljoin = new SQLselect(table1).Select(table1["column1"]).FullJoin(table2, table1["column2"], table2["column2"]);
            Assert.That(sqljoin.toSQL(), Is.EqualTo("SELECT test1.column1, test2.column2 FROM test1 FULL JOIN test2 ON test1.column2 = test2.column2"));
        }

    }
}
