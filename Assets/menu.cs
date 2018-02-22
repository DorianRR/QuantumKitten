using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {


    public void startGame()
    {
        SceneManager.LoadScene("BOUNCE");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
