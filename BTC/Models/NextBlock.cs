using BTC.Attributes;
using BTC.Tools;
using BTC.Typies;

namespace BTC.Models
{
    [DbName(Statics.BTCDbName)]
    public partial class NextBlock : CountableJsonObject<NextBlock>
    {
        public string BlockHash { get; set; }
    }
}
