using ArchitectureTools.Responses;
using Microsoft.AspNetCore.Mvc;

namespace SolutionTemplate.Api.Controllers.Base
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class BaseController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        internal ActionResult BuildResponse<T>(ActionResponse<T> response) =>
            StatusCode(response.StatusNumber, response);

        internal ActionResult BuildResponse<T>(T response)
        {
            var actionResponse = ActionResponse<T>.Ok(response);
            return BuildResponse(actionResponse);
        }
    }
}
