using QuarterService.Domain.Enums;

namespace QuarterService.Infrastructure.Interfaces
{
    public interface IBinanceClient
    {
        public Task<Decimal> GetCandlestickHighPrice(string symbol, TimeFrameEnum timeFrame);
        // В будущем можно добавить другие методы
    }
}
