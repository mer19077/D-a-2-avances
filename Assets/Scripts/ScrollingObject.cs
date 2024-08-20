using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float scrollSpeed = 5f;  // Velocidad a la que se mueven los objetos

    void Update()
    {
        // Mueve el objeto hacia la izquierda
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
    }
}