﻿using System;
using System.Runtime.InteropServices;

namespace Zenseless.Base
{
    /// <summary>
    /// Defines an attribute that is used by Zenseless to detect if SOLUTION is defined
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ComVisible(true)]
    public class SolutionAttribute : Attribute
    {
    }
}