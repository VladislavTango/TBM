using QuarterService.Domain.Enums;
using QuarterService.Infrastructure.DTO;

namespace QuarterService.Infrastructure.Interfaces
{
    public interface IBinanceClient
    {
        public Task<CandlestickDataBinance> GetCandlestickData(string symbol, TimeFrameEnum timeFrame);
        // В будущем можно добавить другие методы
    }
}
