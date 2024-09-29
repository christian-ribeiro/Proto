namespace Proto.Domain.Interface;

public interface IUnitOfWork
{
    Task CommitAsync();
}