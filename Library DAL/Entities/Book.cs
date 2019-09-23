using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DAL
{
    public class Book : BaseClass
    {
        public Book()
        {
            Authors = new List<AuthBooks>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public Publisher Publisher { get; set; }
        public IList<AuthBooks> Authors { get; set; }
    }
}
