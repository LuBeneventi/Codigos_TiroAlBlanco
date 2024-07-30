using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public GameObject hitMarker;

    
    void Start()
    {
        
        if (hitMarker == null)
        {
            Debug.LogError("HitMarker GameObject is not assigned.");
        }
    }

   
    void Update()
    {
        

    }

    void OnMessage(string message)
    {
        
        var data = JsonUtility.FromJson<MessageData>(message);

        
        if (data.type == "cursor")
        {
            
            UpdateHitMarkerPosition(data.x, data.y);
        }
    }

    void UpdateHitMarkerPosition(float x, float y)
    {
       
        Vector3 screenPosition = new Vector3(x, y, Camera.main.nearClipPlane);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        
        hitMarker.transform.position = worldPosition;
    }
}


[System.Serializable]
public class MessageData
{
    public string type;
    public float x;
    public float y;
}




