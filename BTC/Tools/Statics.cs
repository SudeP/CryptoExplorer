using System;

namespace BTC.Tools
{
    public class Statics
    {
        public const string BTCDbName = "BTC";
        public static string DateToString(DateTime dateTime) => dateTime.ToString("_yyyy_MM");
    }
}
