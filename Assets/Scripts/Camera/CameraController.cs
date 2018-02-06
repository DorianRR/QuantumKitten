using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public bool centeredOnGW = false;
    public float lerpRatio = 30f;

    private Vector3 offset;
    private Vector3 GWPosition;
    private Vector3 playerVelocity;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        GWPosition.z = -22f;

        playerVelocity = player.GetComponent<Rigidbody>().velocity;

        if (!centeredOnGW)
        {
            reCenter();
        }

        if (centeredOnGW)
        {
            transform.position = Vector3.Lerp(transform.position, GWPosition, 0.05f);
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 40, lerpRatio * Time.deltaTime);
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
        
        Vector3 temp = transform.GetComponent<Rigidbody>().velocity;
        transform.position = Vector3.SmoothDamp(transform.position,
            new Vector3
            ((player.GetComponent<Rigidbody>().transform.position.x + offset.x + (playerVelocity.x * 15)),
            (player.GetComponent<Rigidbody>().transform.position.y + offset.y + (playerVelocity.y * 7)),
            -20), ref temp, .01f, 150, Time.deltaTime);
        
        centeredOnGW = false;
    }
}

