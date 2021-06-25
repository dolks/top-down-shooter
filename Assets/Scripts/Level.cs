using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    int MAIN_SCENE_INDEX = 0;
    int GAME_OVER_SCENE_INDEX = 1;
    int START_MENU_SCENE_INDEX = 2;

    public void LoadMain()
    {
        SceneManager.LoadScene(MAIN_SCENE_INDEX);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(GAME_OVER_SCENE_INDEX);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(START_MENU_SCENE_INDEX);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
