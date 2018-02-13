using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float lerpRatio;

    private bool centeredOnGW = false;
    private Vector3 offset;
    private Vector3 GWPosition;

    void Start()
    {
        offset = transform.position - player.transform.position;

        transform.position = (player.GetComponent<Rigidbody>().transform.position + offset);
    }

    void LateUpdate()
    {
        if (centeredOnGW)
        {
            GWPosition.z = -22f;

            transform.position = Vector3.Lerp(transform.position, GWPosition, lerpRatio/2 * Time.deltaTime);
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 25, lerpRatio/5 * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -37.5f, 37.5f), Mathf.Clamp(transform.position.y, -19f, 19f), -22);
        }
        else
        {
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 15, lerpRatio/5 * Time.deltaTime);
            transform.position = (player.GetComponent<Rigidbody>().transform.position + offset);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -58f, 58f), Mathf.Clamp(transform.position.y, -30f, 30f), -22);
        }
    }

    public void CenterOnSpawnedGW(Vector3 location)
    {
        centeredOnGW = true;
        GWPosition = location;
    }

    public bool getCenteredOnGW()
    {
        return centeredOnGW;
    }

    public void setCenteredOnGW(bool set)
    {
        centeredOnGW = set;
    }

}