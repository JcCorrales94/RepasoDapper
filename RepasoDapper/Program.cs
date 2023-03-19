
using RepasoDapper.Entities.Authors;
using RepasoDapper.Entities.Books;
using RepasoDapper.Servicies.Authors;
using RepasoDapper.Servicies.Books;
using RepasoDapper.Servicies.Init;


IInitDataBaseServices initDataBaseServices = new InitDataBaseServices();
IAuthorsServices authorsServices = new AuthorsServices();
IBooksServices booksServices = new BooksServices();


//? ==================== LLAMADAS A MÉTODOS ==============================

CleanInitDBData();
InsertInitialData();


//? ========== Apartado 1 y 2 =========
// Hacer un método que inserte varios autores y libros (InsertInitialData)

GetAllAuthors();

GetAllBooks();

//? =========== Apartado 3 =============
// Hacer un método que busque por nombre de autor y devuelva el author y el total de libros escritos

GetPublishedBooksByAuthor("J. R. R. Tolkien");

//? =========== Apartado 4 y 5 =============
// Eliminar un autor y un libro por su ID

DeleteAuthorById(1);

DeleteBookById(2);

//? =========== Apartado 6 =================
// Actualizar el titulo de un libro por su ID
UpdateBookTitle(3, "El Señor de los Anillos Versión Extendida");
GetAllBooks();


//? ============================= MÉTODOS ==================================
void CleanInitDBData()
{
    Console.WriteLine("Limpiando los datos de la Base de Datos");
    initDataBaseServices.CleanDB();
}
void InsertInitialData()
{
    Console.WriteLine("Insertado Datos Iniciales");
    initDataBaseServices.InsertInitialData();
}

void GetAllAuthors()
{
    Console.WriteLine("Devolviendo lista de Autores");
    var author = authorsServices.GetAll();
    ShowAuthorsData(author);
}
void GetAllBooks()
{
    Console.WriteLine("Devolviendo lista de libros");
    var book = booksServices.GetAll();
    ShowBooksData(book);
}

void GetPublishedBooksByAuthor(string authorName)
{
    Console.WriteLine($"Mostrando autor {authorName} con libros publicados");
    
    var authorWithBooks = authorsServices.GetPublishedBooksByAuthor(authorName);

    if(authorWithBooks != null)
    {
        Console.WriteLine($"Id: {authorWithBooks.Id} Nombre: {authorWithBooks.Name}  NumeroLibros: {authorWithBooks.NumberOfBooks}");
    }
}

void DeleteAuthorById(int id)
{
    Console.WriteLine($"Eliminando Autor con ID: {id}");
    var deleteRows = authorsServices.Delete(id);

    if (deleteRows == 0)
    {
        Console.WriteLine($" No se ha podido encontrar ningun autor con el ID: {id} en la base de datos");
    }
    else
    {
        Console.WriteLine($"Se ha eliminado {deleteRows} autor / autores de la base de datos");
    }
}

void DeleteBookById(int id)
{
    Console.WriteLine($"Eliminando Libro con ID: {id}");
    var deleteRows = booksServices.Delete(id);

    if (deleteRows == 0)
    {
        Console.WriteLine($"No se ha podido encontrar ningun libro con el ID: {id} en la base de datos");
    }
    else 
    {
        Console.WriteLine($"SE ha eliminado {deleteRows} libro / libros de la base de datos");
    }
}
void UpdateBookTitle(int Id, string newTitle)
{
    Console.WriteLine($"Actualizando el titulo del libro con ID: {Id} a {newTitle}");
    var updatedRows = booksServices.Update(Id, newTitle);

    if (updatedRows == 0) 
    {
        Console.WriteLine($"No se ha encontrado ningún libro con el ID: {Id} en la base de datos");
    }
    else
    {
        Console.WriteLine($"Se ha actualizado {updatedRows} libro / libros de la base de datos");
    }
}

static void ShowAuthorsData(List<Author> authors)
{
    Console.WriteLine("Mostrando datos autores");
    authors.ForEach(auth => Console.WriteLine($"Id: {auth.Id} Nombre: {auth.Name}"));
}

static void ShowBooksData(List<Book> books)
{
    Console.WriteLine("Mostrando datos libros");
    books.ForEach(book => Console.WriteLine($"Id: {book.Id} Title: {book.Title}  AuthorId: {book.AuthorId} PublishedYear: {book.PublishedYear} Sales: {book.Sales}"));
}