using RepasoDapper.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Servicies.Books
{
    public interface IBooksServices
    {
        //? Solicitar Lista de Book GET()
        List<Book> GetAll();

        //? Insertar un Book POST()
        int Insert(List<Book> books);

        //? Actualizar titulo de libro UPDATE()
        int Update(int Id, string Title);

        //? Eliminar un Book por ID DELETE()
        int Delete(int Id);

        //? Eliminar lista de Book CLEAN()

        void Clean();
        
    }
}
