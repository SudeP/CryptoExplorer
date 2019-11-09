namespace BTC.Interfaces
{
    public interface IBlockChildObject
    {
        public long ParentId { get; set; }
        public long BlockId { get; set; }
    }
}
