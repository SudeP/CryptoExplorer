using MongoDB.Bson.Serialization.Attributes;

namespace BTC.BlockChainAPI.LatestBlocksModels
{
    public partial class APILatestBlock
    {
        [BsonElement("height")]
        public long Height { get; set; }

        [BsonElement("hash")]
        public string Hash { get; set; }

        [BsonElement("time")]
        public long Time { get; set; }

        [BsonElement("main_chain")]
        public bool MainChain { get; set; }
    }
}
