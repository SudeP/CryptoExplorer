using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BTC.BlockChainAPI.BlockDetailModels
{
    public partial class APIOut
    {
        [BsonElement("type")]
        public long Type { get; set; }

        [BsonElement("spent")]
        public bool Spent { get; set; }

        [BsonElement("value")]
        public long Value { get; set; }

        [BsonElement("spending_outpoints")]
        public List<APISpendingOutpoint> SpendingOutpoints { get; set; }

        [BsonElement("tx_index")]
        public long TxIndex { get; set; }

        [BsonElement("script")]
        public string Script { get; set; }

        [BsonElement("addr")]
        public string Addr { get; set; }

        [BsonElement("n")]
        public long N { get; set; }
    }
}
