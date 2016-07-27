using Android.Content;
using Plugin.CurrentActivity;

namespace Cimbalino.Toolkit.Services
{
    public abstract class BaseAndroidService
    {
        protected virtual string SystemServiceString { get; }
        protected Context CurrentContext => CrossCurrentActivity.Current.Activity;

        protected T GetSystemService<T>() where T : class
        {
            if (string.IsNullOrEmpty(SystemServiceString))
            {
                return default(T);
            }

            return CurrentContext.GetSystemService(SystemServiceString) as T;
        }
    }
}