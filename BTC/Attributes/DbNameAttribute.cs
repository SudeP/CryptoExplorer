using System;

namespace BTC.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DbNameAttribute : Attribute
    {
        public string DbName { get; private set; }
        public DbNameAttribute(string dbName)
        {
            DbName = dbName;
        }
    }
}
