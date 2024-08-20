using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float scrollSpeed = 1f;         // Velocidad a la que se mueve el fondo
    public float tileSizeX;                // Ancho del fondo que se repetirá

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Desplaza el fondo hacia la izquierda
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // Verifica si el fondo ha salido de la pantalla
        if (transform.position.x < -tileSizeX)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        // Mueve el fondo al final del último fondo visible
        Vector3 offset = new Vector3(tileSizeX * 2f, 0, 0);
        transform.position = startPosition + offset;
    }
}