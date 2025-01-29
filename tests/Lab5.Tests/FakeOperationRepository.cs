using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Operations;

namespace Lab5.Tests;

public class FakeOperationRepository : IOperationRepository
{
    public IEnumerable<Operation> GetAllOperations(int userId)
    {
        return new List<Operation>();
    }
}
