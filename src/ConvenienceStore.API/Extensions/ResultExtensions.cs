using ConvenienceStore.Application.Models.Results;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult<T>(
            this ControllerBase controller,
            Result<T> result)
        {
            return controller.StatusCode(result.StatusCode, result);
        }
    }
}
