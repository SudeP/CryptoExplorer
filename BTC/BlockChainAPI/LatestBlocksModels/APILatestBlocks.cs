using BTC.Typies;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BTC.BlockChainAPI.LatestBlocksModels
{
    public partial class APILatestBlocks : JsonObject<APILatestBlocks>
    {
        [BsonElement("blocks")]
        public List<APILatestBlock> Blocks { get; set; }
    }
}
