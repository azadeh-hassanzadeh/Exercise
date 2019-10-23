using Exercise.Models;
using Microsoft.Extensions.Configuration;

namespace Exercise.Services
{
    public class ConfigDetails : IConfigDetails
    {
        private readonly IConfiguration _configuration;

        public ConfigDetails(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetResourceBaseUrl()
        {
            return _configuration.GetSection("WooliesXBaseUrl").GetSection("BaseUrl").Value;
        }

        public User GetUserDetails()
        {
            var userDetails = _configuration.GetSection("UserDetails");
            return new User
            {
                Name = userDetails.GetSection("Name").Value,
                Token = userDetails.GetSection("Token").Value
            };
        }
    }
}