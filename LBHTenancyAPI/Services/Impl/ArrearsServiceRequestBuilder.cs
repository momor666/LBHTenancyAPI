using System;
using AgreementService;
using LBHTenancyAPI.Interfaces;

namespace LBHTenancyAPI.Services.Impl
{
    public class ArrearsServiceRequestBuilder : IArrearsServiceRequestBuilder
    {
        private readonly ICredentialsService _credentialsService;
        public ArrearsServiceRequestBuilder(ICredentialsService credentialsService)
        {
            _credentialsService = credentialsService;
        }

        public T BuildArrearsRequest<T>(T arrears) where T:WebRequest
        {
            if(arrears == null)
                throw new ArgumentNullException("ArrearsServiceRequestBuilder-BuildArrearsRequest:arrears is null");
            arrears.DirectUser = _credentialsService.GetUhUserCredentials();
            arrears.SourceSystem = _credentialsService.GetUhSourceSystem();
            return arrears;
        }
    }
}
