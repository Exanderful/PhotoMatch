using UnityEngine;
using UnityEngine.SceneManagement;
namespace GEM.Core
{
    // This class is responsible for loading the next scene in a transition.
    public class SceneTransition : MonoBehaviour
    {
        public string scene = "<Insert scene name>";
        public float duration = 1.0f;
        public Color color = Color.black;

        /// <summary>
        /// Performs the transition to the next scene.
        /// </summary>
        public void PerformTransition()
        {
            if (SceneManager.GetActiveScene().name == "HomeScene")
            {
                if (PlayerStats.instance.playerSettings.name != "")
                {
                    string key = PlayerStats.instance.playerSettings.token;
                    PreloadingManager.instance._PreloadFromSelfImages(key);
                    //CanvasController.instance.OpenCanvas(UserSearching);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Login").GetComponent<SampleWebView>().Login();
                    //CanvasControllerClose();
                }
            }
            else
            {
                Transition.LoadLevel(scene, duration, color);
            }
        }
    }
}