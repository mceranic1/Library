using Library_DAL;
using System;
using System.Linq;
using Xunit;
using Xunit.Priority;

namespace Library.Test
{
   // public class BookTest
    //{
        //[Theory(DisplayName ="Test zbira")]
        //[InlineData(5,12)]
        //[InlineData(22,-5)]
        //[InlineData(10,7)]
        //public void Test1(int x, int y)
        //{
        //    // Arrange  - ne moramo imati arrange ako iznad zadamo konstantne vrijednosti
        //    //int x = 5;
        //    //int y = 12;

        //    //Act
        //    int z = x + y;

        //    //Assert
        //    Assert.Equal(17, z);
        //}
        //[Fact(Skip ="Test koji necemo raditi")]
        //public void Test2()
        //{

        //}
    //}
    public class BookTest
    {
        static LibContext context;
        static IRepository<Book> books;

        [Fact, Priority(1)]
        private void BeforeAllTests()
        {
            context = new TestContext();
            books = new Repository<Book>(context);

            // deletes DB
            context.Database.EnsureDeleted();  // rekreiramo bazu
            // creates DB
            context.Database.EnsureCreated();

            books.Insert(new Book { Title = "Book 1" });
            books.Insert(new Book { Title = "Book 2"});
            context.SaveChanges();
        }

        [Fact, Priority(2)]
        public void TestBooksCount()
        {
            int N = books.Get().Count();

            Assert.Equal(2, N);
        }

        [Theory(DisplayName = "Testing Get(id) method"), Priority(2)]
        [InlineData(1, "Book 1")]
        [InlineData(2, "Book 2")]
        public void TestId(int id, string bookTitle)
        {
            //Act
            Book book = books.Get(id);
            //Assert
            Assert.Equal(bookTitle, book.Title);
        }

        [Fact(DisplayName = "Test insert"), Priority(6)]
        public void TestInsert()
        {
            books.Insert(new Book { Title = "My new book" });
            context.SaveChanges();

            Assert.Equal(3, books.Get().Count());

        }

        [Fact(DisplayName = "Test delete"), Priority(7)]
        public void TestDelete()
        {
            books.Delete(3);
            context.SaveChanges();

            Assert.Equal(2, books.Get().Count());
        }
    }    
}
