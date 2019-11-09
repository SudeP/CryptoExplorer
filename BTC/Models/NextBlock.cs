using BTC.Typies;

namespace BTC.Models
{
    public class NextBlock : CountableJsonObject<NextBlock>
    {
        public string BlockHash { get; set; }
    }
}
