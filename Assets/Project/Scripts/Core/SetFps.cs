using UnityEngine;

namespace GEM.Core
{
    /// <summary>
    /// Utility class to set the desired FPS of the game.
    /// </summary>
    public class SetFps : MonoBehaviour
    {
        public int fps = 60;

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        private void Start()
        {
            Application.targetFrameRate = fps;
        }
    }
}