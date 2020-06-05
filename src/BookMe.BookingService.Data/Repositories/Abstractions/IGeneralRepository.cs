using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using BookMe.BookingService.Domain.Abstractions;

namespace BookMe.BookingService.Data.Repositories.Abstractions
{
    public interface IGeneralRepository<TEntity> where TEntity : Entity
    {
        #region FETCHING

        IQueryable<TEntity> All();

        Task<TEntity> GetAsync(Guid key);

        IQueryable<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);

        #endregion

        #region ADDING

        Task AddAsync(TEntity entity);

        Task AddRelatedEntity(TEntity relatedEntity);

        #endregion

        #region EDITING

        void Edit(TEntity entity);

        void EditRelated<REntity>(REntity relatedEntity) where REntity : Entity;

        #endregion

        #region DELETING

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(IEnumerable<TEntity> entities);

        #endregion

        #region SAVING

        Task SaveAsync();

        #endregion
    }
}
