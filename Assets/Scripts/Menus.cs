using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void InfoScene()
    {
        SceneManager.LoadScene(3);
    }
    public void Exitgame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

}