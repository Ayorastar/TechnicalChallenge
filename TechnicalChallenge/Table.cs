using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalChallenge
{
    public class Table
    {
        public string Name { get; }

        public string Alias { get; }

        public List<Column> Columns { get; }

        public Table(string name, List<Column> columns, string alias)
        {
            Name = name;
            Columns = columns;
            Alias = alias;
        }

        public string ToSql()
        {
            return $"[{Name}]";
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