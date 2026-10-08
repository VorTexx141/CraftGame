using UnityEngine;
using UnityEngine.InputSystem;

public class CatwalkingScript : MonoBehaviour
{
    public Animator CatwalkAnimator;
    int APressedCount;
    int DPressedCount;
    public int PressCount;
    bool APressed = false;
    bool DPressed = true;
    public GameObject APrompt;
    public GameObject DPrompt;
    float WalkingTime = 0;
    public float AddTime = 0.1f;
    public float MaxTime = 1f;
    public float WalkingSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        APrompt.SetActive(true);
        DPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WalkingTime -= Time.deltaTime;
        if (WalkingTime <= 0)
        {
            WalkingTime = 0;
            CatwalkAnimator.speed = 0;
        }
        if (WalkingTime > 0)
        {
            transform.Translate(Vector3.right * (WalkingSpeed * Time.deltaTime),Space.World);
            CatwalkAnimator.speed = 1;
            if (WalkingTime >= MaxTime)
            {
                WalkingTime = MaxTime;
            }
        }
        if (Keyboard.current.aKey.wasPressedThisFrame && APressed == false)
        {
            WalkingTime += AddTime;
            APressedCount++;
            APressed = true;
            DPressed = false;
            APrompt.SetActive(false);
            DPrompt.SetActive(true);
        }
        if (Keyboard.current.dKey.wasPressedThisFrame && DPressed == false)
        {
            WalkingTime += AddTime;
            DPressedCount++;
            DPressed = true;
            APressed = false;
            APrompt.SetActive(true);
            DPrompt.SetActive(false);
        }
    }
}
