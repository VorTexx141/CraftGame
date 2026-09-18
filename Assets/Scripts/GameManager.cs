using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject[] minigames;
    int activeMiniGame = 0;
    int previousMinigame = 0;
    public float MiniGameTime = 10;
    float Timer;
    bool TimerOn;
    public TextMeshProUGUI timeText;
    public int Lives = 3;
    bool minigamelost = false;
    public GameObject MinigameWinScreen;
    public GameObject MinigameLostScreen;
    public GameObject MinigameTransScreen;
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
        if (TimerOn)
        {
            Timer -= Time.deltaTime;
            int seconds = Mathf.RoundToInt(Timer);
            timeText.text = seconds.ToString();
        }
        if (Timer <= 0 && !minigamelost)
        {
            Timer = 0;
            losegame();
        }
    }


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
    

    public void wingame()
    {
        StartCoroutine(GameChanger());
    }


    public void victory()
    {
        WinScreen.SetActive(true);
        TimerOn = false;
    }


    public void losegame()
    {
        minigamelost = true;
        TimerOn = false;
        Lives--;
        if (Lives <= 0)
        {
            gameover();
        }
    }


    public void gameover()
    {
        StartCoroutine(LoseGameChanger());
    }
    IEnumerator GameChanger()
    {
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
            TimerOn = true;
            minigamelost = false;
        }
            //WinScreen.SetActive(true);
    }


    IEnumerator LoseGameChanger()
    {
        LoseScreen.SetActive(true);
        TimerOn = false;
        yield return new WaitForSeconds(1);
    }
}
