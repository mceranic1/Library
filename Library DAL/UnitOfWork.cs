using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DAL
{
    public class UnitOfWork : IDisposable
    {
        private LibContext _context = new LibContext();

        private IRepository<Author> _authors;
        private IRepository<Book> _books;
        private IRepository<Publisher> _publishers;
        private IRepository<AuthBooks> _authbooks;

        public LibContext Context { get { return _context; } }
        public IRepository<Author> Authors
        {
            get
            {
                if (_authors == null)
                {
                    _authors = new Repository<Author>(_context);
                }
                return _authors;
            }
        }
        public IRepository<Book> Books
        {
            get
            {
                return _books ?? (_books = new BooksRepository(_context));  // ?? provjerava da li je null
            }
            
        }
        public IRepository<Publisher> Publishers
        {
            get
            {
                return _publishers ?? (_publishers = new PublishersRepository(_context));  // ?? provjerava da li je null
            }

        }
        public IRepository<AuthBooks> AuthBooks
        {
            get
            {
                return _authbooks ?? (_authbooks = new Repository<AuthBooks>(_context));  // ?? provjerava da li je null
            }  // singleton pattern

        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        
        public void Dispose()
        {
            _context.Dispose();  // metoda za oslobadjanje resursa
        }
    }
}
