using Dapper;
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
        private IDbConnection? connection;
        const string connectionString = "Data Source=PC-TORREPRINCIP\\SQLEXPRESS01;Integrated Security=True; Initial Catalog=DapperDB;";

        public void Clean()
        {
            var query = "TRUNCATE TABLE Books";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
              connection.Execute(query);
            }
        }

        public int Delete(int Id)
        {
            var query = "DELETE FROM Books WHERE Id = @Id";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute(query, new { Id = Id });
            }
        }

        public List<Book> GetAll()
        {
            var query = "SELECT * FROM Books";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Book>(query).ToList();
            }
        }

        public int Insert(List<Book> books)
        {
            var query = @"INSERT INTO Books (Title, AuthorId, publishedYear, Sales)
                         VALUES(@Title, @AuthorId, @publishedYear, @Sales)"; 

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute(query, books);
            }
        }

        public int Update(int Id, string Title)
        {
            var query = "UPDATE Books SET Title = @Title WHERE Id = @Id";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute(query, new { Title = Title, Id = Id });
            }
        }
    }
}
