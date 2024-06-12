using System.Threading.Tasks;

public class AuthService
{
    // This would normally interact with a backend service or database
    private Dictionary<string, List<string>> userPermissions = new Dictionary<string, List<string>>();

    public async Task<bool> Login(string email, string password)
    {
        // Handle login logic
        return true;
    }

    public async Task<bool> Register(RegisterModel model)
    {
        // Handle registration logic
        return true;
    }

    public async Task<bool> HasPermission(string permission)
    {
        // Check if the logged-in user has the specified permission
        return userPermissions["currentUserEmail"].Contains(permission);
    }
    public async Task<bool> UpdateUser(UserModel user){
      return true;
    }
}
