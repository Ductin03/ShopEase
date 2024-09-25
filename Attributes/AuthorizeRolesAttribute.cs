using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClothingStore.Attributes
{
    public class AuthorizeRolesAttribute : Attribute, IAuthorizationFilter
    {
        private new List<string> _roles;
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            _roles = roles.ToList();
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new ForbidResult();
                return;
            }
            else
            {
                var role=user.Claims.FirstOrDefault(x=>x.Type=="RoleName")?.Value;
                if (!_roles.Contains(role)){
                    context.Result = new ForbidResult();
                    return;
                }
            }

        }
    }
}

