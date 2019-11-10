using BTC.Typies;

namespace BTC.Models
{
    public partial class Counter : JsonMongoObject<Counter>
    {
        public string CollectionName { get; set; }
        public long LatestId { get; set; }
    }
}