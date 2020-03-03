using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

using GEM.Game.Common;
using GEM.Game.Scenes;
using GEM.Game.Popups;

namespace GEM.Game.UI
{
    /// <summary>
    /// This class is used to manage the bar to buy coins that is located on the level scene.
    /// </summary>
    public class BuyCoinsBar : MonoBehaviour
    {
        [SerializeField]
        private LevelScene levelScene;

        [SerializeField]
        private Text numCoinsText;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            Assert.IsNotNull(levelScene);
            Assert.IsNotNull(numCoinsText);
        }

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        private void Start()
        {
            var numCoins = PlayerPrefs.GetInt("num_coins");
            numCoinsText.text = numCoins.ToString("n0");
            PuzzleMatchManager.instance.coinsSystem.Subscribe(OnCoinsChanged);
        }

        /// <summary>
        /// Unity's OnDestroy method.
        /// </summary>
        private void OnDestroy()
        {
            PuzzleMatchManager.instance.coinsSystem.Unsubscribe(OnCoinsChanged);
        }

        /// <summary>
        /// Called when the buy button is pressed.
        /// </summary>
        public void OnBuyButtonPressed()
        {
            levelScene.OpenPopup<BuyCoinsPopup>("Popups/BuyCoinsPopup");
        }

        /// <summary>
        /// Called when the number of coins changes.
        /// </summary>
        /// <param name="numCoins">The current number of coins.</param>
        private void OnCoinsChanged(int numCoins)
        {
            numCoinsText.text = numCoins.ToString("n0");
        }
    }
}