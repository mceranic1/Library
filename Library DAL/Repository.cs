using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_DAL
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        protected LibContext _context;
        protected DbSet<Entity> dbSet;
      
        public Repository(LibContext context)
        {
            _context = context;  // Dependency Injection
            dbSet = _context.Set<Entity>();
        }
        public virtual IQueryable<Entity> Get()  // vraca citavu kolekciju iz Authors, Books, Publishers
        {
            return dbSet;
        }
        public IList<Entity> Get(Func<Entity, bool> where)
        {
            IList<Entity> list;
            IQueryable<Entity> dbQuery = Get();
            list = dbQuery.Where(where).ToList();
            return list;
        }
        public virtual Entity Get(int id)
        {
            return dbSet.Find(id);  // ako nema id-a vraca null
        }
        public virtual void Insert(Entity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(Entity entity, int id)  //isti su objekti u argumentima
        {
            Entity old = Get(id);
            if(old != null)
            {
                _context.Entry(old).CurrentValues.SetValues(entity);
            }
        }
        public void Delete(Entity entity)
        {
            dbSet.Remove(entity);
        }
        public void Delete(int id)
        {
            Entity old = Get(id);
            Delete(old);
        }
    }
}
