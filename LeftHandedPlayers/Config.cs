// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LeftHandedPlayers
{
    using System.IO;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the folder the file should be stored in.
        /// </summary>
        public string FolderPath { get; set; } = Path.Combine(Paths.Configs, "LeftHandedPlayers");

        /// <summary>
        /// Gets or sets the name of the file to read and write from.
        /// </summary>
        public string FileName { get; set; } = "LeftHandedData.yml";
    }
}
