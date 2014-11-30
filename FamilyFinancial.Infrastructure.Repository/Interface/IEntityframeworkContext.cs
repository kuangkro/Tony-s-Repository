using System.Data.Entity;
using FamilyFinancial.Domain.Repositories;

namespace FamilyFinancial.Infrastructure.Repository.Interface
{
    public interface IEntityframeworkContext:IRepositoryContext
    {
        DbContext Context { get; }
    }
}
