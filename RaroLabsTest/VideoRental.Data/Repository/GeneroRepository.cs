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
    public class GeneroRepository :DBConnection, IGeneroRepository
    {
        public GeneroRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<int> CreateAsync(Genero entity)
        {
            try
            {
                var query = "INSERT INTO Genero VALUES(@Nome)";

                var parameters = new DynamicParameters();
                parameters.Add("Nome", entity.Nome, DbType.String);              

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

        public async Task<int> DeleteAsync(Genero entity)
        {
            try
            {
                var query = "DELETE FROM Genero WHERE Id = @Id";

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

        public async Task<List<Genero>> GetAllAsync()
        {
            try
            {
                var query = "SELECT Id, Nome FROM Genero ";
                            
                using (var connection = CreateConnection())
                {
                    var t = await connection.QueryAsync<Genero>(query);
                    return t.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<List<Genero>> GetByGeneroAsync(string gnr)
        {
            throw new NotImplementedException();
        }

        public async Task<Genero> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Genero WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Genero>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<List<Genero>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Genero entity)
        {
            try
            {
                var query = "UPDATE Genero SET Nome = @Nome WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Nome", entity.Nome, DbType.String);                
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
