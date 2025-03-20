using QuarterService.Domain.Entities;
using QuarterService.Domain.Enums;

namespace QuarterService.Domain.Interfaces
{
    public interface IFuturesDifferenceRepository
    {
        public Task<FuturesDifference> GetFuturesDifference(string QuarterFutures, string BiQuarterFutures, TimeFrameEnum TimeFrame);
        public Task<Guid> AddFuturesDifference(FuturesDifference futuresDifference);
    }
}
