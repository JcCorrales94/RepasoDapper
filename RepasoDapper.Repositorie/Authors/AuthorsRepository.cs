using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepasoDapper.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Repositorie.Authors
{
    public class AuthorsRepository : IAuthorsRepository
    {
        readonly DatabaseContext _databaseContext;

        public AuthorsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Clean()
        {
            _databaseContext.Database.ExecuteSqlRaw("DELETE FROM Authors; DBCC CHECKIDENT('EjercicioEFCore.dbo.Authors', RESEED, 0)");
        }

        public int Delete(int Id)
        {
            //? MÉTODO DE HACER UN DELETE HASTA LA ÚLTIMA VERSION DE ENTITY FRAMEWORK
          
            var author = _databaseContext.Authors.Where(x => x.Id == Id).FirstOrDefault();
            if (author != null)
            {
                _databaseContext.Remove(author);
                return _databaseContext.SaveChanges();
            }
            return 0;
        }

        public List<Author> GetAll()
        {
            return _databaseContext.Authors.ToList();
        }

        public AuthorExtended? GetPublishedBooksByAuthor(string authorName)
        {
            return (from author in _databaseContext.Authors
                    join book in _databaseContext.Books on author.Id equals book.AuthorId
                    where author.Name == authorName
                    group book by new { book.AuthorId, author.Name } into groupedBooks
                    select new AuthorExtended { Id = groupedBooks.Key.AuthorId, Name = groupedBooks.Key.Name, NumberOfBooks = groupedBooks.Count() }
                     ).FirstOrDefault();
        }

        public int Insert(Author authors)
        {
            _databaseContext.Authors.Add(authors);
           return _databaseContext.SaveChanges();
            
        }
    }
}
