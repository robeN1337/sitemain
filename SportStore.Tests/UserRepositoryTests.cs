using SportStore.API.Entities;
using SportStore.API.Repositories;

namespace SportStore.Tests
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _userRepository;
        public UserRepositoryTests()
        {
            _userRepository = new UserRepository();
        }
        [Fact]
        public void CreateUser_ShouldReturnNewUserWithGeneratedId()
        {
            // Arrange
            var newUser = new User { Username = "Test User" };
            // Act
            var createdUser = _userRepository.CreateUser(newUser);
            // Assert
            Assert.NotNull(createdUser);
            Assert.NotEqual(Guid.Empty, createdUser.guid);
            Assert.Equal(newUser.Username, createdUser.Username);
        }
        [Fact]
        public void DeleteUser_ShouldReturnTrueAndRemoveUser()
        {
            // Arrange
            var userRepository = new UserRepository();
            var testUser = new User { guid = Guid.NewGuid(), Username = "Test User" };
            userRepository.Users.Add(testUser);
            // Act
            bool result = userRepository.DeleteUser(testUser.guid);
            // Assert
            Assert.True(result);
            Assert.Empty(userRepository.Users);
        }
        [Fact]
        public void EditUser_ShouldUpdateExistingUser()
        {
            // Arrange
            var userRepository = new UserRepository();
            var originalUser = new User
            {
                guid = Guid.NewGuid(),
                Username = "Original User"
            };
            userRepository.Users.Add(originalUser);
            // Act
            var editedUser = new User { guid = originalUser.guid, Username = "Edited User" };
            var result = userRepository.EditUser(editedUser, originalUser.guid);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Edited User", result.Username);
            Assert.Single(userRepository.Users);
        }
        [Fact]
        public void FindUserById_ShouldReturnUserByValidId()
        {
            // Arrange
            var userRepository = new UserRepository();
            var testUser = new User { guid = Guid.NewGuid(), Username = "Test User" };
            userRepository.Users.Add(testUser);
            // Act
            var foundUser = userRepository.FindUserById(testUser.guid);
            // Assert
            Assert.NotNull(foundUser);
            Assert.Equal(testUser.guid, foundUser.guid);
            Assert.Equal(testUser.Username, foundUser.Username);
        }
        [Fact]
        public void FindUserById_ShouldThrowExceptionForInvalidId()
        {
            // Arrange
            var userRepository = new UserRepository();
            // Act & Assert
            Assert.Throws<Exception>(() => userRepository.FindUserById(Guid.NewGuid()));

        }
        [Fact]
        public void GetUsers_ShouldReturnAllUsers()
        {
            // Arrange
            var userRepository = new UserRepository();
            var testUser1 = new User { guid = Guid.NewGuid(), Username = "User 1" };
            var testUser2 = new User { guid = Guid.NewGuid(), Username = "User 2" };
            userRepository.Users.Add(testUser1);
            userRepository.Users.Add(testUser2);
            // Act
            var users = userRepository.GetUsers();
            // Assert
            Assert.NotNull(users);
            Assert.Equal(2, users.Count);
            Assert.Contains(testUser1, users);
            Assert.Contains(testUser2, users);
        }
        [Fact]
        public void FindUserById_ShouldThrowExceptionForNonExistentId()
        {
            // Arrange
            var userRepository = new UserRepository();
            // Act & Assert
            Assert.Throws<Exception>(() =>
           userRepository.FindUserById(Guid.NewGuid()));
        }
    }
}



