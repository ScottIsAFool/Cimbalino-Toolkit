namespace Cimbalino.Toolkit.Services
{
    public class AuthenticationResult
    {
        internal AuthenticationResult(string responseData, uint responseErrorDetail, AuthenticationStatus authenticationStatus)
        {
            ResponseData = responseData;
            ResponseErrorDetail = responseErrorDetail;
            AuthenticationStatus = authenticationStatus;
        }

        public string ResponseData { get; private set; }
        public uint ResponseErrorDetail { get; private set; }
        public AuthenticationStatus AuthenticationStatus { get; private set; }
    }
}