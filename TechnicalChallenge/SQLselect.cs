using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalChallenge
{
    public class SQLselect : SQLobject
    {

        private Table table { get; }

        public SQLselect(Table table)
        {
            this.table = table;
        }

        public SQLselect Select(List<Column> columns)
        {

            createQuery(columns);
            return this;
        }

        public SQLselect Select()
        {

            createQuery(null);
            return this;
        }

        private void createQuery(List<Column> columns)
        {
            query = $"SELECT * FROM {table.Name}";
            if (columns != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < columns.Count - 1; i++) {
                    sb.Append(columns[i].Name + ",");
                }
                sb.Append(columns[columns.Count - 1].Name);
                query.Replace("*", sb.ToString());
            }


        }

        //public SQLwhere Where
    }
}
