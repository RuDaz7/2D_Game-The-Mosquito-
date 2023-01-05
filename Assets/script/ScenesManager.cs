using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 필요

public class ScenesManager : MonoBehaviour
{
    public void Click_LoadMainGameScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void Click_ExitGame()
    {
        Application.Quit();
    }

   // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape))
    { 
        Application.Quit();
    }

         if (Input.GetKeyDown(KeyCode.Backspace))
    { 
        SceneManager.LoadScene("TitleScene");
    }
    if(Player.HP == true)
    {
        SceneManager.LoadScene("LostScene");
    }
    if(Mosq.Boss_HP == true)
    {
        SceneManager.LoadScene("ClearScene");
    }
    }
}
