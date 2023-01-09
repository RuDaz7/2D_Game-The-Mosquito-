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
    public void Click_Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
       public void Game_Lost()
    {
        SceneManager.LoadScene("LostScene");
    }
          public void Game_Clear()
    {
        SceneManager.LoadScene("ClearScene");
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
        Player.HP = false;
    }
    if(Mosq.Boss_HP == true || DateManager.Instance.DiePoints == 30)
    {
        SceneManager.LoadScene("ClearScene");
        Mosq.Boss_HP = false;
    }
    }
}
