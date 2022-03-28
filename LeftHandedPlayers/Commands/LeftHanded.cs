// -----------------------------------------------------------------------
// <copyright file="LeftHanded.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LeftHandedPlayers.Commands
{
    using System;
    using CommandSystem;
    using Exiled.API.Features;
    using UnityEngine;

    /// <inheritdoc />
    public class LeftHanded : ICommand
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftHanded"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public LeftHanded(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc />
        public string Command => "lefthanded";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "left", "lefthand" };

        /// <inheritdoc />
        public string Description => "Makes you left handed";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(Player.Get(sender) is Player player))
            {
                response = "This command can only be used in game.";
                return false;
            }

            if (player.Scale.x > 0f)
            {
                player.Scale = Vector3.Scale(player.Scale, LeftHandedCollection.ScaleVector);
                plugin.LeftHandedCollection.Add(player);
                response = "You are now left handed";
                return true;
            }

            player.Scale = Vector3.Scale(player.Scale, LeftHandedCollection.ScaleVector);
            plugin.LeftHandedCollection.Remove(player);
            response = "You are no longer left handed";
            return true;
        }
    }
}
