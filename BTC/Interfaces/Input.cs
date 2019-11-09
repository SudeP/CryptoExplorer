using BTC.Models;
using BTC.Typies;

namespace BTC.Interfaces
{
    public class Input : CountableJsonObject<Input>, IBlockChildObject
    {
        public long ParentId { get; set; }
        public long BlockId { get; set; }
        public long Sequence { get; set; }
        public string Witness { get; set; }
        public string Script { get; set; }
        public long Index { get; set; }
        public long PrevId { get; set; }
        public long PrevOutId { get; set; }
        public Out Prev { get; set; }
        public Out PrevOut { get; set; }
        public bool HasPrev { get; set; }
        public bool HasPrevOut { get; set; }
    }
}
