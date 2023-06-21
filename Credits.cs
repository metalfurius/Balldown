using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private void Awake() {
        FindObjectOfType<AudioManager>().Play("Complete");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
