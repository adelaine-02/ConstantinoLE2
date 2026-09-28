namespace BlogDataLibrary.Database;

public interface ISqlDataAccess
{
    List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName, bool isStoredProcedure = true);
    void SaveData<T>(string storedProcedure, T parameters, string connectionStringName, bool isStoredProcedure = true);
}