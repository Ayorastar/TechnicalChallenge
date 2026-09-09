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
    public abstract class SQLparam
    {
        public abstract string toSQL();
    }

    // implementations for different data types. 

    // didn't opt for this as have to instantiate new type every time when passing in a parameter. would provide validity checking though

    public class SQLparamString : SQLparam
    {
        private string value;
        public SQLparamString(string value)
        {
            this.value = value;
        }
        public override string toSQL()
        {
            return $"'{value}'";
        }
    }

    public class SQLparamInt : SQLparam
    {
        private int value;
        public SQLparamInt(int value)
        {
            this.value = value;
        }
        public override string toSQL()
        {
            return $"{value}";
        }
    }

    public class SQLparamDouble : SQLparam
    {
        private double value;
        public SQLparamDouble(double value)
        {
            this.value = value;
        }
        public override string toSQL()
        {
            return $"{value}";
        }
    }

    public class SQLparamFloat : SQLparam
    {
        private float value;
        public SQLparamFloat(float value)
        {
            this.value = value;
        }
        public override string toSQL()
        {
            return $"{value}";
        }
    }

    public class SQLparamBool : SQLparam
    {
        private bool value;
        public SQLparamBool(bool value)
        {
            this.value = value;
        }
        public override string toSQL()
        {
            return $"{value}";
        }
    }
}
