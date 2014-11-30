using System;
using FamilyFinancial.Infrastructure;

namespace FamilyFinancial.Domain.Repositories
{
    public interface IRepositoryContext:IUnitOfWork,IDisposable
    {
        /// <summary>
        /// Context唯一标识
        /// </summary>
        string ID { get; }

        /// <summary>
        /// Registers a new object to the repository context.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TKey"> </typeparam>
        /// <param name="obj">The object to be registered.</param>
        void RegisterNew<TAggregateRoot,TKey>(TAggregateRoot obj)
            where TAggregateRoot : class, IAggregateRoot<TKey>;

        /// <summary>
        /// Registers a modified object to the repository context.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TKey"> </typeparam>
        /// <param name="obj">The object to be registered.</param>
        void RegisterModified<TAggregateRoot,TKey>(TAggregateRoot obj)
            where TAggregateRoot : class, IAggregateRoot<TKey>;

        /// <summary>
        /// Registers a deleted object to the repository context.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TKey"> </typeparam>
        /// <param name="obj">The object to be registered.</param>
        void RegisterDeleted<TAggregateRoot, TKey>(TAggregateRoot obj)
            where TAggregateRoot : class, IAggregateRoot<TKey>;
    }
}
