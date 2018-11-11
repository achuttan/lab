using Lab.OAuthWeb.API.DataAccess;
using Lab.OAuthWeb.API.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lab.OAuthWeb.API.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private IdentityRepository _idRepository = null;

        public AccountController()
        {
            _idRepository = new IdentityRepository();
        }

        /// <summary>
        /// Registers new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult registerResult = await _idRepository.RegisterUser(user);

            var errorResult = GetErrorResult(registerResult);
            if (errorResult != null)
                return errorResult;

            return Ok();
          
        }

        private IHttpActionResult GetErrorResult(IdentityResult registerResult)
        {
            if (registerResult == null)
            {
                return InternalServerError();
            }
            else if (!registerResult.Succeeded)
            {
                if (registerResult.Errors != null)
                {
                    foreach (var error in registerResult.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}
