using System.Collections;
using System.Collections.Generic;
using UnityEngine.Timeline;
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
        transform.position = (player.GetComponent<Rigidbody>().transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, -22f);

        offset = transform.position - player.transform.position;


    }

    void LateUpdate()
    {
        transform.position = (player.GetComponent<Rigidbody>().transform.position + offset);
        //CAMERA BOUNDS
        float temp = ((Mathf.Abs(player.GetComponent<Rigidbody>().velocity.magnitude) - 10f) / (25f - 10f)) * 20f;
        temp = Mathf.Clamp(temp, 18f, 25f);
        gameObject.GetComponent<Camera>().orthographicSize =
            Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, temp, lerpRatio / 5 * Time.deltaTime);
        float tempOrthSize = gameObject.GetComponent<Camera>().orthographicSize;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, (((tempOrthSize - 10)) * 2f) - 470, (-(tempOrthSize - 10) * 2f) + 470), Mathf.Clamp(transform.position.y, ((tempOrthSize - 10) - 250), (250 - (tempOrthSize - 10))), -22);


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