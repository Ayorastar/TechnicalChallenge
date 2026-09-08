using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace TechnicalChallenge.Tests
{
    public class ExampleQueries
    {

        private Table Events;
        private Table EventAttendee;
        private Table Attendee;

        [SetUp]
        public void Setup()
        {
            Column id = new Column("Id");
            Column name = new Column("Name");
            Column important = new Column("Important");
            Column eventid = new Column("EventId");


            Events = new Table("Events", new List<Column> { id, name });
            EventAttendee = new Table("EventAttendee", new List<Column> { eventid, id, important });
            Attendee = new Table("Attendee", new List<Column> { id, name });
        }

        [Test]
        public void Example1()  
        {
            // where statement with number passed in
            SQLobject sqljoin = new SQLselect(Events).Select().InnerJoin(EventAttendee, Events["Id"], EventAttendee["EventId"])
                .InnerJoin(Attendee, EventAttendee["AttendeeId"], Attendee["Id"]).Where(Attendee["Name"], Operator.Equals, "bob")
                .Or(Events["Important"], Operator.Equals, 1);
            Assert.That(sqljoin.toSQL(), Is.EqualTo("SELECT * FROM Events INNER JOIN EventAttendee ON Events.Id = EventAttendee.EventId " +
                "INNER JOIN Attendee ON EventAttendee.AttendeeId = Attendee.Id WHERE Attendee.Name = 'bob' " +
                "OR Events.Important = 1"));
        }

    }
}
