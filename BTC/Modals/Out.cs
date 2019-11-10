using BTC.Attributes;
using BTC.Interfaces;
using BTC.Tools;
using BTC.Typies;
using System.Collections.Generic;

namespace BTC.Models
{
    [DbName(Statics.BTCDbName)]
    public partial class Out : CountableJsonObject<Out>, IBlockChildObject
    {
        public long ParentId { get; set; }
        public long BlockId { get; set; }
        public long SpendingOutpointCount { get; set; }
        public long Type { get; set; }
        public bool Spent { get; set; }
        public long Value { get; set; }
        public long TxIndex { get; set; }
        public string Script { get; set; }
        public string Addr { get; set; }
        public long N { get; set; }
        public List<SpendingOutpoint> SpendingOutpoints { get; set; }
    }
}
