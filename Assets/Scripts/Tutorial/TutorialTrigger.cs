using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour {

    public GameObject ChildCanvas;
    public GameObject gWell1;

    private TutorialController controller;
    private GameObject Player;



    // Use this for initialization
    void Start ()
    {
        controller = GameObject.Find("TutorialController").GetComponent<TutorialController>();
        Player = GameObject.Find("Player");

        gWell1.SetActive(false);

        Player.GetComponent<PlayerController>().canSpawn = false;
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
