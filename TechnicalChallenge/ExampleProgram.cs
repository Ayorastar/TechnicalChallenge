using System;

namespace TechnicalChallenge
{
    class ExampleProgram
    {

        // view the tests for more examples of SQL queries that can be generated using this library
        static void Main(string[] args)
        {
            Column id = new Column("Id");
            Column name = new Column("Name");
            Column important = new Column("Important");
            Column eventid = new Column("EventId");


            Table Events = new Table("Events", new List<Column> { id, name });
            Table EventAttendee = new Table("EventAttendee", new List<Column> { eventid, id, important });
            Table  Attendee = new Table("Attendee", new List<Column> { id, name });

            SQLobject sqlexample = new SQLselect(Events, "e").Select(Events["Name"]).As("e").FullJoin(EventAttendee, Events["Id"], EventAttendee["EventId"])
                .Where(EventAttendee["Important"], Operator.Equals, 1).And(Events["Name"], Operator.Equals, "test");
            Console.WriteLine(sqlexample.toSQL());

            // To prevent the screen from running and closing quickly 
            Console.ReadKey();
        }
    }
}