using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {

    Vector3 scaleTemp;
    bool scaled = false;
    private void Start()
    {
        scaleTemp = transform.localScale;
    }
    // Update is called once per frame
    void FixedUpdate () {
        transform.Rotate(Vector3.up * .25f);

        if(scaleTemp.x < 8 && !scaled)
        {
            scaleTemp.x += .75f;
            scaleTemp.y += .75f;
            scaleTemp.z += .75f;
        }
        else if(!scaled)
        {
            scaled = true;
        }
        else if(scaleTemp.x > 7 && scaled)
        {
            scaleTemp.x -= .75f;
            scaleTemp.y -= .75f;
            scaleTemp.z -= .75f;
        }

        transform.localScale = scaleTemp;
	}
}
