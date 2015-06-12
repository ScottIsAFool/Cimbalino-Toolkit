using System;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    public interface IPrinterService
    {
        event EventHandler<PrinterRequestEventArgs> PrintTaskRequested;
        event EventHandler<PrinterTaskCompletedEventArgs> PrintTaskCompleted;
        Task<bool> ShowAsync();
    }

    public class PrinterRequestEventArgs : EventArgs
    {
        public PrinterRequestEventArgs(IPrinterServiceTask request)
        {
            Request = request;
        }

        public IPrinterServiceTask Request { get; set; }
    }

    public class PrinterTaskCompletedEventArgs : EventArgs
    {
        public PrinterTaskCompletedEventArgs(PrinterTaskCompletion completion)
        {
            Completion = completion;
        }

        public PrinterTaskCompletion Completion { get; set; }
    }

    public interface IDeferral
    {
        void Complete();
        void GetDeferral();
    }

    public interface IPrinterServiceTask : IDeferral
    {
        void CreatePrintTask(string title);
    }

    public enum PrinterTaskCompletion
    {
        //
        // Summary:
        //     An abandoned print task.
        Abandoned = 0,
        //
        // Summary:
        //     A canceled print task.
        Canceled = 1,
        //
        // Summary:
        //     A failed print task.
        Failed = 2,
        //
        // Summary:
        //     A submitted print task.
        Submitted = 3
    }
}
