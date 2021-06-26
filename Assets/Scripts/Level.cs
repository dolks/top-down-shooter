using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    int MAIN_SCENE_INDEX = 0;
    int GAME_OVER_SCENE_INDEX = 1;
    int START_MENU_SCENE_INDEX = 2;
    [SerializeField] float gameOverLoadSeconds = 3f;

    public void LoadMain()
    {
        SceneManager.LoadScene(MAIN_SCENE_INDEX);
        FindObjectOfType<GameSession>().ResetGameSession();
    }

    public void LoadGameOver()
    {
        StartCoroutine(DelayGameOverLoad());
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(START_MENU_SCENE_INDEX);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    IEnumerator DelayGameOverLoad()
    {
        while (true)
        {
            yield return new WaitForSeconds(gameOverLoadSeconds);
            SceneManager.LoadScene(GAME_OVER_SCENE_INDEX);
        };

    }

}
