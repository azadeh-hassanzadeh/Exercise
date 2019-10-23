using Exercise.Models;

namespace Exercise.Services
{
    public interface IConfigDetails
    {
        string GetResourceBaseUrl();
        User GetUserDetails();
    }
}