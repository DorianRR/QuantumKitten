using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSwitch_vfx : MonoBehaviour
{
    private float speed;  //Float var that allows easy input of velocity.
    public ParticleSystem rainbowTrail;  //Public var to drop in vfx.
    public ParticleSystem destTrail;  //Public var to drop in vfx.
    public ParticleSystem preBurst; //Public var to drop in vfx.
    public float breakSpeed = 0.0f;  //Enter the velocity at which the cat can break things.
    public float topTranformSpeed = 0.0f;  //This is the top end of the velocity at which the lighting works.
    public float bottomTransformSpeed = 0.0f;  //This is the bottom end of the velocity at  which the lighting works.

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {        
        if (GetComponent<Rigidbody>().velocity.magnitude > breakSpeed)  //If speed is > 45, Play destTrail prefab & Stop rainbowTrail prefab.
        {
            destTrail.Play();  //Play destTrail vfx.
            rainbowTrail.Stop();  //Stop rainbowTrail vfx.
        }
        else if (GetComponent<Rigidbody>().velocity.magnitude < breakSpeed)
        {
            rainbowTrail.Play();  //Play rainbowTrail vfx.
            destTrail.Stop();  //Stop destTrail vfx.            
        }  
        
        if ((GetComponent<Rigidbody>().velocity.magnitude < topTranformSpeed) && (GetComponent<Rigidbody>().velocity.magnitude > bottomTransformSpeed))
        {
            preBurst.Play(); //Play the preBurst vfx.
        }
        else
        {
            preBurst.Stop();  //Stop the preBurst vfx.
        }
    }    
}

