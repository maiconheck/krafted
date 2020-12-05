namespace Krafted.Rfc.ProblemDetails.Abstractions
{
    /// <summary>
    /// Represents the response types.
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// The created Microsoft.AspNetCore.Mvc.OkObjectResult for the response.
        /// </summary>
        Ok = 0,

        /// <summary>
        /// The created Microsoft.AspNetCore.Mvc.CreatedAtActionResult for the response.
        /// </summary>
        CreatedAtAction = 1,

        /// <summary>
        /// The created Microsoft.AspNetCore.Mvc.NotFoundObjectResult for the response.
        /// </summary>
        NotFound = 2,

        /// <summary>
        /// The created Microsoft.AspNetCore.Mvc.BadRequestObjectResult for the response.
        /// </summary>
        BadRequest = 4
    }
}
