using Jupiter_api.Models.Authorization;

namespace Jupiter_api.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }
}
