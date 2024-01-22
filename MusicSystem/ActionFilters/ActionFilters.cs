using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicSystem.Entities;
using MusicSystem.ExtensionMethods;

namespace MusicSystem.ActionFilters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<Users>("loggedUser") == null)
            {
                context.Result = new RedirectResult("/Login/Index");
            }
        }
    }
}
