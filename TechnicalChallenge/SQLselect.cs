using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // Select Queries

        public SQLselect Select(List<Column> columns)
        {

            createSelectQuery(columns);
            return this;
        }

        public SQLselect Select(Column column)
        {

            createOneSelectQuery(column);
            return this;
        }

        public SQLselect Select()
        {

            createOneSelectQuery(null);
            return this;
        }

        private void createSelectQuery(List<Column> columns)
        {
            if (columns == null || columns.Count == 0)
            {
                query = $"SELECT * FROM {table.Name}";
                return;
            }

            string columnNames = string.Join(
                ", ",
                columns.Select(c => c.Name)
            );

            query = $"SELECT {columnNames} FROM {table.Name}";
        }

        private void createOneSelectQuery(Column column)
        {
            if (column == null)
            {
                query = $"SELECT * FROM {table.Name}";
                return;
            }
            query = $"SELECT {column.Name} FROM {table.Name}";
        }

        //Where Queries

        public SQLselect Where(Column column, Operator op, string parameter)
        {

            createWhereQuery(column, op, parameter);
            return this;
        }

        public SQLselect Where(Column column, Operator op, float parameter)
        {

            createWhereQuery(column, op, parameter);
            return this;
        }

        private void createWhereQuery(Column column, Operator op, string param)
        {
            query += $" WHERE {column.Name} {GetOperatorSymbol(op)} '{param}'";
        }

        private void createWhereQuery(Column column, Operator op, float param)
        {
            query += $" WHERE {column.Name} {GetOperatorSymbol(op)} {param}";
        }

        private string GetOperatorSymbol(Operator op)
        {
            return op switch
            {
                Operator.Equals => "=",
                Operator.GreaterThan => ">",
                Operator.LessThan => "<",
                Operator.GreaterThanOrEqual => ">=",
                Operator.LessThanOrEqual => "<=",
                Operator.NotEqual => "<>",
                Operator.Between => "BETWEEN",
                Operator.Like => "LIKE",
                Operator.In => "IN",
                _ => throw new ArgumentException("Invalid operator"),
            };
        }


        // Joins

        // Inner Join
        public SQLselect InnerJoin(Table table, Column column1, Column column2)
        {

            createJoinQuery(table, column1, column2, Join.INNER);
            return this;
        }


        // Left Join
        public SQLselect LeftJoin(Table table, Column column1, Column column2)
        {

            createJoinQuery(table, column1, column2, Join.LEFT);
            return this;
        }

        
        // Right Join
        public SQLselect RightJoin(Table table, Column column1, Column column2)
        {

            createJoinQuery(table, column1, column2, Join.RIGHT);
            return this;
        }

        // Full Join
        public SQLselect FullJoin(Table table, Column column1, Column column2)
        {

            createJoinQuery(table, column1, column2, Join.FULL);
            return this;
        }

        private void createJoinQuery(Table table, Column column1, Column column2, Join join)
        {
            query += $" {join} JOIN {table.Name} ON {column1.Name} = {column2.Name}";
        }

    }
}
