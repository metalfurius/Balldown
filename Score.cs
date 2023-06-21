using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    Scene m_Scene;
    string sceneName;
    public TextMeshProUGUI scoreText;
    
    
    private void Start()
        {
            m_Scene = SceneManager.GetActiveScene();
            sceneName = m_Scene.name;
        }

    void FixedUpdate()
    {
        GameObject pl=GameObject.FindGameObjectWithTag("Player");
        PlayerMovement speedpl=pl.GetComponent<PlayerMovement>();
        float currentpl=speedpl.speed;
        float playerpos=pl.GetComponent<Transform>().position.z;
        scoreText.text=(playerpos*2.0f+currentpl*6.0f).ToString("0");
        if (sceneName=="Shop"|sceneName=="LevelSelect")
            {
                Destroy(gameObject);
            }
        
    }
}
