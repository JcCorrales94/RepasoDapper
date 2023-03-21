using Microsoft.EntityFrameworkCore;
using RepasoDapper.Entities.Books;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Repositorie.Books
{
    public class BooksRepository : IBooksRepository
    {
        readonly DatabaseContext _databaseContext;

        public BooksRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Clean()
        {
            _databaseContext.Database.ExecuteSqlRaw("TRUNCATE TABLE Books");
        }

        public int Delete(int Id)
        {
            //? MÉTODO NUEVO DE REALIZAR UN DELETE CON LA NUEVA VERSIÓN DE ENTITY FRAMEWORK
            //todo ExecuteDelete NO necesita de un SaveChanges ya que el propio ExecuteDelete te devuelve el
            //todo número de columnas que se ven afectadas.

            return _databaseContext.Books.Where(x => x.Id == Id).ExecuteDelete();
        }

        public List<Book> GetAll()
        {
            return _databaseContext.Books.ToList();
        }

        public int Insert(List<Book> books)
        {
            _databaseContext.Books.AddRange(books);
            return _databaseContext.SaveChanges();
            
        }

        public int Update(int Id, string Title)
        {
            //? Método de realizar un UPDATE hasta la última version de ENTITY FRAMEWORK

            //var book = _databaseContext.Books.FirstOrDefault(x => x.Id == Id);
            //if (book != null) 
            //{
            //    book.Title = Title;
            //    _databaseContext.Books.Update(book);
            //    return _databaseContext.SaveChanges();
            //}
            //return 0;

            //? MÉTODO NUEVO DE REALIZAR UN UPDATE CON LA NUEVA VERSIÓN DE ENTITY FRAMEWORK
            //! ExecuteUpdate despues de hacer una actualización ENTITY FRAMEWORK no se entera del cambio y hay que forzar que refresque la información con 
            //! el método ChangeTracker.Clear();

            var change = _databaseContext.Books.Where(x => x.Id == Id)
                                         .ExecuteUpdate(book => book.SetProperty(
                                             property => property.Title,
                                             property => Title));
            _databaseContext.ChangeTracker.Clear();
            return change;
        }
    }
}
