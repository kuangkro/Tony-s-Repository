using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FamilyFinancial.Domain.Repositories
{
    public interface IRepository<AggregateRoot, TKey> where AggregateRoot : class,IAggregateRoot<TKey>
    {

        #region Property

        IRepositoryContext Context { get; }

        #endregion

        #region 持久化操作

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">需要操作的对象</param>
        /// <returns></returns>
        void Add(AggregateRoot entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">需要操作的对象</param>
        /// <returns></returns>
        void Update(AggregateRoot entity);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="entity">需要操作的对象</param>
        void Remove(AggregateRoot entity);
        #endregion


        #region  Query 

        AggregateRoot Find(TKey key);

        IEnumerable<AggregateRoot> GetAll(Expression<Func<AggregateRoot,bool>> exp);

        #endregion
    }
}
