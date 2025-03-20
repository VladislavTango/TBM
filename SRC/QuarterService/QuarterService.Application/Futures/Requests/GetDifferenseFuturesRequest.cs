using MediatR;
using QuarterService.Domain.Enums;

namespace QuarterService.Application.Futures.Requests
{
    public class GetDifferenseFuturesRequest : IRequest<Decimal>
    {
        public string Quarter { get; set; }
        public string biQuarter { get; set; }
        public TimeFrameEnum TimeFrame { get; set; }
    }
}
