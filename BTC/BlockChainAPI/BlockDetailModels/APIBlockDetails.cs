using BTC.Typies;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BTC.BlockChainAPI.BlockDetailModels
{
    public partial class APILatestBlocks : JsonObject<APILatestBlocks>
    {
        [BsonElement("blocks")]
        public List<APIBlock> Blocks { get; set; }
    }
}