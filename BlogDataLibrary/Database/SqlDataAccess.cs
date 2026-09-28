using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace BlogDataLibrary.Database;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName, bool isStoredProcedure = true)
    {
        string connectionString = _config.GetConnectionString(connectionStringName);
        CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: commandType).ToList();
            return rows;
        }
    }

    public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName, bool isStoredProcedure = true)
    {
        string connectionString = _config.GetConnectionString(connectionStringName);
        CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(storedProcedure, parameters, commandType: commandType);
        }
    }
}