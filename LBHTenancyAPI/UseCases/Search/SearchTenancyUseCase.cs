using System.Threading;
using System.Threading.Tasks;
using LBHTenancyAPI.Gateways.Search;
using LBHTenancyAPI.Infrastructure.Exceptions;
using LBHTenancyAPI.UseCases.Contacts;
using LBHTenancyAPI.UseCases.Contacts.Models;

namespace LBHTenancyAPI.UseCases.Search
{
    public class SearchTenancyUseCase : ISearchTenancyUseCase
    {
        private readonly ISearchGateway _searchGateway;

        public SearchTenancyUseCase(ISearchGateway searchGateway)
        {
            _searchGateway = searchGateway;
        }

        public async Task<SearchTenancyResponse> ExecuteAsync(SearchTenancyRequest request, CancellationToken cancellationToken)
        {
            //validate
            if (request == null)
                throw new BadRequestException();

            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
                throw new BadRequestException(validationResponse);

            var response = await _searchGateway.SearchTenanciesAsync(request, cancellationToken).ConfigureAwait(false);

            //tenancy could have no attached contacts
            if (response == null)
                return new SearchTenancyResponse();

            //Create real response
            var useCaseResponse = new SearchTenancyResponse
            {
                Tenancies = response
            };

            return useCaseResponse;
        }
    }
}
