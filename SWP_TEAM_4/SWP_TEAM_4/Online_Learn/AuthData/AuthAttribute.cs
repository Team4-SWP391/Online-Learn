using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

using Online_Learn.Models;

namespace Online_Learn.AuthData {

    public class AuthAttribute : ActionFilterAttribute, IAuthorizationFilter {
        private readonly Online_LearnContext _context = new Online_LearnContext();
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("User") == null)
            {
                context.Result = new RedirectResult("/Login/Login_Udemy");
            }
        }
    }
    //public class AuthAttribute : AuthorizeAttribute {
    //    private readonly Online_LearnContext _context = new Online_LearnContext();
    //    private readonly string[] allowedroles;
    //    public void CustomAuthorizeAttribute(params string[] roles)
    //    {
    //        this.allowedroles = roles;
    //    }

    //    public AuthorizeAttribute(string policy)
    //    {

    //    }

}
