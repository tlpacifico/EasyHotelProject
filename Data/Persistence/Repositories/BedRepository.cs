using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Data.Core.Domain;
using Data.Core.Repositories;

namespace Data.Persistence.Repositories
{
    public class BedRepository : Repository<Bed>, IBedRepository
    {
         public BedRepository(EasyHotelDbContext context) 
            : base(context)
        {
        }
    }
}