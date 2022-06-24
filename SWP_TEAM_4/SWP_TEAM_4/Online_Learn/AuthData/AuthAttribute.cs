using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Online_Learn.AuthData {
    public class AuthAttribute : ActionFilterAttribute, IAuthorizationFilter {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("User") == null)
            {
                context.Result = new RedirectResult("/Login/Login_Udemy");
            }
        }
    }
}
