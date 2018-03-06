using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormHole : MonoBehaviour {

	


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().animations.SetBool("hitBlackHole", true);
            other.gameObject.GetComponent<PlayerController>().animations.SetBool("slowSwim", false);
            other.gameObject.GetComponent<PlayerController>().animations.SetBool("fastSwim", false);
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;

            other.GetComponent<PlayerController>().disableInput();
            other.GetComponent<PlayerController>().setPlayerState(PlayerController.PlayerState.Stuck);
            other.GetComponent<SpawnDespawn>().ForcedDeSpawn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Vector3 forceDirection = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(forceDirection, ForceMode.Force);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {

        }
    }
}
