using Backend.ServiceInterface.context;
using Backend.ServiceInterface.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceInterface.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private IDbContext _context;
        private IDbSet<T> _entities;
        private bool _isDisposed;

        public Repository(IDbContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return this.Entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            
                try
                {
                    if (entity == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    this.Entities.Add(entity);
                    this._context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    var msg = string.Empty;

                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                        }
                    }

                    var fail = new Exception(msg, dbEx);
                    throw fail;
                }

            
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                
                //this.Entities.Attach(entity);
                _context.Set<T>().AddOrUpdate(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var p = this.Entities.SingleOrDefault(x => x.Id == entity.Id);
                this.Entities.Remove(p);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
    }
}
