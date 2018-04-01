using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelDelay;
    private int startScene = 0;
    private int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (autoLoadNextLevelDelay > 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevelDelay);
        } else if(autoLoadNextLevelDelay < 0)
        {
            Debug.LogError("AutoLoadNextLevelDelay must be a positive number!");
        }
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Game quit!");
        Application.Quit();
    }
}
