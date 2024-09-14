namespace Domain.UseCases.Messaging;

public class Envelope<T>(T content)
{
    public T Content { get; set; } = content;
}