using MediatR;
using QuarterService.Application.Futures.Requests;
using QuarterService.Domain.Interfaces;
using QuarterService.Infrastructure.Interfaces;

namespace QuarterService.Application.Futures.Handlers
{
    public class GetDifferenseFuturesHandler : IRequestHandler<GetDifferenseFuturesRequest, decimal>
    {
        private readonly IBinanceClient _binanceClient;
        private readonly IFuturesDifferenceRepository _futuresDifferenceRepository;

        public GetDifferenseFuturesHandler(IBinanceClient binanceClient, IFuturesDifferenceRepository futuresDifferenceRepository)
        {
            _binanceClient = binanceClient;
            _futuresDifferenceRepository = futuresDifferenceRepository;
        }

        public async Task<decimal> Handle(GetDifferenseFuturesRequest request, CancellationToken cancellationToken)
        {
            var Futures = await _futuresDifferenceRepository.GetFuturesDifference(request.Quarter, request.biQuarter, request.TimeFrame);

            if (Futures != null)
                return Futures.Difference;

            var Quarter =await _binanceClient.GetCandlestickHighPrice(request.Quarter , request.TimeFrame);
            var biQuarter =await  _binanceClient.GetCandlestickHighPrice(request.biQuarter, request.TimeFrame);

            decimal Difrence = biQuarter - Quarter;

            Futures = new() 
            {
                Id = new Guid(),
                Difference = Difrence,
                BiQuarterFutures=request.biQuarter,
                QuarterFutures=request.Quarter,
                BiQuarterFuturesPrice = biQuarter,
                QuarterFuturesPrice = Quarter,
                TimeFrame = request.TimeFrame
            };

            await _futuresDifferenceRepository.AddFuturesDifference(Futures);

            return Futures.Difference;
        }
    }
}
