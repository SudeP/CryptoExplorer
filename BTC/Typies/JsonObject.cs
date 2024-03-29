﻿namespace BTC.Typies
{
    public abstract class JsonObject<T> where T : class, new()
    {
        public static T FromJson(string json) => MongoDB.Bson.Serialization.BsonSerializer.Deserialize<T>(json);
        public string ToJson() => MongoDB.Bson.BsonExtensionMethods.ToJson(this);
    }
}
