using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data.Dto;

namespace Apexa.IDAL
{
    /// <summary>
    /// inter face for base data, responsible for basic CURD
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseDal<TEntity> where TEntity : BaseDto
    {
        /// <summary>
        /// Get a entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity? Get(long id);

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Add(TEntity entity);
        /// <summary>
        /// update existing entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Update(long id, TEntity entity);
        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id);
    }
}
