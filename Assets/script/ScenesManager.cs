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
        DateManager.Instance.Die();
    }
       public void Game_Lost()
    {
        SceneManager.LoadScene("LostScene");
        DateManager.Instance.Die();
    }
          public void Game_Clear()
    {
        SceneManager.LoadScene("WinScene");
        DateManager.Instance.Die();
    }
           public void Ranking()
    {
        SceneManager.LoadScene("Rank");
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
     if(Player.HP_Zero == true)
    {
        SceneManager.LoadScene("LostScene");
        Player.HP_Zero = false;
    }
    if(Mosq.Boss_HP_Zero == true || DateManager.Instance.DiePoints == 30)
    {
        SceneManager.LoadScene("WinScene");
        Mosq.Boss_HP_Zero = false;
        DateManager.Instance.Die();
    }
    }
}
