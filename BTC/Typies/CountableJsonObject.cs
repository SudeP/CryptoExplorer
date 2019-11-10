using BTC.Interfaces;
using BTC.Models;
using BTC.Tools;
using MongoDB.Driver;
using System;

namespace BTC.Typies
{
    public class CountableJsonObject<T> : JsonMongoObject<T>, IUniqueObject where T : class, new()
    {
        public long UniqueId { get; set; }
        public static long NewId(MongoDatabaseBase mongoDatabaseBase, DateTime? dateTime = null) => mongoDatabaseBase.GetCollection<Counter>(nameof(Counter)).FindOneAndUpdate(c => c.CollectionName == (typeof(T).Name + (dateTime.HasValue ? $"_{Statics.DateToString(dateTime.Value)}" : "")), Builders<Counter>.Update.Inc(c => c.LatestId, 1)).LatestId;
        public long GetNewId(MongoDatabaseBase mongoDatabaseBase, DateTime? dateTime = null) => NewId(mongoDatabaseBase, dateTime);
    }
}
