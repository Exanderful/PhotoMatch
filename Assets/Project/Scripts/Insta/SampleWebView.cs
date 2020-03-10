using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;

public class SampleWebView : MonoBehaviour
{
    public string Url;
    WebViewObject webViewObject;

    public GameObject BG;
    public GameObject LoginButton;

    public string DebugKey;

    public Text loginText;
    public GameObject[] DeleteLoginButton;

    public void Login()
    {

#if UNITY_EDITOR
        if (PlayerStats.instance.playerSettings.name != "")
        {
            StartCoroutine(ConvertKeyToId(DebugKey));
            Debug.Log("Started auth");
        }
        else
        {
            Debug.Log("Login clear cookies");
            ClearCookies();
            StartCoroutine(ConvertKeyToId(DebugKey));
        }
#elif UNITY_ANDROID || UNITY_IOS
        Debug.Log("Login()");

        if (PlayerStats.instance.playerSettings.name == "")
        {
            StartCoroutine(loggingIn());

            Debug.Log("Auth in account");
        }
        //else
        //{
        //    ClearCookies();
        //}
#endif
    }

    #region handler
    private void Start()
    {
        PlayerStats.AccountKeyHandler += DisplayLogin;

        DisplayLogin();
    }
    private void OnDestroy() 
    {
        PlayerStats.AccountKeyHandler -= DisplayLogin;
    }
    #endregion

    void DisplayLogin()
    {
        if(PlayerStats.instance.playerSettings.name != "")
        {
            loginText.text = "@" + PlayerStats.instance.playerSettings.name;
            foreach(GameObject ob in DeleteLoginButton)
            ob.SetActive(true);
            LeanTween.scale(LoginButton, new Vector3(1f, 1f, 1f), 0.4f).setEaseInOutSine();
        }
        else
        {
            //loginText.text = "sign in";
            foreach (GameObject ob in DeleteLoginButton)
            ob.SetActive(false);
            LeanTween.scale(LoginButton, new Vector3(0f, 0f, 0f), 0.4f).setEaseInSine();
        }
    }

    public string GetAccessToken(string myUrl)
    {
        string url1 = myUrl;
        string accessToken = "#access_token";

        if (url1.Contains(accessToken))
        {
            var data = url1.Substring(url1.LastIndexOf("=") + 1);
            Debug.Log("Successfuly authorized. token: " + data);
            AnalyticsEventsController.LogEvent("Authorized");
            //save token here
            StartCoroutine(ConvertKeyToId(data));

            return data;
        }
        return null;
    }

    public IEnumerator ConvertKeyToId(string key)
    {
        Debug.Log("Started converting");
        UnityWebRequest IdRequest = UnityWebRequest.Get("https://api.instagram.com/v1/users/self?access_token=" + key);
        yield return IdRequest.SendWebRequest();
        //get account id
        var _accId = JsonConvert.DeserializeObject<Assets.Accounts.Convert.RootObject>(IdRequest.downloadHandler.text);

        Debug.Log("Converting..");

        PlayerStats.instance.playerSettings = (_accId.data.username, key);

#if !UNITY_EDITOR
        Destroy(webViewObject.gameObject);
#endif

        BG.SetActive(false);

        DisplayLogin();
    }

    public void ClearCookies()
    {
#if UNITY_EDITOR

#elif UNITY_ANDROID || UNITY_IOS

        Debug.Log("Clear Cookies()");
        BG.SetActive(true);
        if (webViewObject == null)
        {
            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
            webViewObject.Init(enableWKWebView: true);
        }
        webViewObject.ClearCookies();

        Destroy(webViewObject.gameObject);
        BG.SetActive(false);
#endif

        PlayerStats.instance.playerSettings = ("", "");
    }

    IEnumerator loggingIn()
    {

        //7050105971.9f7d92e.d92bd5e3730d44d8bf8c7aca48e6ed94 - старый
        //5739047997.9f7d92e.63ea9727c9cd46439dba63b9b8f0caf7 - мой
        Url = "https://www.instagram.com/oauth/authorize/?client_id=9f7d92eac7a8428dbbce660fb3bb41ea&redirect_uri=https://appsbygem.com/authorization/&response_type=token";

        Debug.Log("LoggingIn");

        BG.SetActive(true);

        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init(
            cb: (msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
            },
            err: (msg) =>
            {
                Debug.Log(string.Format("CallOnError[{0}]", msg));
            },
            started: (msg) =>
            {
                Debug.Log(string.Format("CallOnStarted[{0}]", msg));
            },
            ld: (msg) =>
            {
                Debug.Log(string.Format("CallOnLoaded[{0}]", msg));

                GetAccessToken(msg);


#if UNITY_EDITOR_OSX || !UNITY_ANDROID
                // NOTE: depending on the situation, you might prefer
                // the 'iframe' approach.
                // cf. https://github.com/gree/unity-webview/issues/189
#if true
                webViewObject.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        window.location = 'unity:' + msg;
                      }
                    }
                  }
                ");
#else
                webViewObject.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        var iframe = document.createElement('IFRAME');
                        iframe.setAttribute('src', 'unity:' + msg);
                        document.documentElement.appendChild(iframe);
                        iframe.parentNode.removeChild(iframe);
                        iframe = null;
                      }
                    }
                  }
                ");
#endif
#endif
                webViewObject.EvaluateJS(@"Unity.call('ua=' + navigator.userAgent)");
            },
            //ua: "custom user agent string",
            enableWKWebView: true);
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        webViewObject.bitmapRefreshCycle = 1;
#endif
        webViewObject.SetMargins(Screen.width / 4, 100, Screen.width / 4, Screen.height / 4);
        webViewObject.SetVisibility(true);

#if !UNITY_WEBPLAYER
        if (Url.StartsWith("http")) {
            webViewObject.LoadURL(Url.Replace(" ", "%20"));
        } else {
            var exts = new string[]{
                ".jpg",
                ".js",
                ".html"  // should be last
            };
            foreach (var ext in exts) {
                var url = Url.Replace(".html", ext);
                var src = System.IO.Path.Combine(Application.streamingAssetsPath, url);
                var dst = System.IO.Path.Combine(Application.persistentDataPath, url);
                byte[] result = null;
                if (src.Contains("://")) {  // for Android
                    var www = new UnityWebRequest(src);
                    yield return www.SendWebRequest();
                    result = www.downloadHandler.data;

                    //var www = new WWW(src);
                    //yield return www;
                    //result = www.bytes;
                } else {
                    result = System.IO.File.ReadAllBytes(src);
                }
                System.IO.File.WriteAllBytes(dst, result);
                if (ext == ".html") {
                    webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
                    break;
                }
            }
        }
#else
        if (Url.StartsWith("http")) {
            webViewObject.LoadURL(Url.Replace(" ", "%20"));
        } else {
            webViewObject.LoadURL("StreamingAssets/" + Url.Replace(" ", "%20"));
        }
        webViewObject.EvaluateJS(
            "parent.$(function() {" +
            "   window.Unity = {" +
            "       call:function(msg) {" +
            "           parent.unityWebView.sendMessage('WebViewObject', msg)" +
            "       }" +
            "   };" +
            "});");
#endif
        yield break;
    }
}
