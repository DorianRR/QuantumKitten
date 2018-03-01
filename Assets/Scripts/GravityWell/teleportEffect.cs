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
            collision.transform.position = exitHoles[holeNumber].transform.position + new Vector3(0, 0, 205);
            StartCoroutine(WaitABit(collision.gameObject, newDirection));
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

    private IEnumerator WaitABit(GameObject collision, Vector3 direction)
    {
        collision.GetComponent<PlayerController>().animations.SetBool("hitBlackHole", false);
        collision.GetComponent<PlayerController>().setReversed(false);
        yield return new WaitForSeconds(2f);
        
        popOut(collision, direction);
    }

    private void popOut(GameObject collision, Vector3 newDirection)
    {
        collision.transform.position += new Vector3(0, 0, -205);
        collision.transform.GetComponent<Rigidbody>().AddForce(newDirection * 20, ForceMode.Impulse);
        collision.transform.GetComponent<PlayerController>().enableInput();
<<<<<<< HEAD
        
=======
        collision.transform.GetComponent<PlayerController>().setPlayerState(PlayerController.PlayerState.Moving);
>>>>>>> bouncingoffthewalls
    }
}