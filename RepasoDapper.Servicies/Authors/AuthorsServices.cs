using RepasoDapper.Entities.Authors;
using RepasoDapper.Repositorie.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Servicies.Authors
{
    public class AuthorsServices : IAuthorsServices
    {
        readonly IAuthorsRepository _authorsRepository;

        public AuthorsServices(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public void Clean()
        {
            _authorsRepository.Clean();
        }

        public int Delete(int Id)
        {
            if (Id == 0) throw new ArgumentException("El ID enviado no corresponde a un ID valido");
            return _authorsRepository.Delete(Id);
        }

        public List<Author> GetAll()
        {
            return _authorsRepository.GetAll();
        }

        public AuthorExtended? GetPublishedBooksByAuthor(string authorName)
        {
            if (string.IsNullOrEmpty(authorName)) throw new ArgumentException("Debes introduccir un nombre de Autor");
            return _authorsRepository.GetPublishedBooksByAuthor(authorName);
        }

        public int Insert(Author authors)
        {
            if (authors == null) throw new ArgumentNullException("Me has enviado un autor a nulo");
            if (authors.Name == null) throw new ArgumentNullException("El nombre del autor no puede ser nulo");
            return _authorsRepository.Insert(authors);
        }
    }
}
