

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepasoDapper.Configuration;
using RepasoDapper.Entities.Authors;
using RepasoDapper.Entities.Books;
using RepasoDapper.Repositorie;
using RepasoDapper.Repositorie.Authors;
using RepasoDapper.Repositorie.Books;
using RepasoDapper.Servicies.Authors;
using RepasoDapper.Servicies.Books;
using RepasoDapper.Servicies.Init;

var serviceProvider = new ServiceCollection()
    .configureServices()
    .ConfigureRepositories()
    .AddConfigurationConfigFile()
    .ConfigureDataBase()
    .BuildServiceProvider();

IInitDataBaseServices initDataBaseServices = serviceProvider.GetService<IInitDataBaseServices>();
IAuthorsServices authorsServices = serviceProvider.GetService<IAuthorsServices>();
IBooksServices booksServices = serviceProvider.GetService<IBooksServices>();





//? HACEMOS RESET DE LA BASE DE DATOS DE DATOS ANTERIORES
CleanInitDBData();

//? HACEMOS LA INSERCCIÓN DE DATOS A LA BASE DE DATOS
InsertInitialData();

//? SOLICITAMOS A LA BASE DE DATOS TODOS LOS AUTORES
GetAllAuthors();

//? SOLICITAMOS A LA BASE DE DATOS TODOS LOS LIBROS
GetAllBooks();

//? SOLICITAMOS AUTOR CON LOS LIBROS PUBLICADOS
GetPublishedBooksByAuthor("J. R. R. Tolkien");

//? ELIMINAMOS UN AUTOR POR SU ID
DeleteAuthorById(1);
//? ELIMINAMOS UN LIBRO POR SU ID
DeleteBookById(2);

//? ACTUALIZAMOS EL TITULO DE UN LIBRO POR EL ID DEL LIBRO
UpdateBookTitle(3, "El Señor de los Anillos Versión Extendida");



void CleanInitDBData()
{
    Console.WriteLine("Limpiando los datos de la BD");
    initDataBaseServices.CleanDB();
    Console.WriteLine();
}

void InsertInitialData()
{
    Console.WriteLine("Insertando datos iniciales");
    initDataBaseServices.InsertInitialData();
    Console.WriteLine();
}

void GetAllAuthors()
{
    var authors = authorsServices.GetAll();
    ShowAuthorsData(authors);
}

void GetAllBooks()
{
    var books = booksServices.GetAll();
    ShowBooksData(books);
}

void ShowAuthorsData(List<Author> authors)
{
    Console.WriteLine("Mostrando los datos de autores");

    authors.ForEach(auth => Console.WriteLine($"Id: {auth.Id} Nombre: {auth.Name}"));
    Console.WriteLine();
}

void ShowBooksData(List<Book> books)
{
    Console.WriteLine("Mostrando los datos de libros");

    books.ForEach(book => Console.WriteLine($"Id: {book.Id} Title: {book.Title} AuthorId: {book.AuthorId} PublishedYear: {book.PublishedYear} Sales: {book.Sales}"));
    Console.WriteLine();
}

void GetPublishedBooksByAuthor(string authorName)
{
    Console.WriteLine($"Mostrando autor {authorName} con libros publicados");

    var authorWithBooks = authorsServices.GetPublishedBooksByAuthor(authorName);

    if (authorWithBooks != null)
    {
        Console.WriteLine($"Id: {authorWithBooks.Id} Nombre: {authorWithBooks.Name} NumeroLibros: {authorWithBooks.NumberOfBooks}");
    }
    else
    {
        Console.WriteLine($"No se han encontrado datos para el autor {authorName}");
    }
    Console.WriteLine();
}

void DeleteAuthorById(int id)
{
    Console.WriteLine($"Eliminando autor con id {id}");
    var deletedRows = authorsServices.Delete(id);

    if (deletedRows == 0)
    {
        Console.WriteLine($"No se ha encontrado ningún autor con el id {id} en la DB");
    }
    else
    {
        Console.WriteLine($"Se han eliminado {deletedRows} autores de la DB");
    }
    Console.WriteLine();
}

void DeleteBookById(int id)
{
    Console.WriteLine($"Eliminando libro con id {id}");
    var deletedRows = booksServices.Delete(id);

    if (deletedRows == 0)
    {
        Console.WriteLine($"No se ha encontrado ningún libro con el id {id} en la DB");
    }
    else
    {
        Console.WriteLine($"Se han eliminado {deletedRows} libros de la DB");
    }
    Console.WriteLine();
}

void UpdateBookTitle(int id, string newTitle)
{
    Console.WriteLine($"Actualizando el titulo del libro con id {id} a {newTitle}");

    var updatedRows = booksServices.Update(id, newTitle);

    if (updatedRows == 0)
    {
        Console.WriteLine($"No se ha encontrado ningún libro con el id {id} en la DB");
    }
    else
    {
        Console.WriteLine($"Se han actualizado {updatedRows} libros de la DB");
    }
    Console.WriteLine();

    GetAllBooks();
}