using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class PublisherModel
    {
        public PublisherModel()
        {
            Books = new List<MasterModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Road { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<MasterModel> Books { get; set; }  // sadrzi samo id i naziv knjige
    }
}
