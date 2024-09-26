namespace Template.Domain.Interface;

public interface IUnitOfWork
{
    Task CommitAsync();
}