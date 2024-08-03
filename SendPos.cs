using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPos : MonoBehaviour
{
    // Start is called before the first frame update
   async void Start()
    {
        var webViewPrefab = GameObject.Find("WebViewPrefab").GetComponent<WebViewPrefab>();
        await webViewPrefab.WaitUntilInitialized();
        webViewPrefab.WebView.MessageEmitted += (sender, eventArgs) => {
            Debug.Log("JSON received: " + eventArgs.Value);
        };
    } 
}
