using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour
{

    public GameObject player;
    public bool centeredOnGW = false;
    public float zoomSpeed = 1;
    public float screenScaleWithSpeed = 2f;
    public float lerpRatio = 30f;

    private Vector3 offset;
    private Vector3 GWPosition;
    private float screenOrth = 15;
    private Vector3 playerVelocity;
    private Vector3 playerVelLastFrame;
    private bool justBounced = false;
    


    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        playerVelocity = player.GetComponent<Rigidbody>().velocity;

        if (!centeredOnGW && !justBounced)
        {
            reCenter();
        }
      

        if (centeredOnGW)
        {
            GWPosition.z = -22f;
            transform.position = Vector3.Lerp(transform.position, GWPosition, 0.05f);
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 40, lerpRatio* Time.deltaTime);
        }
        
    }

    public void CenterOnSpawnedGW(Vector3 location)
    {
        centeredOnGW = true;
        GWPosition = location;
    }

    public void reCenter()
    {
        gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 20, lerpRatio * Time.deltaTime);
  
        Vector3 playerVelocity = player.GetComponent<Rigidbody>().velocity.normalized;

        if (Mathf.Abs(transform.position.magnitude - (player.GetComponent<Rigidbody>().transform.position + offset + (playerVelocity * 7)).magnitude) > 2)
        {
            Vector3 temp = transform.GetComponent<Rigidbody>().velocity;
            transform.position = Vector3.SmoothDamp(transform.position, (player.GetComponent<Rigidbody>().transform.position + offset + (playerVelocity * 7)), ref temp, .01f, 200, Time.deltaTime);
        }
        else
        {
            transform.position = player.GetComponent<Rigidbody>().transform.position + offset + (playerVelocity * 7);
        }
        
        centeredOnGW = false;
    }

}

