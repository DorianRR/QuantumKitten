using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSwitch_vfx : MonoBehaviour
{

    private float speed;
    public ParticleSystem rainbowTrail;
    public ParticleSystem destTrail;


	// Use this for initialization
	void Start ()
    {
       

        
        
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
        if (GetComponent<Rigidbody>().velocity.magnitude > 45)
        {
            destTrail.Play();
            rainbowTrail.Stop();
        }
        else if (GetComponent<Rigidbody>().velocity.magnitude < 45)
        {
            rainbowTrail.Play();
            destTrail.Stop();
        }

        
    }
    
}

