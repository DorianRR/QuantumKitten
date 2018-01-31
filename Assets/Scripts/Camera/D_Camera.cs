using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Camera: MonoBehaviour
{

    public GameObject player;
    public bool centeredOnGW = false;
    public float zoomSpeed = 1;
    public float screenScaleWithSpeed = 2f;
    public float lerpRatio = 30f;

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
        Mathf.Clamp(screenOrth, 10, 30);

        if (!centeredOnGW)
        {
            reCenter();
        }

        if(centeredOnGW)
        {
            GWPosition.z = -22f;
            //transform.position = Vector3.Lerp(transform.position, GWPosition, 0.05f);
            
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 50, lerpRatio* Time.deltaTime);
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
        //transform.position = Vector3.Lerp(transform.position, player.GetComponent<Rigidbody>().transform.position + offset, lerpRatio* Time.deltaTime);
        transform.position = player.GetComponent<Rigidbody>().transform.position + offset;

        screenOrth = Mathf.Clamp(player.GetComponent<Rigidbody>().velocity.magnitude/2, 10, 30);
        Mathf.Clamp(screenOrth, 10, 30);
        //screenOrth = 10;

        gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, screenOrth, lerpRatio* Time.deltaTime);
        centeredOnGW = false;
    }
}

