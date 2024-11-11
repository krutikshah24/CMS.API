public interface IUserService
{
    User CreateUser(User newUser);
    bool DeleteUser(int id);
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
    IEnumerable<User> GetUsersByPage(int pageNumber, int pageSize, out int totalRecords);
    bool UpdateUser(int id, User updatedUser);
}