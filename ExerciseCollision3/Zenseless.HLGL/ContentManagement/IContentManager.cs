﻿using System;
using System.Collections.Generic;

namespace Zenseless.HLGL
{
    /// <summary>
    /// Interface for a content manager
    /// </summary>
    /// <seealso cref="IContentLoader" />
    public interface IContentManager : IContentLoader
    {
        /// <summary>
        /// Registers an importer.
        /// </summary>
        /// <typeparam name="TYPE">The return type of the importer.</typeparam>
        /// <param name="importer">The importer instance.</param>
        /// <exception cref="ArgumentNullException"></exception>
        void RegisterImporter<TYPE>(Func<IEnumerable<NamedStream>, TYPE> importer) where TYPE : class;
    }
}