using RepasoDapper.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Repositorie.Books
{
    public interface IBooksRepository
    {
        //? Solicitar lista de Libro GET()
        List<Book> GetAll();

        //? Añadir lista libro POST()
        int Insert(List<Book> books);

        //? Actualizar titulo de libro UPDATE()
        int Update(int Id, string Title);

        //? Eliminar un Book DELETE()
        int Delete(int Id);

        //? Eliminar lista de Books CLEAN()
        void Clean();
    }
}
