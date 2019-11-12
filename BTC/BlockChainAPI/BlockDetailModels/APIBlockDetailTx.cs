using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BTC.BlockChainAPI.BlockDetailModels
{
    public partial class APIBlockDetailTx
    {
        [BsonElement("hash")]
        public string Hash { get; set; }

        [BsonElement("ver")]
        public long Ver { get; set; }

        [BsonElement("vin_sz")]
        public long VinSz { get; set; }

        [BsonElement("vout_sz")]
        public long VoutSz { get; set; }

        [BsonElement("size")]
        public long Size { get; set; }

        [BsonElement("weight")]
        public long Weight { get; set; }

        [BsonElement("fee")]
        public long Fee { get; set; }

        [BsonElement("relayed_by")]
        public string RelayedBy { get; set; }

        [BsonElement("lock_time")]
        public long LockTime { get; set; }

        [BsonElement("tx_index")]
        public long TxIndex { get; set; }

        [BsonElement("double_spend")]
        public bool DoubleSpend { get; set; }

        [BsonElement("result")]
        public object Result { get; set; }

        [BsonElement("balance")]
        public object Balance { get; set; }

        [BsonElement("time")]
        public long Time { get; set; }

        [BsonElement("block_index")]
        public long BlockIndex { get; set; }

        [BsonElement("block_height")]
        public long BlockHeight { get; set; }

        [BsonElement("inputs")]
        public List<APIBlockDetailInput> Inputs { get; set; }

        [BsonElement("out")]
        public List<APIBlockDetailOut> Out { get; set; }

        [BsonElement("rbf")]
        public bool? Rbf { get; set; }
    }
}
