using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareAcc : MonoBehaviour
{
    public GameObject ShareCanvas;

    public GameObject Sign_in;
    public GameObject Share_acc;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void ShareAccount()
    {
        if(PlayerStats.instance.playerSettings.name != "")
        {
            StartCoroutine(Share(true));
        }
        else
        {
            StartCoroutine(Share(false));
        }
    }

    IEnumerator Share(bool authorized)
    {
        //share logined account

        ShareCanvas.SetActive(true);

        string t = "";

        if (authorized)
        {
            t = "Lets play with my account!";
            GameObject.Find("Share_account_name").GetComponent<Text>().text = "@" + PlayerStats.instance.playerSettings.name;
        }
        else
        {
            GameObject.Find("Share_account_name").GetComponent<Text>().text = "";
            t = "Lets play Find&Like!";
        }


        GameObject.Find("Share_header").GetComponent<Text>().text = t;

        string path = Application.persistentDataPath + "/share_screen.png";

        yield return new WaitForEndOfFrame();

        //Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();
        //DataSave.SaveImage(tex, "share_screen", Application.persistentDataPath);

        var height = 600;
        var width = 600;

        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        Rect _r = new Rect(0, 0, width, height);

        tex.ReadPixels(_r, 0, 0);
        tex.Apply();

        DataSave.SaveImage(tex, "share_screen", Application.persistentDataPath, true);

        Debug.Log(path + " - screenshot saved");

        //yield return new WaitForSeconds(0.05f);

        ShareCanvas.SetActive(false);


        if (authorized)
        {
            AnalyticsEventsController.LogEvent("Share", "share_type", "authorized");
            new NativeShare().SetTitle("lets play Find&Like!").SetText("Find my account and play! @" + PlayerStats.instance.playerSettings.name + "\n https://play.google.com/store/apps/details?id=com.GeM.InstaJong \n\n\n #Find&Like").AddFile(path).Share();
        }
        else
        {
            AnalyticsEventsController.LogEvent("Share", "share_type", "Not_authorized");
            new NativeShare().SetTitle("lets play Find&Like!").SetText("Hey, lets go play Find&Like! \n https://play.google.com/store/apps/details?id=com.GeM.InstaJong \n\n\n #Find&Like").AddFile(path).Share();
        }
    }
}