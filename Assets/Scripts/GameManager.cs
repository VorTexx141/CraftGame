using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject[] minigames;
    int activeMiniGame = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Shuffle()
    {
        for (int i = 0; i < minigames.Length; i++)
        {
            GameObject temp = minigames[i];
            int randomIndex = Random.Range(i, minigames.Length);
            minigames[i] = minigames[randomIndex];
            minigames[randomIndex] = temp;
        }
    }
    private void Awake()
    {
        Shuffle();
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
        StartCoroutine(GameChanger());
    }
    IEnumerator GameChanger()
    {
        WinScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        if (activeMiniGame != null)
        {
            minigames[activeMiniGame].SetActive(false);
        }
    }

}
