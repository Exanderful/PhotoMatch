using UnityEngine;

namespace GEM.Core
{
    /// <summary>
    /// This class manages the background music of the game.
    /// </summary>
    public class BackgroundMusic : MonoBehaviour
    {
        private static BackgroundMusic instance;

        private AudioSource audioSource;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        private void Start()
        {
            var music = PlayerPrefs.GetInt("music_enabled");
            audioSource.mute = music == 0;
            audioSource.Play();
        }
    }
}