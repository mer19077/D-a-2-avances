using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform[] levelPositions; // Array para las posiciones de los niveles
    public int currentLevel = 0;       // Índice del nivel actual

    void Start()
    {
        // Coloca el globito en la posición inicial (nivel 1)
        transform.position = levelPositions[currentLevel].position;
    }

    void Update()
    {
        // Aquí puedes agregar lógica para mover el globito cuando se desbloquee el siguiente nivel
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el globito ha alcanzado un punto de nivel
        if (other.CompareTag("LevelPoint"))
        {
            int levelIndex = int.Parse(other.name.Replace("Level", ""));
            if (levelIndex == currentLevel + 1)
            {
                // Si el siguiente nivel es alcanzable, muestra un mensaje para entrar
                currentLevel = levelIndex;
                ShowEnterLevelPrompt();
            }
        }
    }

    void ShowEnterLevelPrompt()
    {
        // Aquí mostrarías un cuadro emergente con opciones para entrar al nivel
        Debug.Log("Enter Level " + (currentLevel + 1));
        // Si el jugador confirma, puedes cargar la escena del nivel
        // SceneManager.LoadScene("Level" + currentLevel);
    }
}