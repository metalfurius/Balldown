using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded=false;
    public float restartDelay=2f;
    public GameObject completeLevelUI;
    public TextMeshProUGUI highscore;
    int levelToUnlock,topLevel,score,oldscore;
    public void EndGame()
    {
        if(gameHasEnded==false)
        {
        gameHasEnded=true;
        Invoke("Restart",restartDelay);
        }
    }
    public void Restart()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("DontDestroy",LoadSceneMode.Additive);
    }
    public void CompleteLevel()
    {
        if(!gameHasEnded){
        levelToUnlock = Int16.Parse(SceneManager.GetActiveScene().name.Split(' ').GetValue(1).ToString());
        topLevel = PlayerPrefs.GetInt("levelReached");
        if(topLevel==0)
            topLevel=1;
        if(topLevel == levelToUnlock){
            PlayerPrefs.SetInt("levelReached",levelToUnlock+1);
        }
        FindObjectOfType<PlayerCollision>().GetComponent<PlayerMovement>().enabled=false;
        completeLevelUI.SetActive(true);
        
        FindObjectOfType<AudioManager>().Play("Win");
        FindObjectOfType<AudioManager>().Play("Complete");


        for (int i = 0; i < levelToUnlock; i++)
        {
            score=Int16.Parse(FindObjectOfType<Score>().scoreText.text);
            oldscore=PlayerPrefs.GetInt("highscore"+levelToUnlock);
            if(score>oldscore)
            {
                PlayerPrefs.SetInt("highscore"+levelToUnlock,score);
                highscore.text=score.ToString();
            }
            else
            {
                highscore.text=oldscore.ToString();
            }
        }
        }
    }
}