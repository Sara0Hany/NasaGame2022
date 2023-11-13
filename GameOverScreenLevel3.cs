using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScreenLevel3 : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Level1 2");

    }
}
