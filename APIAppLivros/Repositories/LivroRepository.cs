using APIAppLivros.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace APIAppLivros.Repositories
{
    public class LivroRepository
    {
        private readonly string _connectionString;

        public LivroRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection =>
            new MySqlConnection(_connectionString);

        public async Task<IEnumerable<Livro>> ListarTodosDB()
        {
            using (var conn = Connection)
            {
                var sql = "SELECT * FROM tb_livros";

                return await conn.QueryAsync<Livro>(sql);
            }
        }

        public async Task<Livro> BuscarPorIdDB(int id)
        {
            using (var conn = Connection)
            {
                var sql = "SELECT * FROM tb_livros where Id = @id";

                return await conn.QueryFirstOrDefaultAsync<Livro>(sql, new { Id = id});
            }
        }

        public async Task<int> DeletarPorid(int id)
        {
            using (var conn = Connection)
            {
                var sql = "DELETE FROM tb_livros where Id = @id";

                return await conn.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
 }
