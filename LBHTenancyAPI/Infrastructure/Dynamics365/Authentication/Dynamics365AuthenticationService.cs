using System.Threading.Tasks;
using LBHTenancyAPI.Infrastructure.Dynamics365.Authentication.Exceptions;
using LBHTenancyAPI.Settings.CRM;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace LBHTenancyAPI.Infrastructure.Dynamics365.Authentication
{
    public class Dynamics365AuthenticationService : IDynamics365AuthenticationService
    {
        private readonly Dynamics365Settings _dynamics365Settings;

        public Dynamics365AuthenticationService(Dynamics365Settings dynamics365Settings)
        {
            _dynamics365Settings = dynamics365Settings;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var validationResult = _dynamics365Settings.IsValid();
            if (!validationResult)
                throw new Dynamics365IsNotConfiguredException();
            var clientcred = new ClientCredential(_dynamics365Settings?.ClientId, _dynamics365Settings?.AppKey);
            var authenticationContext = new AuthenticationContext(_dynamics365Settings?.AadInstance + _dynamics365Settings?.TenantId);
            var authenticationResult = await authenticationContext.AcquireTokenAsync(_dynamics365Settings?.OrganizationUrl, clientcred).ConfigureAwait(false);

            var requestedToken = authenticationResult.AccessToken;

            return requestedToken;
        }
    }
}
