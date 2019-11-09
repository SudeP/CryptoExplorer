using BTC.Interfaces;
using BTC.Typies;

namespace BTC.Models
{
    public partial class SpendingOutpoint : CountableJsonObject<SpendingOutpoint>, IBlockChildObject
    {
        public long ParentId { get; set; }
        public long BlockId { get; set; }
        public long TxIndex { get; set; }
        public long N { get; set; }
    }
}
