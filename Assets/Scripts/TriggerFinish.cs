using UnityEngine;
using UnityEngine.Events;

public class TriggerFinish : MonoBehaviour
{
    public UnityEvent Finish;
    public string TagCheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagCheck))
        {
            //Finish.Invoke();
            GameManager.instance.wingame();
        }
    }
}
