using Dapper;
using IA.Autlantico.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IA.Autlantico.Repository
{
    public class TutorRepository
    {
        string connectionstring = "Data Source = (LocalDb)\\MSSQLLocalDB;";

        public Tutor Select(int id)
        {
            try
            {
                Tutor tutor = null;

                string query = @"SELECT [Id]
                                       ,[Name]
                                       ,[Adress]
                                       ,[PhoneNumber]
                                       ,[DeletedAt]
                                  FROM [dbo].[tbTutor]
                                  WHERE [Id] = @Id AND [DeletedAt] IS NULL";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    tutor = connection.QuerySingleOrDefault<Tutor>(query);
                }

                return tutor;
            }
            catch
            {
                throw new Exception("Erro ao buscar informações de tutor.");
            }
        }

        public void Save (Tutor tutor)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[tbTutor]
                                            ,[Name]
                                            ,[Adress]
                                            ,[PhoneNumber])
                                     VALUES
                                           (@Name
                                           ,@Adress
                                           ,@PhoneNumber)";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Name", tutor.Name);
                    parameters.Add("@Adress", tutor.Adress);
                    parameters.Add("@PhoneNumber", tutor.PhoneNumber);

                    connection.Execute(query, parameters);
                }
            }
            catch
            {
                throw new Exception("Erro ao salvar tutor.");
            }
        }

        public void Update(Tutor tutor)
        {
            try
            {
                string query = @"UPDATE [dbo].[tbTutor]
                                    SET [Name]
                                       ,[Adress]
                                       ,[PhoneNumber])
                                WHERE Id = @Id";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Name", tutor.Name);
                    parameters.Add("@Adress", tutor.Adress);
                    parameters.Add("@PhoneNumber", tutor.PhoneNumber);
                    parameters.Add("@Id", tutor.Id);

                    connection.Execute(query, parameters);
                }
            }
            catch
            {
                throw new Exception("Erro ao editar tutor.");
            }
        }
    }
}
