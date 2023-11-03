using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebBanDienThoai.Controllers
{
    public class BaseController : Controller
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var email = context.HttpContext.Session.GetString("Email");
            if (email == null)
            {
                context.Result = new RedirectToActionResult("Login", "User", new { area = "" });
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
