using Dapper;
using RepasoDapper.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Repositorie.Authors
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private IDbConnection? connection;
        const string connectionString = "Data Source=PC-TORREPRINCIP\\SQLEXPRESS01;Integrated Security=True; Initial Catalog=DapperDB;";

        public void Clean()
        {
            var query = "TRUNCATE TABLE Authors";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query);
            }
        }

        public int Delete(int Id)
        {
            var query = "DELETE FROM Authors WHERE Id = @Id";
            
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
              return  connection.Execute(query, new { Id });
            }
        
        }

        public List<Author> GetAll()
        {
            var query = "SELECT * FROM Authors";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Author>(query).ToList();
            }
        }

        public int Insert(Author authors)
        {
            var query = "INSERT INTO Authors (Name) OUTPUT INSERTED.* VALUES(@Name)";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var insertedAuthor = connection.QuerySingle<Author>(query, new { Name = authors.Name});
                return insertedAuthor.Id;
            }
        }

        public AuthorExtended? GetPublishedBooksByAuthor(string authorName)
        {
            var query = @"SELECT Count(book.AuthorId) as NumberOfBooks, book.AuthorId as Id, author.Name
                         FROM Authors author
                         INNER JOIN Books book on book.AuthorId = author.id
                         WHERE author.Name = @AuthorName
                         GROUP BY book.AuthorId, author.Name";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<AuthorExtended>(query, new { AuthorName = authorName }).FirstOrDefault();
            }
        }
    }
}
