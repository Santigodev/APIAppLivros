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

        public async Task<int> DeletarPoridDB(int id)
        {
            using (var conn = Connection)
            {
                var sql = "DELETE FROM tb_livros where Id = @id";

                return await conn.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<int> SalvarDB(Livro dados)
        {
            var sql = "INSERT INTO tb_livros (Titulo,Autor,AnoPublicacao,Genero,NumeroPaginas) VAlUES (@Titulo,@Autor,@AnoPublicacao,@Genero,@NumeroPaginas)";

            using (var conn = Connection)
            {
                return await conn.ExecuteAsync(sql, new {
                    Titulo = dados.Titulo,
                    Autor = dados.Autor,
                    AnoPublicacao = dados.AnoPublicacao,
                    Genero = dados.Genero,
                    NumeroPaginas = dados.NumPaginas
                });
            }
        }

        public async Task<int> AtualizarDB(Livro dados)
        {
            var sql = "UPDATE tb_livros SET Titulo = @Titulo, Autor = @Autor, AnoPublicacao = @AnoPublicacao,Genero = @Genero,NumeroPaginas = @NumPaginas WHERE Id = @Id";

            using (var conn = Connection)
            {
                return await conn.ExecuteAsync(sql, dados);
            }
        }
    }
 }
