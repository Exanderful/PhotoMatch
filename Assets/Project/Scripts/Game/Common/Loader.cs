using UnityEngine;

namespace GEM.Game.Common
{
    /// <summary>
    /// Utility class to initialize the game manager.
    /// </summary>
    public class Loader : MonoBehaviour
    {
        public PuzzleMatchManager gameManager;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            if (PuzzleMatchManager.instance == null)
            {
                Instantiate(gameManager);
            }
        }
    }
}