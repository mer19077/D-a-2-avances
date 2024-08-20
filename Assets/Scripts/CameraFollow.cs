using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // El globo
    public Transform backgroundTransform;  // El fondo
    public Vector3 offset;            // Desplazamiento de la cámara respecto al objetivo
    public float smoothSpeed = 0.125f; // Velocidad de suavizado de la cámara

    private float minX, maxX, minY, maxY;

    void Start()
    {
        // Calcular los límites de movimiento de la cámara basados en el tamaño del fondo
        SpriteRenderer bgRenderer = backgroundTransform.GetComponent<SpriteRenderer>();

        float halfCamHeight = Camera.main.orthographicSize;
        float halfCamWidth = halfCamHeight * Camera.main.aspect;

        minX = backgroundTransform.position.x - bgRenderer.bounds.size.x / 2 + halfCamWidth;
        maxX = backgroundTransform.position.x + bgRenderer.bounds.size.x / 2 - halfCamWidth;

        minY = backgroundTransform.position.y - bgRenderer.bounds.size.y / 2 + halfCamHeight;
        maxY = backgroundTransform.position.y + bgRenderer.bounds.size.y / 2 - halfCamHeight;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Posición deseada de la cámara
            Vector3 desiredPosition = target.position + offset;

            // Limitar la posición deseada dentro de los límites calculados
            float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

            // Suavizado de la transición
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

            // Actualizar la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
