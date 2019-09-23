using Library_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class AuthorModel
    {
        public AuthorModel()
        {
            Books = new List<MasterModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public List<MasterModel> Books { get; set; }
    }
}
