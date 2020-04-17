﻿using UnityEngine;

namespace Status
{
    /// <summary>
    /// A StatusEffect is a temporary or permanent toggleable (de)buff that may either do something each tick or change StatAttributes while active.
    /// Can be applied to StatusEffectHolders.
    /// </summary>
    public class StatusEffect : ScriptableObject
    {

        /// <summary>
        /// Event Handler for adding to a StatusEffectHolder.
        /// </summary>
        public virtual void OnAdd(StatusEffectInstance instance)
        {
        }

        /// <summary>
        /// Event Handler for removing from a StatusEffectHolder.
        /// </summary>
        public virtual void OnRemove(StatusEffectInstance instance)
        {
        }

        /// <summary>
        /// Event Handler for becoming active.
        /// </summary>
        public virtual void OnActive(StatusEffectInstance instance)
        {
        }

        /// <summary>
        /// Event Handler for becoming inactive.
        /// </summary>
        public virtual void OnInactive(StatusEffectInstance instance)
        {
        }

        /// <summary>
        /// Update the StatusEffectInstance's Active status.
        /// </summary>
        public virtual void CheckActive(StatusEffectInstance instance)
        {
        }

        /// <summary>
        /// Event Handler for update logic. Gets called every FixedUpdate.
        /// </summary>
        public virtual void Tick(StatusEffectInstance instance)
        {
        }
    }
}