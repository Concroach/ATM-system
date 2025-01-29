using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Operations;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly AppDbContext _dbContext;

    public OperationRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Operation>> GetAllOperations(int userId)
    {
        return await _dbContext.Operations
            .Where(o => o.AccountId == userId)
            .Select(o => new Operation(o.OperationId, o.AmountBefore, o.AmountDifference, o.AmountAfter))
            .ToListAsync().ConfigureAwait(false);
    }
}