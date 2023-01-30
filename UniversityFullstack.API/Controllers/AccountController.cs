using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniversityFullstack.BL.DTOs;

namespace UniversityFullstack.API.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //demo
            bool isCredentialValid = (loginDTO.Password == "12345");
            if (!isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(loginDTO.Username);
                return Ok(token);
            }
            else
                return Unauthorized();
        }
    }
}
