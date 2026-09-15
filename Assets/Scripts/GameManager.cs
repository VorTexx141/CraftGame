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
    int previousMinigame = 0;
    public float Timer = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Shuffle()
    {
        foreach (GameObject go in minigames)
        {
            go.SetActive(false);
        }
        for (int i = 0; i < minigames.Length; i++)
        {
            GameObject temp = minigames[i];
            int randomIndex = Random.Range(i, minigames.Length);
            minigames[i] = minigames[randomIndex];
            minigames[randomIndex] = temp;
        }
    }
    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = 0;
            losegame();
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
        StartCoroutine(GameChanger());
    }
    
    public void wingame()
    {
        StartCoroutine(GameChanger());
    }
    public void victory()
    {
        WinScreen.SetActive(true);
    }
    public void losegame()
    {
        StartCoroutine(LoseGameChanger());
    }
    IEnumerator GameChanger()
    {
        if (activeMiniGame >= minigames.Length)
        {
            victory();
        }
        //WinScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        if (activeMiniGame == 0)
        {
            minigames[activeMiniGame].SetActive(true);
            previousMinigame = activeMiniGame;
        }
        else if (activeMiniGame > 0)
        {
            minigames[previousMinigame].SetActive(false);
            minigames[activeMiniGame].SetActive(true);
            previousMinigame = activeMiniGame;
        }
        activeMiniGame++;
    }
    IEnumerator LoseGameChanger()
    {
        LoseScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        if (activeMiniGame != null)
        {
            minigames[activeMiniGame].SetActive(false);
        }
    }
}
