using UnityEngine;
using UnityEngine.Assertions;

using GEM.Core;

namespace GEM.Game.Popups
{
    /// <summary>
    /// This class contains the logic associated to the in-game settings popup.
    /// </summary>
    public class InGameSettingsPopup : Popup
    {
        [SerializeField]
        private AnimatedButton soundButton;

        [SerializeField]
        private AnimatedButton musicButton;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(soundButton);
            Assert.IsNotNull(musicButton);
        }

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            UpdateButtons();

            var settingsButton = GameObject.Find("SettingsButton");
            if (settingsButton != null)
            {
                settingsButton.transform.SetParent(GameObject.Find("Canvas").transform, false);
                settingsButton.GetComponent<RectTransform>().SetAsLastSibling();
            }
        }

        /// <summary>
        /// Called when the exit button is pressed.
        /// </summary>
        public void OnExitButtonPressed()
        {
            var settingsButton = GameObject.Find("SettingsButton");
            if (settingsButton != null)
            {
                settingsButton.transform.SetParent(GameObject.Find("BackgroundCanvas").transform);
                settingsButton.GetComponent<RectTransform>().SetAsLastSibling();
            }

            parentScene.CloseCurrentPopup();
            parentScene.OpenPopup<ExitGamePopup>("Popups/ExitGamePopup");
            FacebookAnalytics.LogButtonClickEvent("GameSceneExitButton");
        }

        /// <summary>
        /// Called when the sound button is pressed.
        /// </summary>
        public void OnSoundButtonPressed()
        {
            SoundManager.instance.ToggleSound();
            FacebookAnalytics.LogButtonClickEvent("GameSceneSoundButton");
        }

        /// <summary>
        /// Called when the music button is pressed.
        /// </summary>
        public void OnMusicButtonPressed()
        {
            SoundManager.instance.ToggleMusic();
            FacebookAnalytics.LogButtonClickEvent("GameSceneMusicButton");
        }

        /// <summary>
        /// Updates the state of the sound and music buttons based on the appropriate PlayerPrefs values.
        /// </summary>
        public void UpdateButtons()
        {
            var sound = PlayerPrefs.GetInt("sound_enabled");
            soundButton.GetComponent<SpriteSwapper>().SetEnabled(sound == 1);
            var music = PlayerPrefs.GetInt("music_enabled");
            musicButton.GetComponent<SpriteSwapper>().SetEnabled(music == 1);
        }
    }
}