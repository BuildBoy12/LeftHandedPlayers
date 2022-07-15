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
    using LeftHandedPlayers.EventHandlers;
    using RemoteAdmin;
    using PlayerHandlers = Exiled.Events.Handlers.Player;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config, Translation>
    {
        private ServerEvents serverEvents;
        private PlayerEvents playerEvents;

        /// <summary>
        /// Gets an instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc />
        public override string Author => "Build";

        /// <inheritdoc />
        public override string Name => "LeftHandedPlayers";

        /// <inheritdoc />
        public override string Prefix => "LeftHandedPlayers";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new(5, 2, 2);

        /// <inheritdoc />
        public override Version Version { get; } = new(2, 0, 0);

        /// <summary>
        /// Gets the collection of left handed players.
        /// </summary>
        public LeftHandedCollection LeftHandedCollection { get; private set; }

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Instance = this;
            LeftHandedCollection = new LeftHandedCollection(this);
            serverEvents = new ServerEvents(this);
            playerEvents = new PlayerEvents(this);
            ServerHandlers.RoundEnded += serverEvents.OnRoundEnded;
            ServerHandlers.WaitingForPlayers += serverEvents.OnWaitingForPlayers;
            PlayerHandlers.Verified += playerEvents.OnVerified;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            ServerHandlers.RoundEnded -= serverEvents.OnRoundEnded;
            ServerHandlers.WaitingForPlayers -= serverEvents.OnWaitingForPlayers;
            PlayerHandlers.Verified -= playerEvents.OnVerified;
            serverEvents = null;
            playerEvents = null;
            LeftHandedCollection = null;
            Instance = null;
            base.OnDisabled();
        }

        /// <inheritdoc />
        public override void OnRegisteringCommands()
        {
            QueryProcessor.DotCommandHandler.RegisterCommand(Translation.Command);
        }

        /// <inheritdoc />
        public override void OnUnregisteringCommands()
        {
            QueryProcessor.DotCommandHandler.UnregisterCommand(Translation.Command);
        }
    }
}
