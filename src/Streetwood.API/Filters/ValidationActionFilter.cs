using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Streetwood.API.Filters
{
    public class ValidationActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new Dictionary<string, string[]>();
                var result = new ContentResult();

                foreach (var val in context.ModelState)
                {
                    errors.Add(val.Key, val.Value.Errors.Select(s => s.ErrorMessage).ToArray());
                }

                var content = JsonConvert.SerializeObject(new {errors});
                result.Content = content;
                result.ContentType = "application/json";

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                context.Result = result;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
