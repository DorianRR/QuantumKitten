using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour {

    private TutorialController controller;
    public GameObject ChildCanvas;
    public GameObject gWell1;

	// Use this for initialization
	void Start ()
    {
        controller = GameObject.Find("Test").GetComponent<TutorialController>();
        gWell1.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            StartCoroutine(ThereHasToBeABetterWayToWait());

            controller.CallFadeSlow();
        }
    }

    IEnumerator ThereHasToBeABetterWayToWait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        ChildCanvas.SetActive(true);

    }

    public void spawnWell()
    {
        gWell1.SetActive(true);
        controller.CallFadeToNormalSpeed();
        ChildCanvas.SetActive(false);
    }
}
