using BTC.Attributes;
using BTC.Interfaces;
using BTC.Tools;
using BTC.Typies;

namespace BTC.Models
{
    [DbName(Statics.BTCDbName)]
    public partial class SpendingOutpoint : CountableJsonObject<SpendingOutpoint>, IBlockChildObject
    {
        public long ParentId { get; set; }
        public long BlockId { get; set; }
        public long TxIndex { get; set; }
        public long N { get; set; }
    }
}
