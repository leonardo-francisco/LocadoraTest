using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Entities;
using VideoRental.Domain.Interface;

namespace VideoRental.Data.Repository
{
    public class FilmeRepository : DBConnection, IFilmeRepository
    {
        public FilmeRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<int> CreateAsync(Filme entity)
        {
            try
            {
                var query = "INSERT INTO Filmes VALUES(@Nome, @Ano, @GeneroId, @Classificacao, @Duracao)";

                var parameters = new DynamicParameters();
                parameters.Add("Nome", entity.Nome, DbType.String);
                parameters.Add("Ano", entity.Ano, DbType.Int32);                
                parameters.Add("GeneroId", entity.GeneroId, DbType.Int32);
                parameters.Add("Classificacao", entity.Classificacao, DbType.String);
                parameters.Add("Duracao", entity.Duracao, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Filme entity)
        {
            try
            {
                var query = "DELETE FROM Filmes WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Filme>> GetAllAsync()
        {
            try
            {
                var query = "SELECT f.Id, f.Nome, f.Ano, g.Id as GeneroId, g.Nome as Genero, f.Classificacao, f.Duracao FROM Filmes f "+
                             "JOIN Genero g ON g.Id = f.GeneroId";
                using (var connection = CreateConnection())
                {
                    var t = await connection.QueryAsync<Filme>(query);
                    return t.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Filme>> GetByGeneroAsync(string gnr)
        {
            try
            {
                var query = "SELECT f.Id, f.Nome, f.Ano, g.Id as GeneroId, g.Nome as Genero, f.Classificacao, f.Duracao FROM Filmes f " +
                            "JOIN Genero g ON g.Id = f.GeneroId WHERE g.Nome = @Genero";

                var parameters = new DynamicParameters();
                parameters.Add("Genero", gnr, DbType.String);

                using (var connection = CreateConnection())
                {
                    var t = await connection.QueryAsync<Filme>(query, parameters);
                    return t.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Filme> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Filmes WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Filme>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Filme>> GetByNameAsync(string name)
        {
            try
            {
                var query = "SELECT f.Id, f.Nome, f.Ano, g.Id as GeneroId, g.Nome as Genero, f.Classificacao, f.Duracao FROM Filmes f " +
                            "JOIN Genero g ON g.Id = f.GeneroId WHERE f.Nome LIKE '%' + @Nome + '%'";

                var parameters = new DynamicParameters();
                parameters.Add("Nome", name, DbType.String);

                using (var connection = CreateConnection())
                {
                    var t = await connection.QueryAsync<Filme>(query, parameters);
                    return t.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Filme entity)
        {
            try
            {
                var query = "UPDATE Filmes SET Nome = @Nome, Ano = @Ano, GeneroId = @GeneroId, Classificacao = @Classificacao, Duracao = @Duracao WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Nome", entity.Nome, DbType.String);
                parameters.Add("Ano", entity.Ano, DbType.Int32);
                parameters.Add("GeneroId", entity.GeneroId, DbType.Int32);
                parameters.Add("Classificacao", entity.Classificacao, DbType.String);
                parameters.Add("Duracao", entity.Duracao, DbType.String);
                parameters.Add("Id", entity.Id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
