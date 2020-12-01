using Krafted.Guards;
using Krafted.Rfc.ProblemDetails;
using Krafted.Rfc.ProblemDetails.Types;
using Microsoft.AspNetCore.Mvc;

namespace Krafted.AspNetCore
{
    /// <summary>
    /// Represents the base class for the MVC controllers to Web Apis (no view support).
    /// </summary>
    /// <seealso cref="ControllerBase" />
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Gets the user name (the e-mail, in our configuration) of the current user.
        /// </summary>
        /// <value>
        /// The user name (the e-mail, in our configuration) of the current user.
        /// </value>
        protected string UserName => HttpContext.User.Identity.Name;

        /// <summary>
        /// Creates an ActionResult response, in a standard format, accordingly with the result of the Handlers, with the given response status code.
        /// </summary>
        /// <param name="result">The result of the Handler.</param>
        /// <param name="createActionName">The name of the action to use for generating the URL when a POST is executed.</param>
        /// <returns>The ActionResult response in a standard format.</returns>
        protected new IActionResult Response(IResponse result, string createActionName = "PostAsync")
        {
            Guard.Against.Null(result, nameof(result));

            switch (result.Type)
            {
                case ResponseType.Ok:
                    return Ok(result);

                case ResponseType.CreatedAtAction:
                    return CreatedAtAction(createActionName, result);

                case ResponseType.NotFound:
                    return NotFound(result);

                case ResponseType.BadRequest:
                default:
                    return BadRequest(result);
            }
        }
    }
}
