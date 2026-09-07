using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalChallenge
{
    public enum Operator
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        NotEqual,
        Between,
        Like,
        In,
    }

    public enum Join
    {
        INNER,
        LEFT,
        RIGHT,
        FULL,
    }

    public class SQLwhere : SQLselect
    {

        public SQLwhere(Table table) : base(table)
        {
        
        }

        
        public SQLwhere Where(Column column, Operator op, string parameter)
        {

            createQuery(column, op, parameter);
            return this;
        }

        public SQLwhere Where(Column column, Operator op, float parameter)
        {

            createQuery(column, op, parameter);
            return this;
        }

        private void createQuery(Column column, Operator op, string param)
        {
            query += $"WHERE {column.Name} {GetOperatorSymbol(op)} {param}";
        }

        private void createQuery(Column column, Operator op, float param)
        {
            query += $"WHERE {column.Name} {GetOperatorSymbol(op)} {param}";
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
    }
}
