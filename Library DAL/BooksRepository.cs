using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_DAL
{
    public class BooksRepository : Repository<Book>
    {
        public BooksRepository(LibContext context) : base(context) { }
        
        public override void Update(Book entity, int id)
        {
            Book old = Get(id);
            if (old != null)
            {
                _context.Entry(old).CurrentValues.SetValues(entity);
                old.Publisher = entity.Publisher;
            }
        }
    
    }
}
