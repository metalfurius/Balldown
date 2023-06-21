using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackLvl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    Scene m_Scene;
    string sceneName;
    private void Start() {
        animator=GetComponent<Animator>();
        m_Scene = SceneManager.GetActiveScene();
            sceneName = m_Scene.name;
    }
    public void TriggerEvent(){
        animator.SetTrigger("Triggeri");
    }
    private void Update() {
        if (sceneName=="Credits"|sceneName=="LevelSelect")
            {
                Destroy(gameObject);
            }
    }
}
