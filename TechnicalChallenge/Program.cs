using System;

namespace TechnicalChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

//var query = new SelectQuery(Events)
//    .Select(Events.Id, Events.Name)
//    .InnerJoin(
//        EventAttendee,
//        Where.Equal(Events.Id, EventAttendee.EventId))
//    .InnerJoin(
//        Attendee,
//        Where.Equal(EventAttendee.AttendeeId, Attendee.Id))
//    .Where(
//        Where.Equal(Attendee.Name, "bob")
//            .Or(Where.Equal(Events.Important, true)));

//var sql = query.ToSql();