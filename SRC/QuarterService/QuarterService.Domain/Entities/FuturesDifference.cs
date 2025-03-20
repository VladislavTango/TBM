using QuarterService.Domain.Enums;

namespace QuarterService.Domain.Entities
{
    public class FuturesDifference
    {
        public Guid Id { get; set; }
        public TimeFrameEnum TimeFrame { get; set; }
        public string QuarterFutures { get; set; }
        public string BiQuarterFutures { get; set; }
        public decimal QuarterFuturesPrice { get; set; }
        public decimal BiQuarterFuturesPrice { get; set; }
        public decimal Difference {  get; set; }
    }
}
