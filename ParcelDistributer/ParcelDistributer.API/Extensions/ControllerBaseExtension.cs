using Microsoft.AspNetCore.Mvc;
using ParcelDistributer.DataAccess.Models.Base;

namespace ParcelDistributer.API.Extensions
{
    public static class ControllerBaseExtension
    {
        public static IActionResult Send(this ControllerBase controller, object response)
        {
            if (response.GetType().GetProperty("Error")?.GetValue(response, null) is ErrorDTO err && err.ErrorType != null)
            {
                return controller.BadRequest(response);
            }
            return controller.Ok(response);
        }
    }
}