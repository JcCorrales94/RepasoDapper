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
        readonly IAuthorsServices _authorsServices;
        readonly IBooksServices _booksServices;

        public InitDataBaseServices(IAuthorsServices authorsServices, IBooksServices booksServices)
        {
            _authorsServices = authorsServices;
            _booksServices = booksServices;
        }

        public void CleanDB()
        {
            _authorsServices.Clean();
            _booksServices.Clean();
        }

        public void InsertInitialData()
        {
            insertAuthor();
            insertBooks();
        }

        public void insertAuthor()
        {
            var authorsCSV = File.ReadAllLines("CSVs\\Import\\Authors.csv");
            List<Author> authorList = new List<Author>();
            for(int i = 1; i < authorsCSV.Length; i++)
            {
                string authorCSV = authorsCSV[i];
                var authorCSVSplitted = authorCSV.Split(';');
                authorList.Add(new Author { Name = authorCSVSplitted[1]});
            }
            foreach(Author author in authorList)
            {
                _authorsServices.Insert(author);
            }
        }

        public void insertBooks()
        {
            var booksCSV = File.ReadAllLines("CSVs\\Import\\Books.csv");
            List<Book> bookList = new List<Book>();
            for (int i = 1; i < booksCSV.Length; i++)
            {
                string bookCSV = booksCSV[i];
                var bookCSVSplitted = bookCSV.Split(";");

                bookList.Add(new Book
                {
                    AuthorId = int.Parse(bookCSVSplitted[2]),
                    Title = bookCSVSplitted[1],
                    PublishedYear = int.Parse((bookCSVSplitted[3])),
                    Sales = int.Parse((bookCSVSplitted[4]))
                });
            }
            _booksServices.Insert(bookList);
        }

    }
}
