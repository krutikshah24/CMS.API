using Newtonsoft.Json;

public class UserService : IUserService
{
    private readonly string _filePath = "Data/user.json";
    private List<User> _users;

    /// <summary>
    /// Initializes a new instance of the <see cref=".UserService"/> class.
    /// </summary>
    public UserService()
    {
        // Initialize or load users from JSON file
        _users = LoadUsers();
    }

    /// <summary>
    /// Loads the users.
    /// </summary>
    /// <returns></returns>
    private List<User> LoadUsers()
    {
        if (!File.Exists(_filePath)) return new List<User>();

        var jsonData = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
    }

    private void SaveUsers()
    {
        var jsonData = JsonConvert.SerializeObject(_users, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(_filePath, jsonData);
    }

    /// <summary>
    /// Gets all users.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<User> GetAllUsers() => _users;

    /// <summary>
    /// Gets the user by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public User? GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);

    /// <summary>
    /// Creates the user.
    /// </summary>
    /// <param name="newUser">The new user.</param>
    /// <returns></returns>
    public User CreateUser(User newUser)
    {
        newUser.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
        _users.Add(newUser);
        SaveUsers();
        return newUser;
    }

    /// <summary>
    /// Updates the user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="updatedUser">The updated user.</param>
    /// <returns></returns>
    public bool UpdateUser(int id, User updatedUser)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null) return false;

        existingUser.FirstName = updatedUser.FirstName;
        existingUser.LastName = updatedUser.LastName;
        existingUser.Email = updatedUser.Email;
        SaveUsers();
        return true;
    }

    /// <summary>
    /// Deletes the user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public bool DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return false;

        _users.Remove(user);
        SaveUsers();
        return true;
    }

    /// <summary>
    /// Gets the users by page.
    /// </summary>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="totalRecords">The total records.</param>
    /// <returns></returns>
    public IEnumerable<User> GetUsersByPage(int pageNumber, int pageSize, out int totalRecords)
    {
        totalRecords = _users.Count;
        return _users
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}