using Assert = Xunit.Assert;

namespace RSystem.Task.Tests
{
    public class UserTests
    {

        private readonly UserService _userService;

        public UserTests()
        {
            // Initialize UserService with an empty or mocked user list for testing purposes
            _userService = new UserService();
        }

        [Fact]
        public void CreateUser_ShouldAddUserToList()
        {
            // Arrange
            var newUser = new User { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };

            // Act
            var createdUser = _userService.CreateUser(newUser);

            // Assert
            Assert.NotNull(createdUser);
            Assert.True(createdUser.Id > 0);
            Assert.Contains(_userService.GetAllUsers(), u => u.Id == createdUser.Id);
        }

        [Fact]
        public void GetUserById_ShouldReturnCorrectUser()
        {
            // Arrange
            var newUser = new User { FirstName = "Jay", LastName = "Doe", Email = "Jay.doe@example.com" };
            var createdUser = _userService.CreateUser(newUser);

            // Act
            var result = _userService.GetUserById(createdUser.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Jay", result.FirstName);
            Assert.Equal("Doe", result.LastName);
            Assert.Equal("Jay.doe@example.com", result.Email);
        }

        [Fact]
        public void GetUserById_ShouldReturnNullIfUserDoesNotExist()
        {
            // Act
            var result = _userService.GetUserById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void UpdateUser_ShouldModifyUserDetails()
        {
            // Arrange
            var newUser = new User { FirstName = "Jay", LastName = "Doe", Email = "Jay.doe@example.com" };
            var createdUser = _userService.CreateUser(newUser);

            var updatedUser = new User { FirstName = "Jacob", LastName = "Smith", Email = "jacob.smith@example.com" };

            // Act
            var updateResult = _userService.UpdateUser(createdUser.Id, updatedUser);
            var result = _userService.GetUserById(createdUser.Id);

            // Assert
            Assert.True(updateResult);
            Assert.Equal("Jacob", result.FirstName);
            Assert.Equal("Smith", result.LastName);
            Assert.Equal("jacob.smith@example.com", result.Email);
        }

        [Fact]
        public void UpdateUser_ShouldReturnFalseIfUserDoesNotExist()
        {
            // Arrange
            var updatedUser = new User { FirstName = "Jake", LastName = "Smith", Email = "jake.smith@example.com" };

            // Act
            var updateResult = _userService.UpdateUser(999, updatedUser);

            // Assert
            Assert.False(updateResult);
        }

        [Fact]
        public void DeleteUser_ShouldRemoveUserFromList()
        {
            // Arrange
            var newUser = new User { FirstName = "Mary", LastName = "Jones", Email = "mary.jones@example.com" };
            var createdUser = _userService.CreateUser(newUser);

            // Act
            var deleteResult = _userService.DeleteUser(createdUser.Id);
            var result = _userService.GetUserById(createdUser.Id);

            // Assert
            Assert.True(deleteResult);
            Assert.Null(result);
        }

        [Fact]
        public void DeleteUser_ShouldReturnFalseIfUserDoesNotExist()
        {
            // Act
            var deleteResult = _userService.DeleteUser(999);

            // Assert
            Assert.False(deleteResult);
        }
    }
}