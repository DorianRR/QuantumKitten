using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuButtons : MonoBehaviour {

    [SerializeField]
    private VideoClip VP = null;

    [SerializeField]
    private GameObject VideoPanel = null;

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayButton()
    {
        StartCoroutine(StartMainLevel());
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void FreePlayButton()
    {
        SceneManager.LoadScene("FreePlay");
    }

    public void SurveyButton()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator StartMainLevel()
    {
        VideoPanel.SetActive(true);
        yield return new WaitForSeconds((float)VP.length);
        //VideoPanel.SetActive(false);
        //yield return new WaitForSeconds(0.25f);

        SceneManager.LoadScene("MainLevel");

        yield return null;
    }
}
