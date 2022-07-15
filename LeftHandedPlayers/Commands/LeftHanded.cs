// -----------------------------------------------------------------------
// <copyright file="LeftHanded.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LeftHandedPlayers.Commands
{
    using System;
    using System.ComponentModel;
    using CommandSystem;
    using Exiled.API.Features;
    using UnityEngine;

    /// <inheritdoc />
    public class LeftHanded : ICommand
    {
        /// <inheritdoc />
        public string Command { get; set; } = "lefthanded";

        /// <inheritdoc />
        public string[] Aliases { get; set; } = { "left", "lefthand" };

        /// <inheritdoc />
        public string Description { get; set; } = "Makes you left handed";

        /// <summary>
        /// Gets or sets the response to provide when the player becomes left handed.
        /// </summary>
        [Description("The response to provide when the player becomes left handed.")]
        public string LeftHandedResponse { get; set; } = "You are now left handed";

        /// <summary>
        /// Gets or sets the response to provide when the player becomes right handed.
        /// </summary>
        [Description("The response to provide when the player becomes right handed.")]
        public string RightHandedResponse { get; set; } = "You are now right handed";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Player.Get(sender) is not Player player)
            {
                response = "This command can only be used in game.";
                return false;
            }

            if (player.Scale.x > 0f)
            {
                player.Scale = Vector3.Scale(player.Scale, LeftHandedCollection.ScaleVector);
                Plugin.Instance.LeftHandedCollection.Add(player);
                response = LeftHandedResponse;
                return true;
            }

            player.Scale = Vector3.Scale(player.Scale, LeftHandedCollection.ScaleVector);
            Plugin.Instance.LeftHandedCollection.Remove(player);
            response = RightHandedResponse;
            return true;
        }
    }
}
