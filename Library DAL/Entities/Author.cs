using System;
using System.Collections.Generic;
using System.Text;

namespace Library_DAL
{
    public class Author : BaseClass
    {
        public Author()
        {
            Books = new List<AuthBooks>();
        }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public List<AuthBooks> Books { get; set; }
    }
}
