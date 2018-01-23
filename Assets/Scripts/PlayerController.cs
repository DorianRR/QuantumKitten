using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);
    // Use this for initialization
	void Start () {
<<<<<<< HEAD
        //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(5, 0, 0), ForceMode.Impulse);
=======
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
>>>>>>> hoooooot
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
