using MongoDB.Bson.Serialization.Attributes;

namespace BTC.BlockChainAPI.BlockDetailModels
{
    public partial class APIInput
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
        public APIOut Prev { get; set; }

        [BsonElement("prev_out")]
        public APIOut PrevOut { get; set; }
    }
}
