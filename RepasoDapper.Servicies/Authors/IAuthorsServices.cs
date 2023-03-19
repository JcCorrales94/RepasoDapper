using RepasoDapper.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Servicies.Authors
{
    public interface IAuthorsServices
    {

        //? Solicitar Lista de Author GET()
        List<Author> GetAll(); 

        //? Insertar un Author POST()
        int Insert(Author authors);

        //? Eliminar un Author por ID DELETE()
        int Delete(int Id);

        //? Eliminar lista de Author CLEAN()

        void Clean();

        //? Devolver autor con libros que haya publicado
        AuthorExtended? GetPublishedBooksByAuthor(string authorName);

    }
}
