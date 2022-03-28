// -----------------------------------------------------------------------
// <copyright file="LeftHandedCollection.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LeftHandedPlayers
{
    using System.Collections.Generic;
    using System.IO;
    using Exiled.API.Features;
    using Exiled.Loader;

    /// <summary>
    /// Handles an underlying <see cref="HashSet{T}"/> of user ids that should be considered to be left handed.
    /// </summary>
    public class LeftHandedCollection
    {
        private readonly Plugin plugin;
        private HashSet<string> leftHandedPlayers;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftHandedCollection"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public LeftHandedCollection(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Adds a player to the collection.
        /// </summary>
        /// <param name="player">The player to add.</param>
        public void Add(Player player) => leftHandedPlayers?.Add(player.UserId);

        /// <summary>
        /// Removes a player from the collection.
        /// </summary>
        /// <param name="player">The player to remove.</param>
        public void Remove(Player player) => leftHandedPlayers?.Remove(player.UserId);

        /// <summary>
        /// Checks if a player is in the collection.
        /// </summary>
        /// <param name="player">The player to check for.</param>
        /// <returns>A value indicating whether the player is in the collection.</returns>
        public bool Contains(Player player) => leftHandedPlayers?.Contains(player.UserId) ?? false;

        /// <summary>
        /// Saves the file at the configured path.
        /// </summary>
        public void Save()
        {
            if (!Directory.Exists(plugin.Config.FolderPath))
                Directory.CreateDirectory(plugin.Config.FolderPath);

            File.WriteAllText(Path.Combine(plugin.Config.FolderPath, plugin.Config.FileName), Loader.Serializer.Serialize(leftHandedPlayers ?? new HashSet<string>()));
        }

        /// <summary>
        /// Loads the file from the configured path.
        /// </summary>
        public void Load()
        {
            string filePath = Path.Combine(plugin.Config.FolderPath, plugin.Config.FileName);
            leftHandedPlayers = !File.Exists(filePath)
                ? new HashSet<string>()
                : Loader.Deserializer.Deserialize<HashSet<string>>(File.ReadAllText(filePath));

            Save();
        }
    }
}