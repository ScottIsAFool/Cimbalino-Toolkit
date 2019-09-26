﻿// ****************************************************************************
// <copyright file="LauncherService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILauncherService"/>.
    /// </summary>
    public class LauncherService : ILauncherService
    {
        /// <summary>
        /// Starts the default app associated with the URI scheme name for the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> to start.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task LaunchUriAsync(Uri uri)
        {
            return Launcher.LaunchUriAsync(uri).AsTask();
        }

        /// <summary>
        /// Starts the default app associated with the URI scheme name for the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="url">The URI to start.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task LaunchUriAsync(string url)
        {
            return LaunchUriAsync(new Uri(url));
        }

        /// <summary>
        /// Starts the default app associated with the specified file.
        /// </summary>
        /// <param name="file">The file to start.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task LaunchFileAsync(string file)
        {
            var storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(file);

            await Launcher.LaunchFileAsync(storageFile);
        }

        /// <summary>
        /// Enumerate the scheme handlers on the device.
        /// </summary>
        /// <param name="uriScheme">The scheme name that you find to find handlers for.</param>
        /// <param name="includeUriForResults">Filter the list of handlers by whether they can be launched for results or not.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<IEnumerable<LauncherServiceAppInfo>> FindUriSchemeHandlersAsync(string uriScheme, bool includeUriForResults = false)
        {
            var appInfos = await Launcher.FindUriSchemeHandlersAsync(uriScheme, includeUriForResults ? LaunchQuerySupportType.UriForResults : LaunchQuerySupportType.Uri);

            return appInfos.ToLauncherServiceAppInfo();
        }

        /// <summary>
        /// Enumerate the file handlers on the device.
        /// </summary>
        /// <param name="extension">The file extension that you want to find handlers for.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<IEnumerable<LauncherServiceAppInfo>> FindFileHandlersAsync(string extension)
        {
            var appInfos = await Launcher.FindFileHandlersAsync(extension);

            return appInfos.ToLauncherServiceAppInfo();
        }
    }
}