using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.Generic
{
    public abstract class MyController : Controller
    {
        public AuthUser GetCurrentUser()
        {

            var credUser = base.User;
            var user = new AuthUser();

            foreach (var item in credUser.Claims)
            {
                if (item.Type == ClaimTypes.NameIdentifier)
                {
                    user.UserId = Convert.ToInt32(item.Value);
                }
                else if (item.Type == ClaimTypes.Name)
                {
                    user.Name = item.Value;
                }
                else if (item.Type == ClaimTypes.Email)
                {
                    user.Mail = item.Value;
                }
                else if (item.Type == ClaimTypes.Role)
                {
                    user.Roles.Add(item.Value);
                }

            }

            return user;

        }
        
    }
}
