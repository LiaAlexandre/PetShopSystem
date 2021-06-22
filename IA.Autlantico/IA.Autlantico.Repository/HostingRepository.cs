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
        string connectionstring = "Data Source=LAPTOP-FGQM066T;Initial Catalog=Autlantico;Integrated Security=true;";

        public List<Hosting> GetAll()
        {
            try
            {
                List<Hosting> hostings = null;

                string query = @"SELECT [Id]
                                       ,[Status]
                                  FROM [dbo].[tbHosting]";

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
                                  FROM [dbo].[tbHosting]
                                  WHERE [Id] = @Id";

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

        public Hosting GetEmpty()
        {
            try
            {
                Hosting hosting = null;

                string query = @"SELECT TOP 1 [Id]
                                       ,[Status]
                                  FROM [dbo].[tbHosting]
                                  WHERE [Status] = 0";

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    hosting = connection.QuerySingle<Hosting>(query);
                }

                return hosting;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao buscar alojamento.");
            }
        }

        public void Update(int id, bool status)
        {
            try
            {
                string query = null;

                //atualiza para ocupado
                if(status == true)
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
                    parameters.Add("@Id", id);

                    connection.QuerySingleOrDefault<Hosting>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar alojamento.");
            }
        }
    }
}
