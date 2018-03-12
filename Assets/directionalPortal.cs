using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalPortal : MonoBehaviour
{

    public GameObject exitPortal;
    Vector3 savedVelocity;
    public Vector3 exitDirection;
    public float moveTime;
    public bool destroyObject;
    public GameController.Level changeLevel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerController pC = other.GetComponent<PlayerController>();
            if (pC.getState() != PlayerController.PlayerState.Teleporting)
            {
                pC.setPlayerState(PlayerController.PlayerState.Teleporting);
                savedVelocity = other.GetComponent<Rigidbody>().velocity;
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.transform.position += new Vector3(0, 0, 100);
                StartCoroutine(WaitABit(other, other.transform.position, exitPortal.transform.position + new Vector3(0, 0, 100)));

            }
            else
            {

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (other.GetComponent<PlayerController>().getState() == PlayerController.PlayerState.Teleporting)
            {
                other.GetComponent<PlayerController>().setPlayerState(PlayerController.PlayerState.Moving, moveTime);
            }
        }
    }

    private IEnumerator WaitABit(Collider other, Vector3 source, Vector3 destination)
    {
        float startTime = Time.time;
        while (Time.time < startTime + moveTime)
        {
            other.transform.position = Vector3.Lerp(source, destination, (Time.time - startTime) / moveTime);
            yield return null;
        }
        other.transform.position -= new Vector3(0, 0, 100);
        other.GetComponent<Rigidbody>().velocity = exitDirection.normalized * savedVelocity.magnitude;
        if(destroyObject)
        {
            Destroy(exitPortal.transform);
        }
            GameController.instance.changeLevel(changeLevel);
    }
}
