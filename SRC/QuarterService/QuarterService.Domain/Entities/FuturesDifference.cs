namespace QuarterService.Domain.Entities
{
    public class FuturesDifference
    {
        public Guid Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public decimal QuarterFuturesPrice { get; set; }
        public decimal BiQuarterFuturesPrice { get; set; }
        public decimal Difference {  get; set; }
    }
}
