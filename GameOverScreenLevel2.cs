using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenLevel2 : MonoBehaviour
{
    public void RestartButton() 
    {
        SceneManager.LoadScene("Level1 1");

    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
