using BTC.Attributes;
using BTC.Interfaces;
using BTC.Tools;
using BTC.Typies;
using System.Collections.Generic;

namespace BTC.Models
{
    [DbName(Statics.BTCDbName)]
    public partial class Tx : CountableJsonObject<Tx>, IBlockChildObject
    {
        public long ParentId { get; set; }
        public long BlockId { get; set; }
        public long InputCount { get; set; }
        public long OutCount { get; set; }
        public string Hash { get; set; }
        public long Ver { get; set; }
        public long VinSz { get; set; }
        public long VoutSz { get; set; }
        public long Size { get; set; }
        public long Weight { get; set; }
        public long Fee { get; set; }
        public string RelayedBy { get; set; }
        public long LockTime { get; set; }
        public long TxIndex { get; set; }
        public bool DoubleSpend { get; set; }
        public object Result { get; set; }
        public object Balance { get; set; }
        public long Time { get; set; }
        public long BlockIndex { get; set; }
        public long BlockHeight { get; set; }
        public bool? Rbf { get; set; }
        public List<Input> Inputs { get; set; }
        public List<Out> Outs { get; set; }
    }
}
