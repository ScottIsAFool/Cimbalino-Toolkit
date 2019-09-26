﻿// ****************************************************************************
// <copyright file="ComparableToObjectConverter.cs" company="Pedro Lamas">
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
using Windows.UI.Xaml.Data;

namespace Cimbalino.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> which converts a <see cref="IComparable"/> value to an <see cref="object"/> value.
    /// </summary>
    public class ComparableToObjectConverter : ComparableToValueConverterBase<IComparable, object>
    {
    }
}