using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportEffect : MonoBehaviour
{

    private GameObject[] exitHoles;
    void Start()
    {
        exitHoles = GameObject.FindGameObjectsWithTag("ExitHole");
    }


    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {


            int holeNumber = Random.Range(0, exitHoles.Length);
            collision.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Vector3 newDirection = calculateTrajectory(exitHoles[holeNumber].transform.position);
            newDirection.Normalize();
            collision.transform.position += new Vector3(0, 0, 100);
            StartCoroutine(WaitABit(collision.gameObject, newDirection, collision.transform.position,exitHoles[holeNumber].transform.position + new Vector3(0,0,100)));
        }
    }

    private Vector3 calculateTrajectory(Vector3 fromPosition)
    {
        bool foundVector = false;
        Vector3 newDirection = new Vector3();
        while (!foundVector)
        {
            newDirection = Random.onUnitSphere.normalized;
            newDirection.z = 0;
            if (!Physics.Raycast(fromPosition, newDirection, 5))
            {
                foundVector = true;
            }

        }
        return newDirection;
    }


    private IEnumerator WaitABit(GameObject other, Vector3 direction, Vector3 source, Vector3 destination)
    {
        other.GetComponent<PlayerController>().animations.SetBool("hitBlackHole", false);
        float startTime = Time.time;
        while (Time.time < startTime + 2.0f)
        {
            other.transform.position = Vector3.Lerp(source, destination, (Time.time - startTime) / 2.0f);
            yield return null;
        }
        popOut(other, direction);
        
    }

    private void popOut(GameObject collision, Vector3 newDirection)
    {
        collision.transform.position += new Vector3(0, 0, -100);
        collision.transform.GetComponent<Rigidbody>().AddForce(newDirection * 20, ForceMode.Impulse);

        collision.transform.GetComponent<PlayerController>().setPlayerState(PlayerController.PlayerState.Moving);
    }
}