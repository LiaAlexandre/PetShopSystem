using Dapper;
using IA.Autlantico.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IA.Autlantico.Repository
{
    public class AnimalRepository
    {
        string connectionstring = "Data Source = (LocalDb)\\MSSQLLocalDB;";

        public List<Animal> GetAll()
        {
            try
            {
                List<Animal> animals = null;

                string query = @"SELECT [Id]
                                       ,[Name]
                                       ,[InternationMotive]
                                       ,[Status]
                                       ,[IdTutor]
                                       ,[DeletedAt]
                                  FROM [dbo].[tbAnimal]
                                  WHERE [DeletedAt] IS NULL";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    animals = connection.Query<Animal>(query).ToList();
                }

                return animals;
            }
            catch
            {
                throw new Exception("Erro ao buscar lista de animais.");
            }
        }

        public Animal GetByName(string search)
        {
            try
            {
                Animal animal = null;

                string query = @"SELECT [Id]
                                       ,[Name]
                                       ,[InternationMotive]
                                       ,[Status]
                                       ,[IdTutor]
                                       ,[DeletedAt]
                                  FROM [dbo].[tbAnimal]
                                  WHERE UPPER(Name) LIKE ‘@Search%’ AND [DeletedAt] IS NULL";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Search", search);

                    animal = connection.QuerySingleOrDefault<Animal>(query);
                }

                return animal;
            }
            catch
            {
                throw new Exception("Erro ao buscar animal.");
            }
        }

        public Animal GetById(int id)
        {
            try
            {
                Animal animal = null;

                string query = @"SELECT [Id]
                                       ,[Name]
                                       ,[InternationMotive]
                                       ,[Status]
                                       ,[IdTutor]
                                       ,[DeletedAt]
                                  FROM [dbo].[tbAnimal]
                                  WHERE [Id] = @Id AND [DeletedAt] IS NULL";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    animal = connection.QuerySingleOrDefault<Animal>(query);
                }

                return animal;
            }
            catch
            {
                throw new Exception("Erro ao buscar animal.");
            }
        }

        public int Save(Animal animal)
        {
            int idAnimal = 0;
            try
            {
                string query = @"INSERT INTO [dbo].[tbAnimal]
                                           ([Name]
                                           ,[InternationMotive]
                                           ,[Status]
                                           ,[IdTutor])
                                     VALUES
                                           (@Name
                                           ,@InternationMotive
                                           ,@Status
                                           ,@IdTutor)
                                    SELECT SCOPE_IDENTITY()";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Name", animal.Name);
                    parameters.Add("@InternationMotive", animal.InternationMotive);
                    parameters.Add("@Status", animal.Status);
                    parameters.Add("@IdTutor", animal.IdTutor);

                    idAnimal = connection.Execute(query, parameters);
                }
                return idAnimal;
            }
            catch
            {
                throw new Exception("Erro ao salvar animal.");
            }            
        }

        public void Update(Animal animal)
        {
            try
            {
                string query = @"UPDATE [dbo].[tbAnimal]
                                    SET [Name] = @Name
                                        ,[InternationMotive] = @InternationMotive
                                        ,[Status] = @Status
                                WHERE Id = @Id";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Name", animal.Name);
                    parameters.Add("@InternationMotive", animal.InternationMotive);
                    parameters.Add("@Status", animal.Status);
                    parameters.Add("@Id", animal.Id);

                    connection.Execute(query, parameters);
                }
            }
            catch
            {
                throw new Exception("Erro ao editar animal.");
            }
        }

        public void Delete(int id)
        {
            try
            {
                string query = @"UPDATE [dbo].[tbAnimal]
                                 SET [DeletedAt] = @DeletedAt
                                 WHERE Id = @Id";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@DeletedAt", DateTime.Now);
                    parameters.Add("@Id", id);

                    connection.Execute(query, parameters);
                }
            }
            catch
            {
                throw new Exception("Erro ao excluir animal.");
            }
        }
    }
}
