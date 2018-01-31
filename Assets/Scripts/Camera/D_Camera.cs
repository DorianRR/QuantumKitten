using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Camera: MonoBehaviour
{

    public GameObject player;
    public bool centeredOnGW = false;
    public float zoomSpeed = 1;

    private Vector3 offset;
    private Vector3 GWPosition;
    


    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(centeredOnGW)
        {
            GWPosition.z = -22f;
            transform.position = GWPosition;
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(15, 25, .05f);
        }
        else
        {
            transform.position = player.GetComponent<Rigidbody>().transform.position + offset;

            gameObject.GetComponent<Camera>().orthographicSize = 15;

        }
    }

    public void CenterOnSpawnedGW(Vector3 location)
    {
        Debug.Log("poooop");
        centeredOnGW = true;
        GWPosition = location;
    }
   
    public void reCenter()
    {
        centeredOnGW = false;
    }
}

