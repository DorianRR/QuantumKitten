using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    public GameObject Player;

	void Start () 
    {

	}

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeSlow());
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(FadeToNormalSpeed());
        }
	}

    public void CallFadeSlow()
    {
        StartCoroutine(FadeSlow());
    }

    public void CallFadeSlow(GameObject toPass)
    {
        StartCoroutine(FadeSlow(toPass));
    }

    public void CallFadeToNormalSpeed()
    {
        StartCoroutine(FadeToNormalSpeed());
    }

    private IEnumerator FadeSlow()
    {
        Player.GetComponent<PlayerController>().canSpawn = false;

        while (Time.timeScale > 0.5f)
        {
            Time.timeScale -= 0.02f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Time.timeScale = 0;
        yield return null;
    }

    private IEnumerator FadeSlow(GameObject toActivate)
    {
        Player.GetComponent<PlayerController>().canSpawn = false;

        while (Time.timeScale > 0.5f)
        {
            Time.timeScale -= 0.02f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        toActivate.SetActive(true);
        Time.timeScale = 0;
        yield return null;
    }

    private IEnumerator FadeToNormalSpeed()
    {
        while (Time.timeScale <= 1f)
        {
            Time.timeScale += 0.05f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Time.timeScale = 1;
        Player.GetComponent<PlayerController>().canSpawn = true;

        yield return null;
    }
}
