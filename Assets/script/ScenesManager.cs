using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
<<<<<<< Updated upstream
=======
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
        PlayerHP.Player_HP = 100f;
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

>>>>>>> Stashed changes
   // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape))
    { 
        Application.Quit();
    }
<<<<<<< Updated upstream
        
=======

    if (Input.GetKeyDown(KeyCode.Backspace))
    { 
        SceneManager.LoadScene("TitleScene");
    }
     if(PlayerHP.Player_HP == 0)
    {
        //SceneManager.LoadScene("LostScene");
        Invoke("Game_Lost", 2.0f);
    }
    if(Mosq.Boss_HP_Zero == true || DateManager.Instance.DiePoints == 30)
    {
        SceneManager.LoadScene("WinScene");
        Mosq.Boss_HP_Zero = false;
        DateManager.Instance.Die();
    }
>>>>>>> Stashed changes
    }
}
