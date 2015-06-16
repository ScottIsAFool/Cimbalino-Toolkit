#if WINDOWS_PHONE
using System;
using Cimbalino.Toolkit.Helpers;
#else
using System;
using Windows.ApplicationModel.DataTransfer;
using Cimbalino.Toolkit.Helpers;
#endif

namespace Cimbalino.Toolkit.Services
{
    public class ShareContractService : IShareContractService
    {
#if !WINDOWS_PHONE
        public event EventHandler<ShareDataRequestedEventArgs> DataRequested;

        public void Show()
        {
            var manager = DataTransferManager.GetForCurrentView();
            manager.DataRequested += ManagerOnDataRequested;

            DataTransferManager.ShowShareUI();
        }

        private void ManagerOnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var request = args?.Request;
            sender.DataRequested -= ManagerOnDataRequested;

            var eventHandler = DataRequested;
            eventHandler?.Invoke(this, new ShareDataRequestedEventArgs(new ShareDataRequest(request)));
        }
#else
        public event EventHandler<ShareDataRequestedEventArgs> DataRequested
        {
            add
            {
                ExceptionHelper.ThrowNotSupported();
            }
            remove
            {

            }
        }

        public void Show()
        {
            ExceptionHelper.ThrowNotSupported();
        }
#endif
    }

    public class ShareDataRequest : IShareDataRequest
    {
#if !WINDOWS_PHONE
        private readonly DataRequest _request;
        private DataRequestDeferral _deferral;
        internal ShareDataRequest(DataRequest request)
        {
            _request = request;
        }

        public void Complete()
        {
            if (_deferral == null)
            {
                throw new InvalidOperationException("You must call GetDeferral() before calling this method");
            }

            _deferral.Complete();
        }

        public void GetDeferral()
        {
            _deferral = _request?.GetDeferral();
        }

        public string Title
        {
            get
            {
                return _request?.Data?.Properties?.Title;
            }
            set
            {
                if (_request == null)
                {
                    ExceptionHelper.ThrowNotSupported();
                    return;
                }

                _request.Data.Properties.Title = value;
            }
        }

        public string Description
        {
            get
            {
                return _request?.Data?.Properties?.Description;
            }
            set
            {
                if (_request == null)
                {
                    ExceptionHelper.ThrowNotSupported();
                    return;
                }

                _request.Data.Properties.Description = value;
            }
        }

        public void FailWithDisplayText(string text)
        {
            _request?.FailWithDisplayText(text);
        }

        public void SetApplicationLink(Uri value)
        {
            _request?.Data?.SetApplicationLink(value);
        }

        public void SetData(string formatId, object value)
        {
            _request?.Data?.SetData(formatId, value);
        }

        public void SetHtmlFormat(string value)
        {
            _request?.Data?.SetHtmlFormat(value);
        }

        public void SetRtf(string value)
        {
            _request?.Data?.SetRtf(value);
        }

        public void SetText(string value)
        {
            _request?.Data?.SetText(value);
        }

        public void SetWebLink(Uri value)
        {
            _request?.Data?.SetWebLink(value);
        }
#else
        public string Title
        {
            get
            {
                return ExceptionHelper.ThrowNotSupported<string>();
            }
            set
            {
                ExceptionHelper.ThrowNotSupported();
            }
        }

        public string Description
        {
            get
            {
                return ExceptionHelper.ThrowNotSupported<string>();
            }
            set
            {
                ExceptionHelper.ThrowNotSupported();
            }
        }

        public void Complete()
        {
            ExceptionHelper.ThrowNotSupported();
        }

        public void GetDeferral()
        {
            ExceptionHelper.ThrowNotSupported();
        }

        public void FailWithDisplayText(string text)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        public void SetApplicationLink(Uri value)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        public void SetData(string formatId, object value)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        public void SetHtmlFormat(string value)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        public void SetRtf(string value)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        public void SetText(string value)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        public void SetWebLink(Uri value)
        {
            ExceptionHelper.ThrowNotSupported();
        }
#endif
    }
}
