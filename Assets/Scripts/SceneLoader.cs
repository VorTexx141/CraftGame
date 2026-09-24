using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Tarkistaa, onko scene olemassa ennen lataamista
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Viimeinen taso saavutettu!");
        }
    }

    // Lataa tietyn nimisen scenen (käytettäväksi UI-painikkeissa)
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Lopettaa pelin (UI-painike)
    public void QuitGame()
    {
        Application.Quit();
    }

    // Triggeri seuraavan levelin lataamiseen
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Osui");
            LoadNextScene();
        }
    }
}
