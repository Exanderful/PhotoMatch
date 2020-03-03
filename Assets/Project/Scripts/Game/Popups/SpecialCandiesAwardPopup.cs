﻿using System.Collections;

using UnityEngine;

using GEM.Core;

namespace GEM.Game.Popups
{
    /// <summary>
    /// This class contains the logic associated to the popup for awarding special candies at the end of a game.
    /// </summary>
    public class SpecialCandiesAwardPopup : Popup
    {
        /// <summary>
        /// Unity's Start method.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            StartCoroutine(AutoClose());
        }

        /// <summary>
        /// This coroutine automatically closes the popup after its animation has finished.
        /// </summary>
        /// <returns>The coroutine.</returns>
        private IEnumerator AutoClose()
        {
            yield return new WaitForSeconds(1.5f);
            Close();
        }
    }
}