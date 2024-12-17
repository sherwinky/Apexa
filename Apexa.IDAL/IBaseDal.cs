using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apexa.Data.Dto;

namespace Apexa.IDAL
{
    public interface IBaseDal<TEntity> where TEntity : BaseDto
    {
        public TEntity? Get(long id);

        public long Add(TEntity entity);
        public void Update(long id, TEntity entity);
        public void Delete(long id);
    }
}
