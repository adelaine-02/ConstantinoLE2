using BlogDataLibrary.Models;

namespace BlogDataLibrary.Database;

public interface ISqlData
{
    List<ListPostModel> ListPosts();
    UserModel Authenticate(string username, string password);
    void Register(string username, string firstName, string lastName, string password);
    void AddPost(PostModel post);
}