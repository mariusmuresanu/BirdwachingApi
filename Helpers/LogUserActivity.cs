using BirdwachingApi.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BirdwachingApi.Helpers
{
    public class LogUserActivity : IAsyncActionFilter

    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var reslutContext = await next();

            var userId = int.Parse(reslutContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var repo = reslutContext.HttpContext.RequestServices.GetService<IDatingRepository>();
            var user = await repo.GetUser(userId);
            user.LastActive = DateTime.Now;
            await repo.SaveAll();
        }
    }
}
