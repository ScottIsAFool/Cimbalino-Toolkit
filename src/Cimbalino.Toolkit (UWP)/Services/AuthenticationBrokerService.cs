using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;

namespace Cimbalino.Toolkit.Services
{
    public class AuthenticationBrokerService : IAuthenticationBrokerService
    {
        public Uri ApplicationCallbackUri => WebAuthenticationBroker.GetCurrentApplicationCallbackUri();

        public virtual async Task<AuthenticationResult> AuthenticateAsync(Uri url, Uri callbackUri = null, AuthenticationOptions options = AuthenticationOptions.None)
        {
            AuthenticationResult result = null;
#if WINDOWS_APP || WINDOWS_UWP
            var webOption = GetOption(options);
            var task = callbackUri == null ? WebAuthenticationBroker.AuthenticateAsync(webOption, url) : WebAuthenticationBroker.AuthenticateAsync(webOption, url, callbackUri);

            var webResult = await task;
            result = new AuthenticationResult(webResult.ResponseData, webResult.ResponseErrorDetail, GetStatus(webResult.ResponseStatus));
#elif WINDOWS_PHONE_APP
            var view = CoreApplication.GetCurrentView();
            var tcs = new TaskCompletionSource<WebAuthenticationResult>();

            TypedEventHandler<CoreApplicationView, IActivatedEventArgs> handler = null;
            handler = (a, e) =>
            {
                view.Activated -= handler;
                WebAuthenticationResult webResult = null;
                var continuationEventArgs = e as IContinuationActivatedEventArgs;
                if (continuationEventArgs != null)
                {
                    switch (continuationEventArgs.Kind)
                    {
                        case ActivationKind.WebAuthenticationBrokerContinuation:
                            var arguments = continuationEventArgs as WebAuthenticationBrokerContinuationEventArgs;
                            webResult = arguments?.WebAuthenticationResult;
                            break;
                    }
                }

                tcs.SetResult(webResult);
            };

            view.Activated += handler;
            WebAuthenticationBroker.AuthenticateAndContinue(url, callbackUri, new ValueSet(), GetOption(options));

            var taskResult = await tcs.Task;
            result = new AuthenticationResult(taskResult.ResponseData, taskResult.ResponseErrorDetail, GetStatus(taskResult.ResponseStatus));
#else

#endif
            return result;
        }

        private static WebAuthenticationOptions GetOption(AuthenticationOptions option)
        {
            var i = (int) option;
            return (WebAuthenticationOptions) i;
        }

        private static AuthenticationStatus GetStatus(WebAuthenticationStatus status)
        {
            var i = (int) status;
            return (AuthenticationStatus) i;
        }
    }
}