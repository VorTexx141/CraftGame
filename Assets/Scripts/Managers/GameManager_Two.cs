using System.Collections;
using UnityEngine;

public class GameManager_Two : MonoBehaviour
{
    public static GameManager_Two instance;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject[] minigames;

    int activeMiniGame = 0;
    int previousMinigame = 0;
    public float MiniGameTime = 10;
    float Timer;

    private bool gameIsOn = false;

    private void Awake()
    {
        Timer = MiniGameTime;
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

    private void Start()
    {
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);
    }

    private void Update()
    {
        if (gameIsOn)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Timer = 0;
                losegame();
            }

        }
    }

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

    public void wingame()
    {
        StartCoroutine(GameChanger());
    }
    public void victory()
    {
        gameIsOn = false;
        WinScreen.SetActive(true);
    }
    public void losegame()
    {
        StartCoroutine(LoseGameChanger());
    }
    IEnumerator GameChanger()
    {
        gameIsOn = true;
        if (activeMiniGame >= minigames.Length)
        {
            victory();
        }
        else
        {
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
            Timer = MiniGameTime;
        }
        //WinScreen.SetActive(true);
    }
    IEnumerator LoseGameChanger()
    {
        gameIsOn = false;
        LoseScreen.SetActive(true);
        yield return new WaitForSeconds(1);
    }
}
