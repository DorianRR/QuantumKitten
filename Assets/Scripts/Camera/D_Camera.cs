using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Camera: MonoBehaviour
{

    public GameObject player;
    public bool centeredOnGW = false;
    public float zoomSpeed = 1;
    public float screenScaleWithSpeed = 2f;

    private Vector3 offset;
    private Vector3 GWPosition;
    private float screenOrth = 15;
    


    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        Mathf.Clamp(screenOrth, 20, 50);

        if (!centeredOnGW)
        {
            reCenter();
        }

        if(centeredOnGW)
        {
            GWPosition.z = -22f;
            transform.position = Vector3.Lerp(transform.position, GWPosition, 0.05f);
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 50, 0.05f);
        }
        
    }

    public void CenterOnSpawnedGW(Vector3 location)
    {
        centeredOnGW = true;
        GWPosition = location;
    }

    public void reCenter()
    {
        //This lerping needs to be adjusted to reduce lag.
        transform.position = Vector3.Lerp(transform.position, player.GetComponent<Rigidbody>().transform.position + offset, 0.1f);

        screenOrth = player.GetComponent<Rigidbody>().velocity.magnitude;
        Mathf.Clamp(screenOrth, 20, 50);

        gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, screenOrth, 0.025f);
        centeredOnGW = false;
    }
}

