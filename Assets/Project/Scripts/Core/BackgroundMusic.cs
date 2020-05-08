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

        public AudioClip[] musicClips;

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

        private void OnLevelWasLoaded(int level)
        {
            if(level == 2)
            {
                GetComponent<AudioSource>().clip = musicClips[1];
                audioSource.Play();
            }
            else if(level == 1)
            {
                if (GetComponent<AudioSource>().clip == musicClips[1])
                {
                    GetComponent<AudioSource>().clip = musicClips[0];
                    audioSource.Play();
                }
            }
        }
    }
}