namespace BTC.Typies
{
    public abstract class JsonMongoObject<T> : CoreObject where T : class, new()
    {
        public static T FromJson(string json) => MongoDB.Bson.Serialization.BsonSerializer.Deserialize<T>(json);
        public string ToJson() => MongoDB.Bson.BsonExtensionMethods.ToJson(this);
    }
}
