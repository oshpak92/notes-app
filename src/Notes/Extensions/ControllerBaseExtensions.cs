using Common.System;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Notes.BL.Errors;

namespace Notes.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static ActionResult Result<TData>(this ControllerBase controller, Result<TData, Error> result)
        {
            return result.Match(
                value => controller.Ok(value),
                error =>
                {
                    switch (error.Name!)
                    {
                        case DomainErrorNames.NotFound:
                            return controller.NotFound(new WebServiceError()
                            {
                                Code = (int)System.Net.HttpStatusCode.NotFound,
                                Name = error.Name,
                                Message = error.Message,
                            });
                        default:
                            return (ActionResult)controller.BadRequest(new WebServiceError()
                            {
                                Code = (int)System.Net.HttpStatusCode.BadRequest,
                                Name = error.Name,
                                Message = error.Message,
                            });
                    }
                });
        }
    }
}
