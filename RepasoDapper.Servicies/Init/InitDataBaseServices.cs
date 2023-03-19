using RepasoDapper.Entities.Authors;
using RepasoDapper.Entities.Books;
using RepasoDapper.Servicies.Authors;
using RepasoDapper.Servicies.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Servicies.Init
{
    public class InitDataBaseServices : IInitDataBaseServices
    {
        IAuthorsServices authorsServices = new AuthorsServices();
        IBooksServices BooksServices = new BooksServices();
        public void CleanDB()
        {
            authorsServices.Clean();
            BooksServices.Clean();
        }

        public void InsertInitialData()
        {
            var author = new Author { Name = "Miguel de Cervantes" };
            var authorInsertedId = authorsServices.Insert(author);
            var authorsBooks = new List<Book>
            {
                new Book{ Title = "Don Quijote de la Mancha", PublishedYear = 1605, Sales = 500, AuthorId = authorInsertedId }
            };

            author = new Author { Name = "Charles Dickens" };
            authorInsertedId = authorsServices.Insert(author);
            authorsBooks.Add(new Book { Title = "Historia de dos ciudades", PublishedYear = 1859, Sales = 200, AuthorId = authorInsertedId });

            author = new Author { Name = "J. R. R. Tolkien" };
            authorInsertedId = authorsServices.Insert(author);
            authorsBooks.AddRange(new List<Book>
            {
                new Book{ Title = "El Señor de los Anillos", PublishedYear = 1978, Sales = 150, AuthorId = authorInsertedId },
                new Book{ Title = "El hobbit", PublishedYear = 1982, Sales = 100, AuthorId = authorInsertedId },
            });

            author = new Author { Name = "Antoine de Saint-Exupéry" };
            authorInsertedId = authorsServices.Insert(author);
            authorsBooks.Add(new Book { Title = "El principito", PublishedYear = 1951, Sales = 140, AuthorId = authorInsertedId });

            author = new Author { Name = "Cao Xueqin" };
            authorInsertedId = authorsServices.Insert(author);
            authorsBooks.Add(new Book { Title = "Sueño en el pabellón rojo", PublishedYear = 1792, Sales = 100, AuthorId = authorInsertedId });

            author = new Author { Name = "Lewis Car" };
            authorInsertedId = authorsServices.Insert(author);
            authorsBooks.Add(new Book { Title = "Las aventuras de Alicia en el país de las maravillas", PublishedYear = 1865, Sales = 100, AuthorId = authorInsertedId });

            author = new Author { Name = "Agatha Christie" };
            authorInsertedId = authorsServices.Insert(author);
            authorsBooks.Add(new Book { Title = "Diez negritos", PublishedYear = 1939, Sales = 100, AuthorId = authorInsertedId });

            author = new Author { Name = "C. S. Lewis" };
            authorInsertedId = authorsServices.Insert(author);
            authorsBooks.Add(new Book { Title = "El león, la bruja y el armario", PublishedYear = 1950, Sales = 85, AuthorId = authorInsertedId });

            author = new Author { Name = "Dan Brown" };
            authorInsertedId = authorsServices.Insert(author);
            authorsBooks.Add(new Book { Title = "El código Da Vinci", PublishedYear = 2003, Sales = 80, AuthorId = authorInsertedId });

            author = new Author { Name = "J. D. Salinger" };
            authorInsertedId = authorsServices.Insert(author);
            authorsBooks.Add(new Book { Title = "El guardián entre el centeno", PublishedYear = 1951, Sales = 65, AuthorId = authorInsertedId });

            BooksServices.Insert(authorsBooks);
        }
    }
}
