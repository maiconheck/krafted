using System;

namespace Krafted.Framework.SharedKernel.Domain
{
    public static class EntityExtension
    {
        public static void SetNewId(this Entity entity) => entity.Id = Guid.NewGuid();
    }
}