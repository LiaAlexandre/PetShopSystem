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
        string connectionstring = "Data Source=LAPTOP-FGQM066T;Initial Catalog=Autlantico;Integrated Security=true;";

        public Tutor GetById(int id)
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

        public int Save (Tutor tutor)
        {
            int idTutor = 0;
            try
            {
                string query = @"INSERT INTO [dbo].[tbTutor]
                                            ([Name]
                                            ,[Address]
                                            ,[PhoneNumber])
                                     VALUES
                                           (@Name
                                           ,@Address
                                           ,@PhoneNumber)
                                     SELECT SCOPE_IDENTITY()";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Name", tutor.Name);
                    parameters.Add("@Address", tutor.Address);
                    parameters.Add("@PhoneNumber", tutor.PhoneNumber);

                    idTutor = connection.Execute(query, parameters);
                }

                return idTutor;
            }
            catch(Exception ex)
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
                    parameters.Add("@Adress", tutor.Address);
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

        public void Delete(int id)
        {
            try
            {
                string query = @"UPDATE [dbo].[tbTutor]
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
                throw new Exception("Erro ao excluir tutor.");
            }
        }
    }
}
