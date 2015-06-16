using System;

namespace Cimbalino.Toolkit.Services
{
    public interface IShareContractService
    {
        void ShowUIAsync();

        event EventHandler<ShareDataRequestedEventArgs> DataRequested;
    }

    public class ShareDataRequestedEventArgs : EventArgs
    {
        public ShareDataRequestedEventArgs(IShareDataRequest request)
        {
            Request = request;
        }

        public IShareDataRequest Request { get; private set; }
    }

    public interface IShareDataRequest : IDeferral
    {
        void FailWithDisplayText(string text);
        void SetApplicationLink(Uri value);
        void SetData(string formatId, object value);
        void SetHtmlFormat(string value);
        void SetRtf(string value);
        void SetText(string value);
        void SetWebLink(Uri value);
    }
}
