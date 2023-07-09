namespace TShirt.Photos.App.Infra.Data.Repository;

using Context;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction _transaction;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public void Dispose() => _transaction.Dispose();

    public async Task BeginTransaction()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task Rollback()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}
