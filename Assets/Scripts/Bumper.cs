using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {


    Animator anim;



    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionExit(Collision collision)
    {
        
        anim.SetBool("Hit", false);

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {

            anim.SetBool("Hit", true);

        }
        

    }

}
