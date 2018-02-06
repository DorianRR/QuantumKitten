using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAndScale : MonoBehaviour {

    public GameObject particleOwner;
    private float radius;
    Vector3 scaleTemp;
    Transform temp;
    // Use this for initialization
    private void Start()
    {
        scaleTemp = particleOwner.transform.localScale;
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (scaleTemp.x <= 5f)
        {
            scaleTemp.x += .5f;
            scaleTemp.y += .5f;
            scaleTemp.z += .5f;
        }
        else if (scaleTemp.x <= 13f)
        {
            scaleTemp.x += .75f;
            scaleTemp.y += .75f;
            scaleTemp.z += .75f;
        }
        particleOwner.transform.localScale = scaleTemp;
        particleOwner.transform.Rotate(Vector3.right * 2f);
    }
}
