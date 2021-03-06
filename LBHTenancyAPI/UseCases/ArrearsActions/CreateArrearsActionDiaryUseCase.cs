using System.Threading.Tasks;
using AgreementService;
using LBHTenancyAPI.Gateways;
using LBHTenancyAPI.Gateways.Arrears;
using LBHTenancyAPI.Interfaces;

namespace LBHTenancyAPI.UseCases.ArrearsActions
{
    /// <summary>
    /// Use Case for creating Arrears actions diary entry
    /// </summary>
    public class CreateArrearsActionDiaryUseCase: ICreateArrearsActionDiaryUseCase
    {
        private readonly IArrearsActionDiaryGateway _arrearsActionDiaryGateway;
        public readonly IArrearsServiceRequestBuilder _requestBuilder;
        public CreateArrearsActionDiaryUseCase(
            IArrearsActionDiaryGateway arrearsActionDiaryGateway,
            IArrearsServiceRequestBuilder arrearsRequestBuilder)
        {
            _arrearsActionDiaryGateway = arrearsActionDiaryGateway;
            _requestBuilder = arrearsRequestBuilder;
        }

        public async Task<ArrearsActionResponse> ExecuteAsync(ArrearsActionCreateRequest request)
        {
            request = _requestBuilder.BuildArrearsRequest(request);

            var response = await _arrearsActionDiaryGateway.CreateActionDiaryEntryAsync(request);

            return response;
        }
    }
}
