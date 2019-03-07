using System;
using System.Collections.Generic;
using SharedKernel.Domain;
using SharedKernel.Transactions;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity>
        where TEntity : Entity
    {
        protected Repository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
        public IEnumerable<TEntity> GetAll() => throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
        public IEnumerable<TEntity> GetAll(object whereConditions) => throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
        public TEntity GetById(Guid id) => throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
        public virtual void Create(TEntity entity) => throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
        public virtual void Update(TEntity entity) => throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
#pragma warning disable CC0057 // Unused parameters
#pragma warning disable CC0091 // Use static method
        public void Delete(TEntity entity) => throw new NotImplementedException();
#pragma warning restore CC0091 // Use static method
#pragma warning restore CC0057 // Unused parameters
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
        public void Delete(Guid id) => throw new NotImplementedException();
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
    }
}