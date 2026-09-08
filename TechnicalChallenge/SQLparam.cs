using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalChallenge
{
    public abstract class SQLparam
    {
        public abstract string toSQL();
    }

    // implementations for different data types. could add more if needed

    // opted for this for validity checking but unfortunately have to instantiate new type every time when passing in a parameter

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
