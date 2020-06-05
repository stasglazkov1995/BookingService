using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BookMe.BookingService.Domain.Abstractions;

namespace BookMe.BookingService.Data.Repositories.Abstractions
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GeneralRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #region FETCHING

        public IQueryable<TEntity> All()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> GetAsync(Guid key)
        {
            return await _dbSet.FirstOrDefaultAsync(entity => entity.Id == key);
        }

        public IQueryable<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        #endregion

        #region ADDING

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRelatedEntity(TEntity relatedEntity)
        {
            await _context.AddAsync(relatedEntity);
        }

        #endregion

        #region EDITING

        public void Edit(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void EditRelated<REntity>(REntity relatedEntity) where REntity : Entity
        {
            _context.Update(relatedEntity);
        }

        #endregion

        #region DELETING

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SAVING

        public async Task SaveAsync()
        {
            // PRocessing modified entities
            foreach (var entity in GetEntitiesByState(EntityState.Modified))
            {
                ++entity.Version;
                entity.ModifiedAt = DateTime.UtcNow;
            }

            // Processing added entities
            foreach (var entity in GetEntitiesByState(EntityState.Added))
            {
                entity.Version = 1;
                entity.CreatedAt = DateTime.UtcNow;
                entity.ModifiedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        #endregion

        #region PRIVATE

        private Entity[] GetEntitiesByState(EntityState state)
        {
            return _context.ChangeTracker.Entries()
             .Where(x => x.State == state)
             .Select(x => (Entity)x.Entity).ToArray();
        }

        #endregion
    }
}
