using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvas : MonoBehaviour
{
    public GameObject FindHashtag;
    public GameObject UserSearching;

    public void OnClick()
    {
        if (gameObject.name == "MyAccButton")
        {
            if (PlayerStats.instance.playerSettings.name != "")
            {
                string key = PlayerStats.instance.playerSettings.token;
                PreloadingManager.instance._PreloadFromSelfImages(key);
                //CanvasController.instance.OpenCanvas(UserSearching);
                DownloadManager.instance.CreateLoadingBar();
            }
            else
            {
                GameObject.FindGameObjectWithTag("Login").GetComponent<SampleWebView>().Login();
                //CanvasController.instance.CloseCanvas();
            }
        }
        if (gameObject.name == "HashtagButton")
        {
            Instantiate(FindHashtag);
        }
        if (gameObject.name == "FindUserButton")
        {
            Instantiate(UserSearching);
        }
        if (gameObject.name == "StorageButton")
        {
            
        }
    }
}
