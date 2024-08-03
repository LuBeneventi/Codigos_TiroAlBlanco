using UnityEngine;

public class Mov : MonoBehaviour
{
    private Vector3 targetPosition;

    void Start()
    {
        // Inicializar la posición del objeto
        targetPosition = transform.position;
    }

    void Update()
    {
        // Interpolar la posición del objeto hacia la posición objetivo
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
    }

    public void SetTargetPosition(float x, float y)
    {
        // Convertir las coordenadas de la pantalla a coordenadas del mundo
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(x, y, Camera.main.nearClipPlane));
        targetPosition = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
    }
}




