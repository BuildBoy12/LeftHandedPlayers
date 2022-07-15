// -----------------------------------------------------------------------
// <copyright file="Translation.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LeftHandedPlayers
{
    using Exiled.API.Interfaces;
    using LeftHandedPlayers.Commands;

    /// <inheritdoc />
    public class Translation : ITranslation
    {
        /// <summary>
        /// Gets or sets an instance of the <see cref="LeftHanded"/> command.
        /// </summary>
        public LeftHanded Command { get; set; } = new();
    }
}