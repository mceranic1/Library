using Library_DAL;
using System;
using System.Linq;

namespace Library.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LibContext context = new LibContext())
            {
                Publisher p = new Publisher();
                Console.Write("Publisher name: ");
                p.Name = Console.ReadLine();
                Console.Write("Address: ");
                p.Road = Console.ReadLine();
                Console.Write("ZIP code: ");
                p.ZipCode = Console.ReadLine();
                Console.Write("City: ");
                p.City = Console.ReadLine();
                Console.Write("Country: ");
                p.Country = Console.ReadLine();
                context.Publishers.Add(p);

                Book b = new Book();
                Console.Write("Book title: ");
                b.Title = Console.ReadLine();
                Console.Write("Book cover: ");
                b.Image = Console.ReadLine();
                Console.Write("Number of pages: ");
                b.Pages = int.Parse(Console.ReadLine());
                Console.Write("Book price: ");
                b.Price = decimal.Parse(Console.ReadLine());
                Console.Write("Publisher: ");
                string pubName = Console.ReadLine();
                Publisher pub = context.Publishers.FirstOrDefault(x => x.Name == pubName);
                b.Publisher = pub;
                context.Books.Add(b);

                int n = context.SaveChanges();
                Console.WriteLine($"{n} transactions commited.");
            }
            Console.ReadKey();
        }
    }
}
