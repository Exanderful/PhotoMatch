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
            FacebookAnalytics.LogButtonClickEvent("MyAccButton");
        }
        if (gameObject.name == "HashtagButton")
        {
            Instantiate(FindHashtag);
            FacebookAnalytics.LogButtonClickEvent("HashtagButton");
        }
        if (gameObject.name == "FindUserButton")
        {
            Instantiate(UserSearching);
            FacebookAnalytics.LogButtonClickEvent("FindUserButton");
        }
        if (gameObject.name == "StorageButton")
        {
            FacebookAnalytics.LogButtonClickEvent("StorageButton");
        }
    }
}
