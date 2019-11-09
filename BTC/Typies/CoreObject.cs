using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace BTC.Typies
{
    public abstract class CoreObject
    {
        [BsonId(IdGenerator = typeof(ObjectIDGenerator))]
#pragma warning disable IDE1006 // Naming Styles
        public ObjectId _id { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
