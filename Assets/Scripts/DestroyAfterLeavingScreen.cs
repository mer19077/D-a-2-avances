using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterLeavingScreen : MonoBehaviour
{
    private float destroyXPosition;

    void Start()
    {
        // Calcular la posición X en la que el objeto será destruido, justo fuera del borde izquierdo de la pantalla
        destroyXPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 1f;

        // Verificar si el objeto es un clon; si no, no destruir
        if (gameObject.scene.name == null)
        {
            Debug.Log("This is the original prefab and should not be destroyed.");
            // Salir de este script si es el prefab original
            enabled = false;
        }
    }

    void Update()
    {
        // Destruir el objeto si sale de la pantalla
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
