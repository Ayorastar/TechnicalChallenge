using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalChallenge
{
    public class Table
    {
        public string Name { get; }

        public string Alias { get; set; }

        public List<Column> Columns { get; }

        public Table(string name, List<Column> columns)
        {
            Name = name;
            Columns = columns;
            Alias = name;
        }

        public Table(string name, List<Column> columns, string alias)
        {
            Name = name;
            Columns = columns;
            Alias = alias;
        }

        public Column Column(string name)
        {
            return new Column($"{Alias}.{name}");
        }

        public Column this[string name]
        {
            get
            {
                return new Column($"{Alias}.{name}");
            }
        }

        public string ToSql()
        {
            return $"[{Alias}]";
        }

        public Table SetAlias(string alias)
        {
            Alias = alias;
            return this;
        }

    }
}


