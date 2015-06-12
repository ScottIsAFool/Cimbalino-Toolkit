#if WINDOWS_UAP 
using System;
using System.Threading.Tasks;
using Windows.Graphics.Printing;
using Windows.Graphics.Printing3D;
using Cimbalino.Toolkit.Helpers;
#elif WINDOWS_APP
using System;
using System.Threading.Tasks;
using Windows.Graphics.Printing;
using Cimbalino.Toolkit.Helpers;
#else
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
#endif

namespace Cimbalino.Toolkit.Services
{
    public class PrinterService : IPrinterService
    {
#if WINDOWS_UAP || WINDOWS_APP
        public PrinterService()
        {
            PrintManager.GetForCurrentView().PrintTaskRequested += OnPrintTaskRequested;
        }

        private void OnPrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            var eventHandler = PrintTaskRequested;
            eventHandler?.Invoke(this, new PrinterRequestEventArgs(new PrinterServiceTask(args)));
        }

        public event EventHandler<PrinterRequestEventArgs> PrintTaskRequested;
        public event EventHandler<PrinterTaskCompletedEventArgs> PrintTaskCompleted;
#else
        public event EventHandler<PrinterRequestEventArgs> PrintTaskRequested
        {
            add
            {
                ExceptionHelper.ThrowNotSupported();
            }
            remove
            {
                
            }
        }

        public event EventHandler<PrinterTaskCompletedEventArgs> PrintTaskCompleted
        {
            add
            {
                ExceptionHelper.ThrowNotSupported();
            }
            remove
            {

            }
        }
#endif

        public Task<bool> ShowAsync()
        {
#if WINDOWS_UAP || WINDOWS_APP
            return PrintManager.ShowPrintUIAsync().AsTask();
#else
            return ExceptionHelper.ThrowNotSupported<Task<bool>>();
#endif
        }

        public Task<bool> Show3DAsync()
        {
#if WINDOWS_UAP
            return Print3DManager.ShowPrintUIAsync().AsTask();
#else
            return ExceptionHelper.ThrowNotSupported<Task<bool>>();
#endif
        }
    }

    public class PrinterServiceTask : IPrinterServiceTask
    {
#if WINDOWS_UAP || WINDOWS_APP
        private readonly PrintTaskRequestedEventArgs _args;

        private PrintTaskRequestedDeferral _deferral;

        public PrinterServiceTask(PrintTaskRequestedEventArgs args)
        {
            _args = args;
        }
#endif

        public void Complete()
        {
#if WINDOWS_UAP || WINDOWS_APP
            if (_deferral == null)
            {
                ExceptionHelper.ThrowNotSupported();
                return;
            }

            _deferral.Complete();
#else
            ExceptionHelper.ThrowNotSupported();
#endif
        }

        public void GetDeferral()
        {
#if WINDOWS_UAP || WINDOWS_APP
            var request = _args?.Request;
            _deferral = request?.GetDeferral();
#else
            ExceptionHelper.ThrowNotSupported();
#endif
        }

        public void CreatePrintTask(string title)
        {
#if WINDOWS_UAP || WINDOWS_APP

#else
            ExceptionHelper.ThrowNotSupported();
#endif
        }
    }
}
