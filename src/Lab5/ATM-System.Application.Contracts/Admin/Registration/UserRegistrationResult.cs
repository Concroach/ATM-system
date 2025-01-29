namespace Lab5.Application.Contracts.Admin.Registration;

public abstract record UserRegistrationResult
{
    public record Success : UserRegistrationResult;

    public record Failure(string Message) : UserRegistrationResult;
}