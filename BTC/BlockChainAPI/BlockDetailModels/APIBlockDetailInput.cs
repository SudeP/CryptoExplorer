using MongoDB.Bson.Serialization.Attributes;

namespace BTC.BlockChainAPI.BlockDetailModels
{
    public partial class APIBlockDetailInput
    {
        [BsonElement("sequence")]
        public long Sequence { get; set; }

        [BsonElement("witness")]
        public string Witness { get; set; }

        [BsonElement("script")]
        public string Script { get; set; }

        [BsonElement("index")]
        public long Index { get; set; }

        [BsonElement("prev")]
        public APIBlockDetailOut Prev { get; set; }

        [BsonElement("prev_out")]
        public APIBlockDetailOut PrevOut { get; set; }
    }
}
