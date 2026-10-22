using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

//This is used for when we want the music to keep playing or stop playing depending on the scene and I hope this actually works

public class REALROCKFM : MonoBehaviour
{
    public AudioSource MusicSource;
    //public AudioClip MusicClip;
    public static GameObject MusicObject;
    
    void Start()
    {
        //MusicSource = GetComponent<AudioSource>();
        

    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (MusicObject != null)
        {
            print(MusicObject.name);
            Destroy(gameObject);
            return;
        }
        MusicObject = this.gameObject;
        

    }
    void Update()
    {
        //if (SceneManager.GetActiveScene().name != "Ellan testi scene")
        //{
            
        //}
        if (SceneManager.GetActiveScene().name == "Ellan testi scene")
        {
            Destroy(gameObject);
        }
        //if(MusicSource.isPlaying == true)
        //{
            //return;
            
        //}
        //else
        //{
            //MusicSource.Play();
        //}
        
        
        
    }
}
