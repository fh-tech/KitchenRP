using Microsoft.AspNetCore.Mvc;

namespace KitchenRP.Web
{
    public static class Errors
    {
        public static ProblemDetails NotYetRegisteredError()
        {
            return new ProblemDetails
            {
                Type = "NotYetRegistered",
                Title = "Account is not registered",
                Detail = "Your credentials seems valid, but your account is not yet registered with ProjectKitchen.\n" +
                         "Only ProjectKitchen staff can activate your account.",
                Status = 403
            };
        }

        public static ProblemDetails InvalidCredentials()
        {
            return new ProblemDetails
            {
                Type = "InvalidCredentials",
                Title = "Invalid credentials",
                Detail = "Username or password were invalid. Make sure you use your usual university login",
                Status = 403
            };
        }
    }
}