using BTC.Typies;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BTC.BlockChainAPI
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
    public partial class APITx
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
        public List<APIInput> Inputs { get; set; }

        [BsonElement("out")]
        public List<APIOut> Out { get; set; }

        [BsonElement("rbf")]
        public bool? Rbf { get; set; }
    }
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
    public partial class APISpendingOutpoint
    {
        [BsonElement("tx_index")]
        public long TxIndex { get; set; }

        [BsonElement("n")]
        public long N { get; set; }
    }
}
