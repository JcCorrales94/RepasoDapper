using RepasoDapper.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Repositorie.Authors
{
    public interface IAuthorsRepository
    {
        //? Solicitar Lista Author GET().
        List<Author> GetAll();

        //? Añadir un Author POST()
        int Insert(Author authors);

        //? Eliminar un Author DELETE()
        int Delete(int Id);

        //? Eliminar lista de Author CLEAN()
        void Clean();
        AuthorExtended? GetPublishedBooksByAuthor(string authorName);
    }
}
