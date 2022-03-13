using MongoDB.Driver;

using Rise.Phone.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rise.Phone.Data
{
    /// <summary>
    /// Defines the <see cref="MongoRepository{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    public partial class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        /// <summary>
        /// Defines the _collection.
        /// </summary>
        private readonly IMongoCollection<TEntity> _collection;

        /// <summary>
        /// Defines the _mongoDbSettings.
        /// </summary>
        private readonly PhoneDbSettings _mongoDbSettings;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="mongoDbSettings">The mongoDbSettings<see cref="PhoneDbSettings"/>.</param>
        public MongoRepository(PhoneDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;

            MongoClient client = new MongoClient(_mongoDbSettings.ConnectionString);
            IMongoDatabase db = client.GetDatabase(_mongoDbSettings.Database);
            _collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Table.
        /// </summary>
        public IQueryable<TEntity> Table => _collection.AsQueryable();

        #endregion

        #region Methods

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            _collection.FindOneAndDelete(filter);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        public void Delete(string id)
        {
            _collection.FindOneAndDelete(x => x.Id == id);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        public void Delete(TEntity entity)
        {
            _collection.FindOneAndDelete(x => x.Id == entity.Id);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            await _collection.FindOneAndDeleteAsync(filter);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task DeleteAsync(string id)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task DeleteAsync(TEntity entity)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        /// <summary>
        /// The GetAll.
        /// </summary>
        /// <returns>The <see cref="List{TEntity}"/>.</returns>
        public List<TEntity> GetAll()
        {
            return _collection.AsQueryable().ToList();
        }

        /// <summary>
        /// The GetById.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="TEntity"/>.</returns>
        public TEntity GetById(string id)
        {
            return _collection.Find(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// The GetByIdAsync.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TEntity}"/>.</returns>
        public virtual Task<TEntity> GetByIdAsync(string id)
        {
            return _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        public void Insert(TEntity entity)
        {
            InsertOneOptions options = new InsertOneOptions { BypassDocumentValidation = false };
            _collection.InsertOne(entity, options);
        }

        /// <summary>
        /// The InsertAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task InsertAsync(TEntity entity)
        {
            InsertOneOptions options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options);
        }

        /// <summary>
        /// The InsertRange.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        public void InsertRange(IEnumerable<TEntity> entities)
        {
            BulkWriteOptions options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            bool result = (_collection.BulkWrite((IEnumerable<WriteModel<TEntity>>)entities, options)).IsAcknowledged;
        }

        /// <summary>
        /// The InsertRangeAsync.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{TEntity}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            BulkWriteOptions options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            bool result = (await _collection.BulkWriteAsync((IEnumerable<WriteModel<TEntity>>)entities, options)).IsAcknowledged;
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        public void Update(TEntity entity)
        {
            _collection.FindOneAndReplace(x => x.Id == entity.Id, entity);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        public void Update(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            _collection.FindOneAndReplaceAsync(predicate, entity);
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/>.</param>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            await _collection.FindOneAndReplaceAsync(predicate, entity);
        }

        #endregion
    }
}
