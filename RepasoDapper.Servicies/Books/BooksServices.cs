using RepasoDapper.Entities.Books;
using RepasoDapper.Repositorie.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Servicies.Books
{
    public class BooksServices : IBooksServices
    {
        readonly IBooksRepository _booksRepository;

        public BooksServices(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public void Clean()
        {
            _booksRepository.Clean();
        }

        public int Delete(int Id)
        {
            if (Id <= 0) throw new ArgumentException("Debes enviar un ID correcto");
            return _booksRepository.Delete(Id);
        }

        public List<Book> GetAll()
        {
            return _booksRepository.GetAll();
        }

        public int Insert(List<Book> books)
        {
            if (books == null) throw new ArgumentNullException("La lista de libros debe de contener al menos un libro");
            foreach (Book book in books)
            {
                if (book.Title == null) throw new ArgumentNullException("El titulo del libro no puede ser nulo");
                if (book.PublishedYear == 0) throw new ArgumentException("El formato fecha es erroneo");
                if (book.Sales < 0) throw new ArgumentException("Las ventas no pueden ser negativas");
            }
                
            return _booksRepository.Insert(books);
        }


        public int Update(int Id, string Title)
        {
            if (Id <= 0) throw new ArgumentException("El ID no corresponde a ninguno de nuestra base de datos");
            if (Title == null) throw new ArgumentNullException("Debes introduccir un titulo");
            return _booksRepository.Update(Id, Title);
        }
    }
}
