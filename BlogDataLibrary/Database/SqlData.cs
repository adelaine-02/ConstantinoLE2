using BlogDataLibrary.Models;

namespace BlogDataLibrary.Database;

public class SqlData : ISqlData
{
    private readonly ISqlDataAccess _db;

    public SqlData(ISqlDataAccess db)
    {
        _db = db;
    }

    public List<ListPostModel> ListPosts()
    {
        return _db.LoadData<ListPostModel, dynamic>(
            "dbo.spPosts_List", 
            new { }, 
            "Default", 
            true);
    }

    public UserModel Authenticate(string username, string password)
    {
        return _db.LoadData<UserModel, dynamic>(
            "dbo.spUsers_Authenticate",
            new { username, password },
            "Default",
            true).FirstOrDefault();
    }

    public void Register(string username, string firstName, string lastName, string password)
    {
        _db.SaveData(
            "dbo.spUsers_Register",
            new { username, firstName, lastName, password },
            "Default",
            true);
    }

    public void AddPost(PostModel post)
    {
        _db.SaveData(
            "dbo.spPosts_Insert",
            new { post.UserId, post.Title, post.Body, post.DateCreated },
            "Default",
            true);
    }
}
