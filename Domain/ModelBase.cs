namespace Domain;

public interface IModel
{
    public int Id { get; set; }
}

public class ModelBase : IModel
{
    public int Id { get; set; }
}
