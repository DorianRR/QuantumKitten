using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complicated : MonoBehaviour
{

    public GameObject player;
    public bool centeredOnGW = false;
    public float lerpRatio = 50f;

    private Vector3 offset;
    private Vector3 GWPosition;
    private bool justBounced = false;

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
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 25, lerpRatio/2 * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -37.5f, 37.5f), Mathf.Clamp(transform.position.y, -19f, 19f), -22);

        }
        //else if(!centeredOnGW && justBounced)
        //{
        //    PauseCamera();
        //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -47f, 47f), Mathf.Clamp(transform.position.y, -23f, 23f), -22);

        //}
        else/* if(!centeredOnGW && !justBounced)*/
        {
            Vector3 playerVelocity = player.GetComponent<Rigidbody>().velocity.normalized;

            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 15, lerpRatio * Time.deltaTime);
            //transform.position = new Vector3((player.GetComponent<Rigidbody>().transform.position.x + offset.x + playerVelocity.x * 9f), (player.GetComponent<Rigidbody>().transform.position.y + offset.y + playerVelocity.y * 6f), offset.z);
            transform.position = (player.GetComponent<Rigidbody>().transform.position + offset);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -58f, 58f), Mathf.Clamp(transform.position.y, -30f, 30f), -22);

        }

    }

    public void CenterOnSpawnedGW(Vector3 location)
    {
        centeredOnGW = true;

        GWPosition = location;
    }


    public void PauseCamera()
    {
        StartCoroutine(BounceCooldown());
    }

  

    public bool getCenteredOnGW()
    {
        return centeredOnGW;
    }

    public void setCenteredOnGW(bool set)
    {
        centeredOnGW = set;
    }

    public bool getJustBounced()
    {
        return justBounced;
    }

    public void setJustBounced(bool set)
    {
        justBounced = set;
    }

  

    IEnumerator BounceCooldown()
    {
       
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(reCenter());
    }
    IEnumerator reCenter()
    {
        //Vector3 playerVelocity = player.GetComponent<Rigidbody>().velocity.normalized;

        //Vector3 temp = transform.GetComponent<Rigidbody>().velocity;
        //transform.position = Vector3.SmoothDamp(transform.position,
        //    new Vector3
        //    ((player.GetComponent<Rigidbody>().transform.position.x + offset.x),
        //    (player.GetComponent<Rigidbody>().transform.position.y + offset.y),
        //    -22), ref temp, .03f, 150, Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        justBounced = false;

    }
}