﻿// ****************************************************************************
// <copyright file="StatusBarService.cs" company="Pedro Lamas">
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

#if WINDOWS_APP
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
#else
using System;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStatusBarService"/>.
    /// </summary>
    public class StatusBarService : IStatusBarService
    {
        /// <summary>
        /// Shows the status bar with the specified text.
        /// </summary>
        /// <param name="text">The text to display in the status bar.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text)
        {
            return ShowAsync(text, 0, false);
        }

        /// <summary>
        /// Shows the status bar with the specified text and an optional indeterminate progress indicator.
        /// </summary>
        /// <param name="text">The text to display in the status bar.</param>
        /// <param name="isIndeterminate">true if the progress indicator is indeterminate; otherwise, false.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text, bool isIndeterminate)
        {
            return ShowAsync(text, 0, isIndeterminate);
        }

        /// <summary>
        /// Shows the status bar with the specified text and progress value.
        /// </summary>
        /// <param name="text">The text to display in the status bar.</param>
        /// <param name="value">The progress indicator value.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text, double value)
        {
            return ShowAsync(text, value, false);
        }

        /// <summary>
        /// Hides the status bar.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
#if WINDOWS_APP
        public virtual Task HideAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task>();
        }

        private Task ShowAsync(string text, double value, bool isIndeterminate)
        {
            return ExceptionHelper.ThrowNotSupported<Task>();
        }
#else
        public virtual async Task HideAsync()
        {
#if WINDOWS_UWP
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                return;
            }
#endif

            var statusBar = StatusBar.GetForCurrentView();

            if (statusBar != null)
            {
                await statusBar.ProgressIndicator.HideAsync();
            }
        }

        private async Task ShowAsync(string text, double value, bool isIndeterminate)
        {
#if WINDOWS_UWP
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                return;
            }
#endif

            var statusBar = StatusBar.GetForCurrentView();

            if (statusBar != null)
            {
                statusBar.ProgressIndicator.Text = text;
                statusBar.ProgressIndicator.ProgressValue = isIndeterminate ? (double?)null : value;

                await statusBar.ProgressIndicator.ShowAsync();
            }
        }
#endif
    }
}