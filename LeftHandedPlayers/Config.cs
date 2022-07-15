// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LeftHandedPlayers
{
    using System.ComponentModel;
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
        [Description("The folder the file should be stored in.")]
        public string FolderPath { get; set; } = Path.Combine(Paths.Configs, "LeftHandedPlayers");

        /// <summary>
        /// Gets or sets the name of the file to read and write from.
        /// </summary>
        [Description("The name of the file to read and write from.")]
        public string FileName { get; set; } = "LeftHandedData.yml";
    }
}
