// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LeftHandedPlayers
{
    using System;
    using Exiled.API.Features;
    using LeftHandedPlayers.Commands;
    using LeftHandedPlayers.EventHandlers;
    using RemoteAdmin;
    using PlayerHandlers = Exiled.Events.Handlers.Player;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private ServerEvents serverEvents;
        private PlayerEvents playerEvents;

        private LeftHanded leftHandedCommand;

        /// <inheritdoc />
        public override string Author => "Build";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <summary>
        /// Gets the collection of left handed players.
        /// </summary>
        public LeftHandedCollection LeftHandedCollection { get; private set; }

        /// <inheritdoc />
        public override void OnEnabled()
        {
            LeftHandedCollection = new LeftHandedCollection(this);
            serverEvents = new ServerEvents(this);
            playerEvents = new PlayerEvents(this);
            ServerHandlers.RoundEnded += serverEvents.OnRoundEnded;
            ServerHandlers.WaitingForPlayers += serverEvents.OnWaitingForPlayers;
            PlayerHandlers.Verified += playerEvents.OnVerified;
            PlayerHandlers.ChangingItem += playerEvents.OnChangingItem;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            ServerHandlers.RoundEnded -= serverEvents.OnRoundEnded;
            ServerHandlers.WaitingForPlayers -= serverEvents.OnWaitingForPlayers;
            PlayerHandlers.Verified -= playerEvents.OnVerified;
            PlayerHandlers.ChangingItem -= playerEvents.OnChangingItem;
            serverEvents = null;
            playerEvents = null;
            LeftHandedCollection = null;
            base.OnDisabled();
        }

        /// <inheritdoc />
        public override void OnRegisteringCommands()
        {
            leftHandedCommand = new LeftHanded(this);
            QueryProcessor.DotCommandHandler.RegisterCommand(leftHandedCommand);
        }

        /// <inheritdoc />
        public override void OnUnregisteringCommands()
        {
            QueryProcessor.DotCommandHandler.UnregisterCommand(leftHandedCommand);
            leftHandedCommand = null;
        }
    }
}
