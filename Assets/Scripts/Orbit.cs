using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public GameObject CenterOrbit; //game object that will be the center of the orbit.
    public float speed; //controls the speed of the orbit.

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        OrbitAround();  // This function or method will make an object orbit around the centerOrbit.
		
	}

    void OrbitAround()
    {

        transform.RotateAround(CenterOrbit.transform.position, Vector3.back, speed * Time.deltaTime);  //make object orbit around the CenterOrbit.

    }
}
