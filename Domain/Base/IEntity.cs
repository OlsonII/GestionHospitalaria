namespace Domain.Base
{
    public interface IEntity<T>
    {
        T Identification { get; set; }
    }
}