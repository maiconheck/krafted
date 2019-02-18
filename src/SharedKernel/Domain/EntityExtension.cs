﻿using System;

namespace SharedKernel.Domain
{
    public static class EntityExtension
    {
        public static void SetNewId(this Entity entity) => entity.Id = Guid.NewGuid();
    }
}