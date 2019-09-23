using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DAL
{
    public class Publisher : BaseClass
    {
        public Publisher()
        {
            Books = new List<Book>();
        }
        public string Name { get; set; }
        public string Road { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public IList<Book> Books { get; set; }
    }
}
