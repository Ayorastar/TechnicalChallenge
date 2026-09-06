using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalChallenge
{
    public class Column
    {
        public string Name { get; }

        public string? Alias { get; }

        public Column(string name, string? alias=null)
        {
            Name = name;
            Alias = alias;
        }

    }
}
