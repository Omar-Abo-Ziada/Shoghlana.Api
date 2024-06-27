using Microsoft.AspNetCore.Identity;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUserRepository(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)  
        {
            ApplicationUser? user = await userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email) 
        {
            ApplicationUser? user = await userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<IdentityResult> InsertAsync(ApplicationUser User , string Role, string Password = null)  
        {
            IdentityResult result;

            if (Password == null)
            {
               result  = await userManager.CreateAsync(User);
            }

            else
            {
               result = await userManager.CreateAsync(User, Password);
            }

            await userManager.AddToRoleAsync(User, Role);
            return result;
        }

        //public async Task<IdentityResult> InsertWithPasswordAsync(ApplicationUser User, string Role, string Password) 
        //{
        //    IdentityResult result = await userManager.CreateAsync(User, Password);
        //    await userManager.AddToRoleAsync(User, Role);
        //    return result;
        //}
    }
}
