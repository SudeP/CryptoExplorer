using BTC.Attributes;
using BTC.Tools;
using BTC.Typies;
using System.Collections.Generic;

namespace BTC.Models
{
    [DbName(Statics.BTCDbName)]
    public partial class BlockDetail : CountableJsonObject<BlockDetail>
    {
        public string BlockHash { get; set; }
        public long TxCount { get; set; }
        public long NextBlockCount { get; set; }
        public long Ver { get; set; }
        public long Time { get; set; }
        public long Bits { get; set; }
        public long Fee { get; set; }
        public long Nonce { get; set; }
        public long NTx { get; set; }
        public long Size { get; set; }
        public long BlockIndex { get; set; }
        public bool MainChain { get; set; }
        public long Height { get; set; }
        public long Weight { get; set; }
        public string Hash { get; set; }
        public string PrevBlock { get; set; }
        public string MrklRoot { get; set; }
        public List<NextBlock> NextBlocks { get; set; }
        public List<Tx> Txs { get; set; }
    }
}
