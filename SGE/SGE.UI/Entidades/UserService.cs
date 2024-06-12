using System.Collections.Generic;
using System.Threading.Tasks;

public class UserService
{
    public async Task<List<UserModel>> GetUsers()
    {
        // Fetch users from database or API
        return new List<UserModel>
        {
            new UserModel { Email = "user1@example.com", FirstName = "User1", LastName = "Last1" },
            new UserModel { Email = "user2@example.com", FirstName = "User2", LastName = "Last2" },
            // Add more users
        };
    }
}

