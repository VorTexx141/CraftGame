using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class KnittingGameScript : MonoBehaviour
{
    public Animator KnittingAnimator;
    int APressedCount;
    int DPressedCount;
    public int PressCount;
    bool APressed = false;
    bool DPressed = true;
    public GameObject APrompt;
    public GameObject DPrompt;
    public GameObject[] ScarfChunks;
    int ScarfChunksDone;
    public GameObject WorkingFace;
    public GameObject DoneFace;
    int TotalPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        APrompt.SetActive(true);
        DPrompt.SetActive(false);
        WorkingFace.SetActive(true);
        DoneFace.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame && APressed == false)
        {
            KnittingAnimator.SetTrigger("Right");
            APressedCount++;
            APressed = true;
            DPressed = false;
            APrompt.SetActive(false);
            DPrompt.SetActive(true);
        }
        if (Keyboard.current.dKey.wasPressedThisFrame && DPressed == false)
        {
            KnittingAnimator.SetTrigger("Left");
            DPressedCount++;
            DPressed = true;
            APressed = false;
            APrompt.SetActive(true);
            DPrompt.SetActive(false);
            TotalPressed = APressedCount + DPressedCount;
            if (TotalPressed >= PressCount)
            {
                AddChunk();
                APressedCount = 0;
                DPressedCount = 0;
                TotalPressed = 0;
            }
        }
    }

    void AddChunk()
    {
        print("chunky");
        ScarfChunks[ScarfChunksDone].SetActive(true);
        ScarfChunksDone++;
        if (ScarfChunksDone >= ScarfChunks.Length)
        {
            WorkingFace.SetActive(false);
            DoneFace.SetActive(true);
            GameManager.instance.wingame();
        }
    }
}
