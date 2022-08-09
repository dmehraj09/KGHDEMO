using Backend.ServiceInterface.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceInterface.context
{
    public interface IDbContext
    {
        
        IDbSet<TEntity> Set<TEntity>() where TEntity: BaseEntity;
        int SaveChanges();       
    }
}
