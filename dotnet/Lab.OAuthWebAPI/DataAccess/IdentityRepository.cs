using Lab.OAuthWeb.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lab.OAuthWeb.API.DataAccess
{
    public class IdentityRepository : IDisposable
    {
        private IdentityContext _ctx;
        private UserManager<IdentityUser> _userManager; // Provided by Microsoft.AspNet.Identity.EntityFramework

        public IdentityRepository()
        {
            _ctx = new IdentityContext();
            try
            {
                _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityResult result = null;
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };
            try
            {
                result = await _userManager.CreateAsync(user, userModel.Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<IdentityUser> FindUser(string username, string password)
        {
            return await _userManager.FindAsync(username, password);
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}