using Library_DAL;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library.Seed
{
    public class Program
    {
        //static ExcelWorksheet rawAuthors;
        //static ExcelWorksheet rawBooks;
        //static ExcelWorksheet rawPublishers;
        //static ExcelWorksheet rawAuthBooks;

        //static Dictionary<int, int> dicAuthors = new Dictionary<int, int>();  // zasto smo uvodili rjecnike
        //static Dictionary<int, int> dicBooks = new Dictionary<int, int>();
        //static Dictionary<int, int> dicPublishers = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                Book b = unit.Books.Get(6);
                if(b == null)
                {
                    Console.WriteLine("Podatak ne postoji!");
                }
                else
                {
                    unit.Books.Delete(6);
                    unit.Save();
                    Console.WriteLine("Podatak obrisan!");
                }                
            }

            //FileInfo file = new FileInfo(@"C:\\Users\\mersihace\\Downloads\\Library.xlsx");
            //using(ExcelPackage package = new ExcelPackage(file))
            //{
            //    ExcelWorkbook book = package.Workbook;
            //    rawPublishers = book.Worksheets["Publishers"];
            //    rawAuthors = book.Worksheets["Authors"];
            //    rawBooks = book.Worksheets["Books"];
            //    rawAuthBooks = book.Worksheets["AuthBooks"];

            //    Console.WriteLine($"Publishers:  {rawPublishers.Dimension.Rows} rows.");
            //    Console.WriteLine($"Authors:  {rawAuthors.Dimension.Rows} rows.");
            //    Console.WriteLine($"Books:  {rawBooks.Dimension.Rows} rows.");
            //    Console.WriteLine($"AuthBooks:  {rawAuthBooks.Dimension.Rows} rows.");

                

            //    using (UnitOfWork unit = new UnitOfWork())
            //    {
            //        //IRepository<Publisher> publishers = new Repository<Publisher>(context);
            //        for (int row = 2; row <= rawPublishers.Dimension.Rows; row++)
            //        {
            //            int oldId = rawPublishers.readInteger(row, 1);
            //            Publisher p = new Publisher // u {} je objekat
            //            {
            //                Name = rawPublishers.readString(row, 2),
            //                Road = rawPublishers.readString(row, 3),
            //                ZipCode = rawPublishers.readString(row, 4),
            //                City = rawPublishers.readString(row, 5),
            //                Country = rawPublishers.readString(row, 6)
            //            };
            //            unit.Publishers.Insert(p);
            //            unit.Save(); // ovo smo morali staviti u petlju da bi imali pristup id-u; mora biti prethodno pohranjen
            //            dicPublishers.Add(oldId, p.Id);
            //        }
            //        /*for (int row = 2; row <= rawPublishers.Dimension.Rows; row++)
            //        {
            //            int oldId = rawPublishers.readInteger(row, 1);
            //            Publisher p = new Publisher // u {} je objekat
            //            {
            //                Name = rawPublishers.readString(row, 2),
            //                Road = rawPublishers.readString(row, 3),
            //                ZipCode = rawPublishers.readString(row, 4),
            //                City = rawPublishers.readString(row, 5),
            //                Country = rawPublishers.readString(row, 6)
            //            };
            //            publishers.Insert(p);
            //            context.SaveChanges(); // ovo smo morali staviti u petlju da bi imali pristup id-u; mora biti prethodno pohranjen
            //            dicPublishers.Add(oldId, p.Id);
            //        }*/

            //        for (int row = 2; row <= rawAuthors.Dimension.Rows; row++)
            //        {
            //            int oldId = rawAuthors.readInteger(row, 1);
            //            Author a = new Author // u {} je objekat
            //            {
            //                Name = rawAuthors.readString(row, 2),
            //                Image = rawAuthors.readString(row, 3),
            //                Biography = rawAuthors.readString(row, 4),
            //                Birthday = rawAuthors.readDate(row, 5),
            //                Email = rawAuthors.readString(row, 6)
            //            };
            //            unit.Authors.Insert(a);
            //            unit.Save();
            //            dicAuthors.Add(oldId, a.Id); // treba nam za tabelu AuthBooks
            //        }
            //        for (int row = 2; row <= rawBooks.Dimension.Rows; row++)
            //        {
            //            int oldId = rawBooks.readInteger(row, 1);
            //            Book b = new Book
            //            {
            //                Title = rawBooks.readString(row, 2),
            //                Description = rawBooks.readString(row, 3),
            //                Image = rawBooks.readString(row, 4),
            //                Pages = rawBooks.readInteger(row, 5),
            //                Price = rawBooks.readDecimal(row, 6),
                            
            //            };
            //            int oldPub = rawBooks.readInteger(row, 7);
            //            int newPub = dicPublishers[oldPub];
            //            b.Publisher = unit.Publishers.Get(newPub);
            //            unit.Books.Insert(b);
            //            unit.Save();
            //            dicBooks.Add(oldId, b.Id);
            //        }

            //        for (int row = 2; row <= rawAuthBooks.Dimension.Rows; row++)
            //        {
            //            int oldAuth = rawAuthBooks.readInteger(row, 2);
            //            int oldBook = rawAuthBooks.readInteger(row, 1);
            //            AuthBooks ab = new AuthBooks
            //            {
            //                Book = unit.Books.Get(dicBooks[oldBook]),
            //                Author = unit.Authors.Get(dicAuthors[oldAuth])
            //            };
            //            unit.AuthBooks.Insert(ab);
            //        }
            //        unit.Save();
                
            //    }
            //}
            Console.ReadKey();
        }
    }
}
