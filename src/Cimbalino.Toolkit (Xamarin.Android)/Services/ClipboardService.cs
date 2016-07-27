using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using JavaUri = Android.Net.Uri;

namespace Cimbalino.Toolkit.Services
{
    public class ClipboardService : BaseAndroidService, IClipboardService
    {
        protected override string SystemServiceString => Context.ClipboardService;
        private ClipboardManager ClipboardManager => GetSystemService<ClipboardManager>();
        public bool ContainsText => CheckForType(ClipDescription.MimetypeTextPlain);
        public bool ContainsBitmap { get; } = false;
        public bool ContainsHtml => CheckForType(ClipDescription.MimetypeTextHtml);
        public bool ContainsRtf { get; } = false;
        public bool ContainsWebLink => CheckForType(ClipDescription.MimetypeTextUrilist);
        public bool ContainsApplicationLink { get; } = false;
        public Task<string> GetTextAsync()
        {
            var result = string.Empty;
            if (ContainsText)
            {
                var data = ClipboardManager.PrimaryClip;
                result = data.GetItemAt(0).Text;
            }

            return Task.FromResult(result);
        }

        public Task<Uri> GetWebLinkAsync()
        {
            Uri result = null;
            if (ContainsWebLink)
            {
                var data = ClipboardManager.PrimaryClip;
                var url = data.GetItemAt(0).Uri;
                result = new Uri(url.ToString());
            }

            return Task.FromResult(result);
        }

        public Task<string> GetHtmlAsync()
        {
            var result = string.Empty;
            if (ContainsHtml)
            {
                var data = ClipboardManager.PrimaryClip;
                result = data.GetItemAt(0).HtmlText;
            }

            return Task.FromResult(result);
        }

        public Task<string> GetRtfAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> GetApplicationLinkAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetBitmapAsync()
        {
            throw new NotImplementedException();
        }

        public void SetText(string content)
        {
            var clipData= ClipData.NewPlainText("", content);
            ClipboardManager.PrimaryClip = clipData;
        }

        public void SetWebLink(Uri content)
        {
            var uri = JavaUri.Parse(content.ToString());
            var clipData = ClipData.NewUri(null, "", uri);
            ClipboardManager.PrimaryClip = clipData;
        }

        public void SetApplicationLink(Uri content)
        {
            throw new NotImplementedException();
        }

        public void SetRtf(string content)
        {
            throw new NotImplementedException();
        }

        public void SetHtml(string content)
        {
            var clipData = ClipData.NewHtmlText("", "", content);
            ClipboardManager.PrimaryClip = clipData;
        }

        public void SetBitmap(Stream content)
        {
            throw new NotImplementedException();
        }

        private bool CheckForType(string mimeType)
        {
            var result = false;

            if (ClipboardManager.HasPrimaryClip)
            {
                var description = ClipboardManager.PrimaryClipDescription;
                var data = ClipboardManager.PrimaryClip;
                result = data != null && description != null && description.HasMimeType(mimeType);
            }

            return result;
        }
    }
}