using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_DAL
{
    public interface IRepository<Entity>  // genericki repozitorij
    {
        IQueryable<Entity> Get();
        IList<Entity> Get(Func<Entity, bool> where);
        Entity Get(int id);

        void Insert(Entity entity);
        void Update(Entity entity, int id);  // entitiy.id mora biti isti kao id (to je kontrola kod update-a));
        void Delete(Entity entity);
        void Delete(int id);
    }
}
