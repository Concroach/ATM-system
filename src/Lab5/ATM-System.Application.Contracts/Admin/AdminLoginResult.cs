namespace Lab5.Application.Contracts.Admin;

public abstract record AdminLoginResult
{
    public record Success : AdminLoginResult;

    public record Failure(string Message) : AdminLoginResult;
}