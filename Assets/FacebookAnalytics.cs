using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FacebookAnalytics : MonoBehaviour
{
    private void Awake()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            FB.Init(() => {
                FB.ActivateApp();
            });
        }
    }

    public static void LogButtonClickEvent(string buttonName)
    {
        var parameters = new Dictionary<string, object>();
        parameters["ButtonName"] = buttonName;
        FB.LogAppEvent("ButtonClick", null, parameters);
    }

    public static void LogActivityEvent(string eventName)
    {
        var parameters = new Dictionary<string, object>();
        parameters["EventName"] = eventName;
        FB.LogAppEvent("Activity", null, parameters);
    }
}
