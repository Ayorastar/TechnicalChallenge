using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace TechnicalChallenge.Tests
{
    public class Tests
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


            Events = new Table("Events", new List<Column> { id, name }, "alias1");
            EventAttendee = new Table("EventAttendee", new List<Column> { eventid, id, important }, "alias2");
            Attendee = new Table("Attendee", new List<Column> { id, name }, "alias3");
        }

        [Test]
        public void Example1()  
        {
            // where statement with number passed in
            SQLselect sqljoin = new SQLselect(Events).Select().InnerJoin(EventAttendee, Events["Id"], EventAttendee["EventId"]).InnerJoin(Attendee, EventAttendee["AttendeeId"], Attendee["Id"]).Where();
            new SQLselect(Events).Select(Events.Id, Events.Name)
//    .InnerJoin(
//        EventAttendee,
//        Where.Equal(Events.Id, EventAttendee.EventId))
//    .InnerJoin(
//        Attendee,
//        Where.Equal(EventAttendee.AttendeeId, Attendee.Id))
//    .Where(
//        Where.Equal(Attendee.Name, "bob")
//            .Or(Where.Equal(Events.Important, true)));
            Assert.That(sqljoin.toSQL(), Is.EqualTo("SELECT test1.column1, test2.column2 FROM test1 INNER JOIN test2 ON test1.column2 = test2.column2"));
        }

    }
}
