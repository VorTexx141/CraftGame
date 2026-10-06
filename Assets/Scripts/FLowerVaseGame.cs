using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FLowerVaseGame : MonoBehaviour
{
    public Rigidbody2D flower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            flower.transform.parent = null;
            flower.simulated = true;
            flower.gravityScale = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flower"))
        {
            print("planted");
            GameManager.instance.wingame();
        }
    }
}
