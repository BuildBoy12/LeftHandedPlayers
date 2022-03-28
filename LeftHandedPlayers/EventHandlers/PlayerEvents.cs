// -----------------------------------------------------------------------
// <copyright file="PlayerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LeftHandedPlayers.EventHandlers
{
    using Exiled.API.Features.Items;
    using Exiled.Events.EventArgs;
    using InventorySystem.Items.Firearms.Attachments;
    using UnityEngine;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers.Player"/>.
    /// </summary>
    public class PlayerEvents
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public PlayerEvents(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnChangingItem(ChangingItemEventArgs)"/>
        public void OnChangingItem(ChangingItemEventArgs ev)
        {
            if (ev.NewItem.Type != ItemType.GunE11SR)
                return;

            if (ev.NewItem.Scale[0] < 0)
            {
                if (plugin.LeftHandedCollection.Contains(ev.Player))
                {
                    ev.NewItem.Scale.Scale(new Vector3(-1, 1, 1));
                }

                return;
            }

            if (!plugin.LeftHandedCollection.Contains(ev.Player))
                return;

            Firearm firearm = (Firearm)ev.NewItem;

            foreach (FirearmAttachment st in firearm.Attachments)
            {
                if ((st.Name == AttachmentNameTranslation.NightVisionSight || st.Name == AttachmentNameTranslation.ScopeSight) && st.IsEnabled)
                {
                    firearm.Scale.Scale(new Vector3(-1, 1, 1));
                    return;
                }
            }
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnVerified(VerifiedEventArgs)"/>
        public void OnVerified(VerifiedEventArgs ev)
        {
            if (plugin.LeftHandedCollection.Contains(ev.Player))
                ev.Player.Scale = new Vector3(-1, 1, 1);
        }
    }
}
