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
        private EmployeeContext _context;
        private IDbSet<T> _entities;
        private bool _isDisposed;
        private DbContextTransaction _objTran;

        public Repository(EmployeeContext context)
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
                   throw new ArgumentNullException(nameof(entity));
               }
               this.Entities.Add(entity);                    
           }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                throw new Exception(GetDetailedExceptions(dbEx, msg));
            }
        }

        public void Update(T entity)
        {
              try
                {
                    if (entity == null)
                    {
                    throw new ArgumentNullException(nameof(entity));
                }

                    //this.Entities.Attach(entity);
                    _context.Set<T>().AddOrUpdate(entity);
                                       
               }
               catch (DbEntityValidationException dbEx)
               {

                var msg = string.Empty;
                throw new Exception(GetDetailedExceptions(dbEx, msg));                
               }

        }      

        public void Delete(T entity)
        {
            
                try
                {
                    if (entity == null)
                    {
                    throw new ArgumentNullException(nameof(entity));
                    }
                    var p = this.Entities.SingleOrDefault(x => x.Id == entity.Id);
                    this.Entities.Remove(p);                    
                }
                catch (DbEntityValidationException dbEx)
                {
                    var msg = string.Empty;
                    throw new Exception(GetDetailedExceptions(dbEx, msg));
                }            
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                throw new Exception(GetDetailedExceptions(dbEx, msg));
            }
        }

        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }
        //If all the Transactions are completed successfuly then we need to call this Commit() 
        //method to Save the changes permanently in the database
        public void Commit()
        {
            _objTran.Commit();
        }
        //If atleast one of the Transaction is Failed then we need to call this Rollback() 
        //method to Rollback the database changes to its previous state
        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }
        //This Save() Method Implement DbContext Class SaveChanges method so whenever we do a transaction we need to
        //call this Save() method so that it will make the changes in the database
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

        private static string GetDetailedExceptions(DbEntityValidationException dbEx, string msg)
        {
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }

            return msg;
        }

    }
}
