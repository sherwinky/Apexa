﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data.Dto;
using Apexa.IDAL;
using Microsoft.EntityFrameworkCore;

namespace Apexa.DAL
{
    /// <summary>
    /// Base class of dal, responsible for basic CURD
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseDal<TEntity> : IBaseDal<TEntity> where TEntity : BaseDto
    {
        protected readonly AdvisorContext AdvisorContext;

        public BaseDal(AdvisorContext dbContext)
        {
            AdvisorContext = dbContext;
        }

        protected DbSet<TEntity> Entities => AdvisorContext.Set<TEntity>();

        /// <summary>
        /// Get Advisor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity? Get(long id)
        {
            return Entities.FirstOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// Add new advisor
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Add(TEntity entity)
        {
            //add modification time
            entity.LastUpdatedDateTime = DateTime.Now;
            var id = Entities.Add(entity).Entity.Id!.Value;
            AdvisorContext.SaveChanges();
            return id;
        }

        /// <summary>
        /// Update advisor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Update(long id,TEntity entity)
        {
            var oldEntity = this.Get(id);
            if (oldEntity != null)
            {
                this.UpdateEntity(entity,oldEntity);
                this.Entities.Update(oldEntity);
                this.AdvisorContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete advisor
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            var adVisor = Entities.First(c => c.Id == id);
            Entities.Remove(adVisor);
            this.AdvisorContext.SaveChanges();
        }

        protected abstract void UpdateEntity(TEntity source, TEntity  target);
    }
}
