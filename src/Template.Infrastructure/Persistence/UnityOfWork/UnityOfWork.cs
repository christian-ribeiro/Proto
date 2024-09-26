using Microsoft.EntityFrameworkCore.Storage;
using Template.Domain.Interface;
using Template.Infrastructure.Persistence.Context;

namespace Template.Infrastructure.Persistence;

public class UnityOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly IDbContextTransaction transaction = context.Database.BeginTransaction();

    public Task CommitAsync()
    {
        return transaction.CommitAsync();
    }
}