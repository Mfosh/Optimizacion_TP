using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
   public Button primaryButton;

   void Start()
    {
        primaryButton.Select();
    }

   public void Level_Start(string level)
    {
        SceneManager.LoadScene(level);
    }

   public void Exit()
    {
        Application.Quit();
    }
}
