using System.Linq.Expressions;

namespace CompetitionEventsManager.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<GetUserDto> GetAsync(Expression<Func<LocalUser, bool>> filter);
        Task<bool> IsRegisteredAsync(int userId);
        Task<bool> IsUniqueUserAsync(string username);
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        Task<LocalUser> RegisterAsync(RegistrationRequest registrationRequest);
        Task Update(GetUserDto userDto);

    }
}