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
        IAuthorsRepository authorsRepository = new AuthorsRepository();
        public void Clean()
        {
            authorsRepository.Clean();
        }

        public int Delete(int Id)
        {
            if (Id == 0) throw new ArgumentException("El ID enviado no corresponde a un ID valido");
            return authorsRepository.Delete(Id);
        }

        public List<Author> GetAll()
        {
            return authorsRepository.GetAll();
        }

        public AuthorExtended? GetPublishedBooksByAuthor(string authorName)
        {
            if (string.IsNullOrEmpty(authorName)) throw new ArgumentException("Debes introduccir un nombre de Autor");
            return authorsRepository.GetPublishedBooksByAuthor(authorName);
        }

        public int Insert(Author authors)
        {
            if (authors == null) throw new ArgumentNullException("Me has enviado un autor a nulo");
            if (authors.Name == null) throw new ArgumentNullException("El nombre del autor no puede ser nulo");
            return authorsRepository.Insert(authors);
        }
    }
}
