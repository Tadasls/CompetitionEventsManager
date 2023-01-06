
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Services;
using CompetitionEventsManager.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CompetitionEventsManager.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context;
        private readonly IUserService _userService;
        private DbSet<LocalUser> _dbSet;


        public UserRepository(DBContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
            _dbSet = _context.Set<LocalUser>();
        }



        public virtual bool TryLogin(string userName, string password, out LocalUser? user)
        {
            user =  _context.LocalUsers.FirstOrDefault(x => x.Username == userName);
            if (user == null)
                return false;

            if (!_userService.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return false;

            return true;
        }

        public async Task<int> RegisterAsync(LocalUser user)
        {
            _context.LocalUsers.Add(user);
           await _context.SaveChangesAsync();
            return user.Id;
        }
                    


        public async Task<LocalUser> GetAsync(Expression<Func<LocalUser, bool>> filter, bool tracked = true)
        {
            IQueryable<LocalUser> query = _dbSet.AsQueryable();
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();

        }




        public async Task<bool> IsRegisteredAsync(int userId) // same as exist
        {
            var isRegistered = await _context.LocalUsers.AnyAsync(u => u.Id == userId);
            return isRegistered;
        }

        /// <summary>
        /// Should return a flag indicating if a user with a specified username already exists
        /// </summary>
        /// <param name="username">Registration username</param>
        /// <returns>A flag indicating if username already exists</returns>
        public async Task<bool> IsUniqueUserAsync(string username)
        {
            var user = await _context.LocalUsers.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null) return true;
            return false;
        }


        public bool Exist(string userName)
        {
            return _context.LocalUsers.Any(x => x.Username == userName);
        }





    }
}