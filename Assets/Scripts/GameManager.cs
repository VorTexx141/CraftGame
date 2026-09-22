using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Search;

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
    public Animator TransitionAnimation;
    public GameObject[] Life;
    public TextMeshProUGUI InstructionText;
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
        TimerOn = false;
        StartCoroutine(WinnerWaiter());
    }


    IEnumerator WinnerWaiter()
    {
        timeText.gameObject.SetActive(false);
        minigames[previousMinigame].SetActive(false);
        MinigameWinScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        MinigameWinScreen.SetActive(false);
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
        StartCoroutine(LoserWaiter());
    }


    void LifeManager()
    {
        for (int i = 0; i < Life.Length; i++)
        {
            if (i >= Lives)
            {
                Life[i].gameObject.SetActive(false);
            }
            else
            {
                Life[i].gameObject.SetActive(true);
            }
        }
    }


    IEnumerator LoserWaiter()
    {
        timeText.gameObject.SetActive(false);
        minigames[previousMinigame].SetActive(false);
        MinigameLostScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        Lives--;
        LifeManager();
        if (Lives <= 0)
        {
            MinigameLostScreen.SetActive(false);
            gameover();
        }
        else
        {
            MinigameLostScreen.SetActive(false);
            StartCoroutine(GameChanger());
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
            InstructionText.text = minigames[activeMiniGame].GetComponent<Instructor>().GameInstructor;
            TransitionAnimation.SetTrigger("Show");
            yield return new WaitForSeconds(3);
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
            TransitionAnimation.SetTrigger("Hide");
            activeMiniGame++;
            int seconds = Mathf.RoundToInt(Timer);
            timeText.text = seconds.ToString();
            TimerOn = true;
            Timer = MiniGameTime+1;
            
            timeText.gameObject.SetActive(true);
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
