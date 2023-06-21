using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {
        UpdateLevelButtons();
    }

    public void Select(string levelname)
    {
        SceneManager.LoadScene(levelname);
        SceneManager.LoadScene("DontDestroy", LoadSceneMode.Additive);
    }

    public void SelectX(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public void UnlockAllLevels()
    {
        PlayerPrefs.SetInt("levelReached", levelButtons.Length);
        UpdateLevelButtons();
    }

    private void UpdateLevelButtons()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= levelReached)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    public void ResetAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        UpdateLevelButtons();
    }
}
