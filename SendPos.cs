using UnityEngine;

public class WebGLCommunication : MonoBehaviour
{
    private Mov controlledObject;

    void Start()
    {
        controlledObject = FindObjectOfType<Mov>();
    }

    public void OnMessage(string message)
    {
        // Parsear el mensaje y actualizar la posición del objeto
        string[] parts = message.Split(',');
        if (parts.Length == 3 && parts[0] == "cursor")
        {
            float x = float.Parse(parts[1]);
            float y = float.Parse(parts[2]);
            controlledObject.SetTargetPosition(x, y);
        }
    }
}

