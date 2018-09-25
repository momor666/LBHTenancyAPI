using System.Net;
using System.Net.Http;
using LBHTenancyAPI.Infrastructure.Exceptions;
using LBHTenancyAPI.Infrastructure.UseCase.Execution;

namespace LBHTenancyAPI.Gateways.Contacts
{
    public class Dynamics365RestApiException : APIException
    {
        public ExecutionError ExecutionError { get; set; }

        public Dynamics365RestApiException(HttpResponseMessage response)
        {
            StatusCode = HttpStatusCode.BadGateway;
            ExecutionError = new ExecutionError(response);
        }
    }
}