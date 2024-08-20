using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;        // Fuerza con la que el globo sube
    public float rotationAmount = 5f;   // Cantidad de rotaci�n del globo
    private Rigidbody2D rb;             // Referencia al Rigidbody2D del globo

    private float screenTop;            // Coordenada del techo
    private float screenBottom;         // Coordenada del suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Inicializa la referencia al Rigidbody2D
        rb.gravityScale = 1f;              // Ajusta la gravedad
        Time.timeScale = 1;                // Asegura que el tiempo est� corriendo

        // Calcula los l�mites de la pantalla en el eje Y
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    void Update()
    {
        // Mant�n presionado para que el globo suba
        if (Input.GetMouseButton(0))  // Detecta si el jugador est� manteniendo presionado el bot�n del mouse o la pantalla t�ctil
        {
            rb.velocity = new Vector2(0, jumpForce);  // Solo mueve en el eje Y
            rb.rotation = rotationAmount;  // Rota hacia arriba
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);  // Mantener solo el movimiento en Y
            rb.rotation = -rotationAmount;  // Rota hacia abajo cuando no se presiona
        }

        // Verifica si el globo toca el techo o el suelo
        if (transform.position.y > screenTop || transform.position.y < screenBottom)
        {
            GameOver();  // Llama a GameOver si el globo sale de los l�mites
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;  // Pausa el juego
        // Aqu� puedes agregar l�gica para reiniciar el nivel o mostrar una pantalla de fin de juego
    }
}