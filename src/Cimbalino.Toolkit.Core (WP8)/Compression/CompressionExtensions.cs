﻿// ****************************************************************************
// <copyright file="CompressionExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Core</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using SystemCompressionLevel = System.IO.Compression.CompressionLevel;

namespace Cimbalino.Toolkit.Compression
{
    internal static class CompressionExtensions
    {
        public static SystemCompressionLevel ToCompressionLevel(this CompressionLevel compressionLevel)
        {
            switch (compressionLevel)
            {
                case CompressionLevel.Optimal:
                    return SystemCompressionLevel.Optimal;

                case CompressionLevel.Fastest:
                    return SystemCompressionLevel.Fastest;

                case CompressionLevel.NoCompression:
                    return SystemCompressionLevel.NoCompression;

                default:
                    throw new ArgumentOutOfRangeException(nameof(compressionLevel), compressionLevel, null);
            }
        }
    }
}