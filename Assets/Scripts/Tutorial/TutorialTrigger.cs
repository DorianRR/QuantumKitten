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


    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            ChildCanvas.SetActive(true);

            controller.CallFadeSlow();
        }
    }

}
