using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void wingame()
    {
        StartCoroutine(LevelLoader());
    }
    IEnumerator LevelLoader()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(1);
        while(!loading.isDone)
        {
            yield return null;
        }
    }

}
