using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

using GEM.Core;

namespace GEM.Game.Popups
{
    /// <summary>
    /// This class contains the logic associated to the alert popup.
    /// </summary>
    public class AlertPopup : Popup
    {
        [SerializeField]
        private Text titleText;

        [SerializeField]
        private Text bodyText;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(titleText);
            Assert.IsNotNull(bodyText);
        }

        /// <summary>
        /// Called when the popup button is pressed.
        /// </summary>
        public void OnButtonPressed()
        {
            Close();
        }

        /// <summary>
        /// Called when the close button is pressed.
        /// </summary>
        public void OnCloseButtonPressed()
        {
            Close();
        }

        /// <summary>
        /// Sets the title text.
        /// </summary>
        /// <param name="text">The title text.</param>
        public void SetTitle(string text)
        {
            titleText.text = text;
        }

        /// <summary>
        /// Sets the body text.
        /// </summary>
        /// <param name="text">The body text.</param>
        public void SetText(string text)
        {
            bodyText.text = text;
        }
    }
}