using System.Threading;
using System.Threading.Tasks;
using AgreementService;
using LBHTenancyAPI.Infrastructure.UseCase.Execution;
using LBHTenancyAPI.UseCases.ArrearsAgreements;

namespace LBHTenancyAPI.Gateways.Arrears
{
    public interface IArrearsAgreementGateway
    {
        Task<IExecuteWrapper<ArrearsAgreementResponse>> CreateArrearsAgreementAsync(ArrearsAgreementRequest request, CancellationToken cancellationToken);
    }
}
