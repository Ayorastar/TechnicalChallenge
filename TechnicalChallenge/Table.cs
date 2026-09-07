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

        public Column Column(string name)
        {
            return new Column($"{Name}.{name}");
        }

        public Column this[string name]
        {
            get
            {
                return new Column($"{Name}.{name}");
            }
        }

        public string ToSql()
        {
            return $"[{Name}]";
        }

    }
}


