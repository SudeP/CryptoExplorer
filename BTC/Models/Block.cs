using BTC.Attributes;
using BTC.Tools;
using BTC.Typies;
using MongoDB.Bson;
using System;

namespace BTC.Models
{
    [DbName(Statics.BTCDbName)]
    public partial class Block : CountableJsonObject<Block>
    {
        public long BlockId { get; set; }
        public BsonInt64 BlockHash { get; set; }
        public DateTime DateTime { get; set; }
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp) => new BsonDateTime(unixTimeStamp).ToUniversalTime();
        public DateTime ConvertUnixTimeStampToDateTime(long unixTimeStamp) => UnixTimeStampToDateTime(unixTimeStamp);
    }
}
