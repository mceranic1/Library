using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_DAL
{
    public class PublishersRepository : Repository<Publisher>
    {
        public PublishersRepository(LibContext context) : base(context) { }
        public override IQueryable<Publisher> Get()
        {
            return dbSet.Include(p => p.Books)
                        .ThenInclude(p => p.Authors)  // theninclude se referise na argument prethodnog include-a
                        .ThenInclude(p => p.Author);
        }
        public override Publisher Get(int id)
        {
            Publisher publisher = Get().FirstOrDefault(x => x.Id == id);
            return publisher;  // ako nema id-a vraca null
        }
    }
}
