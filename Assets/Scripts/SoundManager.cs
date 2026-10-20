using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] KnitSounds;
    public AudioClip[] WalkSounds;
    public AudioSource GeneralSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void PlayRandomKnitSound()
    {
        int randomKnitSound = Random.Range(0, KnitSounds.Length);
        GeneralSource.PlayOneShot(KnitSounds[randomKnitSound]);
    }

    public void PlayRandomWalkSound()
    {
        int randomWalkSound = Random.Range(0, WalkSounds.Length);
        GeneralSource.PlayOneShot(WalkSounds[randomWalkSound]);
    }


    private void Awake()
    {
        
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
