using System;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    public interface IAuthenticationBrokerService
    {
        Uri ApplicationCallbackUri { get; }
        Task<AuthenticationResult> AuthenticateAsync(Uri url, Uri callbackUri = null, AuthenticationOptions options = AuthenticationOptions.None);
    }
}