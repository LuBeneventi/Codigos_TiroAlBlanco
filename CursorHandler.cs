using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    void Start()
    {
        
    }

    
   public void OnMessageReceived(string message)
    {
        
        MessageData data = JsonUtility.FromJson<MessageData>(message);

        if (data.type == "cursor")
        {
            // Mueve el objeto basado en las coordenadas del cursor
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(data.x, data.y, Camera.main.nearClipPlane));
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    [System.Serializable]
    public class MessageData
    {
        public string type;
        public float x;
        public float y;
    }
}
