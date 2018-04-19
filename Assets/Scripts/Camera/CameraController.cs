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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, (((tempOrthSize - 10)) * 2f) - 500, (-(tempOrthSize - 10) * 2f) + 500), Mathf.Clamp(transform.position.y, ((tempOrthSize - 10) - 250), (250 - (tempOrthSize - 10))), -22);


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

    public void callHover(Vector3 loc)
    {
        StartCoroutine(highlightLocation(loc));
    }

    IEnumerator highlightLocation(Vector3 hoverLocation)
    {
        TutorialController tut = GameObject.Find("GameController").GetComponent<TutorialController>();
        Vector3 currentLocation = transform.position;
        tut.CallFadeSlow();

        Vector3 moveDirection = hoverLocation - currentLocation;
        float lerpFactor = 0.1f;
        while ((transform.position - hoverLocation).magnitude > 1f)
        {
            transform.position += (lerpFactor * moveDirection);
            Debug.Log(transform.position);
            yield return null;
        }
       // yield return new WaitForSeconds(3f);
        moveDirection = currentLocation - transform.position;
        lerpFactor = 0.1f;
        while ((transform.position - currentLocation).magnitude > 1f)
        {
            transform.position = Vector3.Lerp(hoverLocation, currentLocation, lerpFactor);
            lerpFactor += 0.1f;
            yield return null;
        }
        tut.CallFadeToNormalSpeed();
    }

}