using UnityEngine;

using FullSerializer;

using GEM.Core;

namespace GEM.Game.Common
{
    /// <summary>
    /// This class is a utility class that allows other classes to easily access the game configuration and
    /// the lives and coins systems.
    /// </summary>
    public class PuzzleMatchManager : MonoBehaviour
    {
        public static PuzzleMatchManager instance;

        public GameConfiguration gameConfig;

        public LivesSystem livesSystem;
        public CoinsSystem coinsSystem;

        public int lastSelectedLevel;
        public bool unlockedNextLevel;

        #if PHOTO_MATCH_ENABLE_IAP
        public IapManager iapManager;
        #endif

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);

            livesSystem = GetComponent<LivesSystem>();
            coinsSystem = GetComponent<CoinsSystem>();

            var serializer = new fsSerializer();
            gameConfig = FileUtils.LoadJsonFile<GameConfiguration>(serializer, "game_configuration");
            if (!PlayerPrefs.HasKey("num_lives"))
            {
                PlayerPrefs.SetInt("num_lives", gameConfig.maxLives);
            }
            if (!PlayerPrefs.HasKey("num_coins"))
            {
                PlayerPrefs.SetInt("num_coins", gameConfig.initialCoins);
            }
            if (!PlayerPrefs.HasKey("sound_enabled"))
            {
                PlayerPrefs.SetInt("sound_enabled", 1);
            }
            if (!PlayerPrefs.HasKey("music_enabled"))
            {
                PlayerPrefs.SetInt("music_enabled", 1);
            }

            #if PHOTO_MATCH_ENABLE_IAP
            iapManager = new IapManager();
            #endif
        }
    }
}