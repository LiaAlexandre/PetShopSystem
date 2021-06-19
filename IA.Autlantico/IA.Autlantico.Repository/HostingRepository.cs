using Dapper;
using IA.Autlantico.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IA.Autlantico.Repository
{
    public class HostingRepository
    {
        string connectionstring = "Data Source = (LocalDb)\\MSSQLLocalDB;";

        public List<Hosting> GetAll()
        {
            try
            {
                List<Hosting> hostings = null;

                string query = @"SELECT [Id]
                                       ,[Status]
                                       ,[DeletedAt]
                                  FROM [dbo].[tbHosting]
                                  WHERE [DeletedAt] IS NULL";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    hostings = connection.Query<Hosting>(query).ToList();
                }

                return hostings;
            }
            catch
            {
                throw new Exception("Erro ao buscar lista de alojamentos.");
            }
        }

        public Hosting GetById(int id)
        {
            try
            {
                Hosting hosting = null;

                string query = @"SELECT [Id]
                                       ,[Status]
                                       ,[DeletedAt]
                                  FROM [dbo].[tbHosting]
                                  WHERE [Id] = @Id AND [DeletedAt] IS NULL";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    hosting = connection.QuerySingleOrDefault<Hosting>(query);
                }

                return hosting;
            }
            catch
            {
                throw new Exception("Erro ao buscar alojamento.");
            }
        }

        public void Update(Hosting hosting)
        {
            try
            {
                string query = null;

                //atualiza para ocupado
                if(hosting.Status == false)
                {
                    query = @"UPDATE [dbo].[tbHosting]
                                 SET [Status] = 1
                                 WHERE Id = @Id";
                }
                //atualiza para desocupado
                else
                {
                    query = @"UPDATE [dbo].[tbHosting]
                                 SET [Status] = 0
                                 WHERE Id = @Id";
                }


                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", hosting.Id);

                    connection.QuerySingleOrDefault<Hosting>(query);
                }
            }
            catch
            {
                throw new Exception("Erro ao atualizar alojamento.");
            }
        }
    }
}
