﻿using MongoDB.Bson.Serialization.Attributes;

namespace BTC.BlockChainAPI.BlockDetailModels
{
    public partial class APISpendingOutpoint
    {
        [BsonElement("tx_index")]
        public long TxIndex { get; set; }

        [BsonElement("n")]
        public long N { get; set; }
    }
}
