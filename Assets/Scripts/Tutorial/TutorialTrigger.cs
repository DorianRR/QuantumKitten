using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour {

    private TutorialController controller;
    public GameObject ChildCanvas;

	// Use this for initialization
	void Start ()
    {
        controller = GameObject.Find("Test").GetComponent<TutorialController>();
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
        //WHY IS THIS NOT WORKING WAAAAT TERMINATING AT THE YIELD
        Debug.Log("Start");
       
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Stop");
        ChildCanvas.SetActive(true);

    }
}
