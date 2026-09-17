using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiButtonCode : MonoBehaviour

{
 public void ButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}
