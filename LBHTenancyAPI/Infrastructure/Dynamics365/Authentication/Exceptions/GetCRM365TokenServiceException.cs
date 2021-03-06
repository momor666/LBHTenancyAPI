using System;
using System.Net;
using LBHTenancyAPI.Infrastructure.Exceptions;

namespace LBHTenancyAPI.Infrastructure.Dynamics365.Authentication.Exceptions
{
    public class GetCRM365TokenServiceException : APIException
    {
        public GetCRM365TokenServiceException(HttpStatusCode statusCode) : base(statusCode) { }

        public GetCRM365TokenServiceException(Exception ex) : base(ex) { }
    }

}
