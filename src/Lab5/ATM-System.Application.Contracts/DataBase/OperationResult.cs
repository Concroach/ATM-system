namespace Lab5.Application.Contracts.DataBase;

public abstract record OperationResult
{
    public record Success(Models.Users.User User) : OperationResult;

    public record InsufficientFunds(Models.Users.User CurrentUser) : OperationResult;

    public record Failure(string Message) : OperationResult;
}