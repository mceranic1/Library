using Library_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class ModelFactory  // za kreiranje modela cemo je koristiti
    {
        public PublisherModel CreatePublisher(Publisher publisher)
        {
            return new PublisherModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                City = publisher.City,
                Country = publisher.Country,
                ZipCode = publisher.ZipCode,
                Road = publisher.Road,
                Books = publisher.Books.Select(x => new MasterModel { Id = x.Id, Name = x.Title }).ToList()
            };
        }
        //public AuthorModel CreateAuthor(Author author)
        //{
        //    return new AuthorModel
        //    {
        //        Id = author.Id,
        //        Name = author.Name,
        //        Image = author.Image,
        //        Biography = author.Biography,
        //        Birthday = author.Birthday,
        //        Email = author.Email,
        //        Books = author.Books.Select(x => new MasterModel { Id = x.Id, Name = x. }).ToList()
        //    };
        //}
    }
}
