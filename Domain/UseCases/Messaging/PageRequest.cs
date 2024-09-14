namespace Domain.UseCases.Messaging;

public record PageRequest
{
    public int Page { get; init; } = 1;

    public int Limit { get; init; } = 10;

    public static PageRequest Default { get; } = new();
}
