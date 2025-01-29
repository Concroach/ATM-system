using Lab5.Application.Models.Operations;

namespace ATM;

public interface IOperationRepository
{
    public IEnumerable<Operation> GetAllOperations(Task<int> userId);
}