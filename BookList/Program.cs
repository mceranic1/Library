using Library_DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookList
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                var ListOfBooks = unit.Books.Get().Include(x => x.Publisher).Include(x => x.Authors);  // Include koristimo kad iz kolekcije zelimo dobaviti dodatne podatke
                foreach (Book b in ListOfBooks) // lista knjiga
                {
                    Console.WriteLine($"{b.Title} ({b.Authors.Count} authors) published by {b.Publisher.Name}");
                }
            }
            
        }
    }
}
