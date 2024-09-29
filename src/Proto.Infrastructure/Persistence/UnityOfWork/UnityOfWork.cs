using Microsoft.EntityFrameworkCore.Storage;
using Proto.Domain.Interface;
using Proto.Infrastructure.Persistence.Context;

namespace Proto.Infrastructure.Persistence;

public class UnityOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly IDbContextTransaction transaction = context.Database.BeginTransaction();

    public Task CommitAsync()
    {
        return transaction.CommitAsync();
    }
}