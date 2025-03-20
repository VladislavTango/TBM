using Microsoft.EntityFrameworkCore;
using QuarterService.DataPersistance.AppContext;
using QuarterService.Domain.Entities;
using QuarterService.Domain.Enums;
using QuarterService.Domain.Interfaces;

namespace QuarterService.DataPersistance.Repository
{
    public class FuturesDifferenceRepository : IFuturesDifferenceRepository
    {
        private readonly AppDbContext _dbContext;

        public FuturesDifferenceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddFuturesDifference(FuturesDifference futuresDifference)
        {
            _dbContext.FuturesDifference.Add(futuresDifference);
            await _dbContext.SaveChangesAsync();

            return futuresDifference.Id;
        }

        public async Task<FuturesDifference?> GetFuturesDifference(string QuarterFutures, string BiQuarterFutures, TimeFrameEnum TimeFrame)
        {
            return await _dbContext.FuturesDifference
                .Where
                    (x => x.TimeFrame == TimeFrame 
                    && x.QuarterFutures == QuarterFutures 
                    && x.BiQuarterFutures == BiQuarterFutures)
                 .FirstOrDefaultAsync();
        }
    }
}
