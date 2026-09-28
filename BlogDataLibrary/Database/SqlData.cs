using BlogDataLibrary.Models;

namespace BlogDataLibrary.Database;

public class SqlData : ISqlData
{
    private readonly SqlDataAccess _db;

    public SqlData(SqlDataAccess db)
    {
        _db = db;
    }

    public UserModel Authenticate(string username, string password)
    {
        var output = _db.LoadData<UserModel, dynamic>(
            "dbo.spUsers_Lookup",
            new { UserName = username, Password = password },
            "Default",
            true);

        return output.FirstOrDefault();
    }

    public void Register(string username, string firstName, string lastName, string password)
    {
        _db.SaveData<dynamic>(
            "dbo.spUsers_Register",
            new { UserName = username, FirstName = firstName, LastName = lastName, Password = password },
            "Default",
            true);
    }

    public void AddPost(PostModel post)
    {
        _db.SaveData<dynamic>(
            "dbo.spPosts_Insert",
            new { post.UserId, post.Title, post.Body, post.DateCreated },
            "Default",
            true);
    }

    public List<ListPostModel> ListPosts()
    {
        return _db.LoadData<ListPostModel, dynamic>(
            "dbo.spPosts_List",
            new { },
            "Default",
            true);
    }

    public ListPostModel ShowPostDetails(int id)
    {
        return _db.LoadData<ListPostModel, dynamic>(
            "dbo.spPosts_Details",
            new { id },
            "Default",
            true).FirstOrDefault();
    }
}