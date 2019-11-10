using BTC.Typies;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BTC.BlockChainAPI.BlockDetailModels
{
    public partial class APIBlock : JsonObject<APIBlock>
    {
        [BsonElement("ver")]
        public long Ver { get; set; }

        [BsonElement("next_block")]
        public List<string> NextBlock { get; set; }

        [BsonElement("time")]
        public long Time { get; set; }

        [BsonElement("bits")]
        public long Bits { get; set; }

        [BsonElement("fee")]
        public long Fee { get; set; }

        [BsonElement("nonce")]
        public long Nonce { get; set; }

        [BsonElement("n_tx")]
        public long NTx { get; set; }

        [BsonElement("size")]
        public long Size { get; set; }

        [BsonElement("block_index")]
        public long BlockIndex { get; set; }

        [BsonElement("main_chain")]
        public bool MainChain { get; set; }

        [BsonElement("height")]
        public long Height { get; set; }

        [BsonElement("weight")]
        public long Weight { get; set; }

        [BsonElement("tx")]
        public List<APITx> Tx { get; set; }

        [BsonElement("hash")]
        public string Hash { get; set; }

        [BsonElement("prev_block")]
        public string PrevBlock { get; set; }

        [BsonElement("mrkl_root")]
        public string MrklRoot { get; set; }
    }
}
