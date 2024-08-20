using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnLevelListButton()
    {
        // Aqu� cargamos la escena de la lista de niveles
        SceneManager.LoadScene("LevelMap"); // Reemplaza con el nombre de tu escena
    }

    public void OnStoreButton()
    {
        // Aqu� cargamos la escena de la tienda
        SceneManager.LoadScene("StoreScene"); // Reemplaza con el nombre de tu escena
    }

    public void OnUpdatesButton()
    {
        // Aqu� cargamos la escena de actualizaciones
        SceneManager.LoadScene("UpdatesScene"); // Reemplaza con el nombre de tu escena

    }
}

