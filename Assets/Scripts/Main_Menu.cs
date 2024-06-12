using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

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

        Addressables.LoadScene(level, LoadSceneMode.Single);
    }

   public void Exit()
    {
        Application.Quit();
    }
}
