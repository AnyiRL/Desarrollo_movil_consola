using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonFunctions : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadFlappyScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        GameManager.instance.Reset();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);        
    }
}
