using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array de puntos de control que el globito debe alcanzar
    public float moveSpeed = 2f;  // Velocidad del globito
    private int currentWaypointIndex = 0; // Índice del punto de control actual

    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // Mueve el globito hacia el siguiente punto de control
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

            // Si el globito llega al punto de control, se detiene y espera a la señal para moverse al siguiente
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                StartCoroutine(WaitAtWaypoint());
            }
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        yield return new WaitForSeconds(1f); // Espera un segundo en el punto de control
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            // Ha llegado al último punto de control
            ShowLevelPrompt();
        }
    }

    void ShowLevelPrompt()
    {
        // Muestra el mensaje de entrar al nivel
        Debug.Log("Has alcanzado Level 1. ¿Entrar?");
        // Aquí puedes mostrar un cuadro de diálogo real usando UI de Unity
    }
}