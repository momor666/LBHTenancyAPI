using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using AgreementService;
using LBHTenancyAPI.Infrastructure.UseCase.Execution;
using LBHTenancyAPI.Interfaces;
using LBHTenancyAPI.UseCases.ArrearsAgreements;

namespace LBHTenancyAPI.Gateways.Arrears.Impl
{
    /// <summary>
    /// ArrearsActionDiaryGateway marshalls calls to the Database for reads and Web Service for writes
    /// </summary>
    public class ArrearsAgreementGateway : IArrearsAgreementGateway
    {
        /// <summary>
        /// WCF Service Interface which allows us to create action diary entries
        /// </summary>
        private readonly IArrearsAgreementServiceChannel _actionDiaryService;
        private readonly IArrearsServiceRequestBuilder _arrearsServiceRequestBuilder;

        public ArrearsAgreementGateway(IArrearsAgreementServiceChannel actionDiaryService, IArrearsServiceRequestBuilder arrearsServiceRequestBuilder)
        {
            _actionDiaryService = actionDiaryService;
            _arrearsServiceRequestBuilder = arrearsServiceRequestBuilder;
        }

        public async Task<IExecuteWrapper<ArrearsAgreementResponse>> CreateArrearsAgreementAsync(ArrearsAgreementRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("request is null");

            request = _arrearsServiceRequestBuilder.BuildArrearsRequest<ArrearsAgreementRequest>(request);
            var response = await _actionDiaryService.CreateArrearsAgreementAsync(request).ConfigureAwait(false);
            if(_actionDiaryService.State != CommunicationState.Closed)
                _actionDiaryService.Close();
            var executeResponse = new ExecuteWrapper<ArrearsAgreementResponse>(response);
            return executeResponse;
        }
    }
}
