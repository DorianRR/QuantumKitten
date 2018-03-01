using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {

    public GameObject exitPortal;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerController pC = other.GetComponent<PlayerController>();
            if (pC.getState() != PlayerController.PlayerState.Teleporting)
            {
                pC.setPlayerState(PlayerController.PlayerState.Teleporting);
                other.transform.position = exitPortal.transform.position;
            }
            else
            {

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if (other.GetComponent<PlayerController>().getState() == PlayerController.PlayerState.Teleporting)
            {
                other.GetComponent<PlayerController>().StartCoroutine(other.GetComponent<PlayerController>().setState(PlayerController.PlayerState.Moving, 0.2f));
            }
        }
    }
}
