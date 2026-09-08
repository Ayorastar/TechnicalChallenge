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
        public SQLselect(Table table, string alias)
        {
            this.table = table;
            this.table.SetAlias(alias);
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
        public SQLselect Select(List<Tuple<Column, string>> columnAliases)
        {

            createSelectAliasQuery(columnAliases);
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
                columns.Select(c => c.Alias)
            );

            query = $"SELECT {columnNames} FROM {table.Name}";
        }

        private void createOneSelectQuery(Column column)
        {
            if (column == null)
            {
                query = $"SELECT * FROM {table.Alias}";
                return;
            }
            query = $"SELECT {column.Alias} FROM {table.Name}";
        }

        private void createSelectAliasQuery(List<Tuple<Column, string>> columnAliases)
        {
            if (columnAliases == null || columnAliases.Count == 0)
            {
                query = $"SELECT * FROM {table.Name}";
                return;
            }
            string columnNames = string.Join(
                ", ",
                columnAliases.Select(ca => $"{ca.Item1.Alias} AS {ca.Item2}")
            );
            query = $"SELECT {columnNames} FROM {table.Name}";
        }

        //Where Queries

        public SQLselect Where(Column column, Operator op, float parameter)
        {
            createWhereQuery(column, op, parameter);
            return this;
        }

        public SQLselect Where(Column column, Operator op, int parameter)
        {
            createWhereQuery(column, op, parameter);
            return this;
        }

        public SQLselect Where(Column column, Operator op, string parameter)
        {
            createWhereQuery(column, op, parameter);
            return this;
        }

        // between operator
        public SQLselect Where(Column column, Operator op, float param1, float param2)
        {
            createWhereBetweenQuery(column, op, param1, param2);
            return this;
        }

        // in operator
        public SQLselect Where(Column column, Operator op, int[] list)
        {
            createWhereInQuery(column, op, list);
            return this;
        }

        public SQLselect Where(Column column, Operator op, double[] list)
        {
            createWhereInQuery(column, op, list);
            return this;
        }

        public SQLselect Where(Column column, Operator op, string[] list)
        {
            createWhereInQuery(column, op, list);
            return this;
        }

        // for every operator except in and between
        private void createWhereQuery(Column column, Operator op, object param)
        {
            if (param is string text)
            {
                query += $" WHERE {column.Alias} {GetOperatorSymbol(op)} '{text}'";
            }
            else
            {
                query += $" WHERE {column.Alias} {GetOperatorSymbol(op)} {param}";
            }
        }

        // for in operator. could add more data types
        private void createWhereInQuery(Column column, Operator op, string[] list)
        {
            string formattedList = string.Join(", ", list.Select(item => $"'{item}'"));
            query += $" WHERE {column.Alias} {GetOperatorSymbol(op)} ({formattedList})";
        }

        private void createWhereInQuery(Column column, Operator op, double[] list)
        {
            string formattedList = string.Join(", ", list.Select(item => $"{item}"));
            query += $" WHERE {column.Alias} {GetOperatorSymbol(op)} ({formattedList})";
        }

        private void createWhereInQuery(Column column, Operator op, int[] list)
        {
            string formattedList = string.Join(", ", list.Select(item => $"{item}"));
            query += $" WHERE {column.Alias} {GetOperatorSymbol(op)} ({formattedList})";
        }

        // for between operator
        private void createWhereBetweenQuery(Column column, Operator op, float param1, float param2)
        {
            query += $" WHERE {column.Alias} {GetOperatorSymbol(op)} {param1} AND {param2}";
        }

        //And/Or Queries

        public SQLselect And(Column column, Operator op, object parameter)
        {

            createAndQuery(column, op, parameter);
            return this;
        }

        public SQLselect Or(Column column, Operator op, object parameter)
        {

            createOrQuery(column, op, parameter);
            return this;
        }

        private void createAndQuery(Column column, Operator op, object param)
        {
            if (param is string text)
            {
                query += $" AND {column.Alias} {GetOperatorSymbol(op)} '{text}'";
            }
            else
            {
                query += $" AND {column.Alias} {GetOperatorSymbol(op)} {param}";
            }
        }

        private void createOrQuery(Column column, Operator op, object param)
        {
            if (param is string text)
            {
                query += $" OR {column.Alias} {GetOperatorSymbol(op)} '{text}'";
            }
            else
            {
                query += $" OR {column.Alias} {GetOperatorSymbol(op)} {param}";
            }
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
            query += $" {join} JOIN {table.Alias} ON {column1.Alias} = {column2.Alias}";
        }

        public SQLselect As(string alias)
        {
            query += $" AS {alias}";
            return this;
        }

    }
}
