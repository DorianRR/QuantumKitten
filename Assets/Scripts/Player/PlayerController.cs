using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);
    public bool startedWhirl = false;
    public bool canSpawn = true;
    public float ImpulsePower = 20;
    public enum PlayerState {Moving,Bouncing,Stuck,MaxSpeed }
    private PlayerState currentState;

    private Vector3 playerDirection;
    private bool canBounce = true;

    private float bounceCD = 0.1f;

    void Start ()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
        currentState = PlayerState.Moving;
	}
	
	void Update ()
    {
        //if(!canBounce)
        //{
        //    bounceCD -= Time.deltaTime;
        //    if(bounceCD<=0f)
        //    {
        //        canBounce = true;
        //        bounceCD = 0.1f;
        //    }
        //}


        switch(currentState)
        {
            case PlayerState.Moving:
                Move();
                break;
            case PlayerState.Stuck:
                Stuck();
                break;
            case PlayerState.MaxSpeed:
                MaxSpeed();
                break;
            case PlayerState.Bouncing:
                Bouncing();
                break;
        }


		//Cat facing direction of movement
		playerDirection = GetComponent<Rigidbody>().velocity.normalized;
        gameObject.GetComponentInChildren<Rigidbody>().transform.rotation = Quaternion.LookRotation(playerDirection);
        
      

    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.transform.tag == "Bounce")
        {
            gameObject.transform.GetComponent<CapsuleCollider>().isTrigger = true;
            currentState = PlayerState.Bouncing;
            StartCoroutine(setState(PlayerState.Moving, 0.1f));
            Vector3 collisionPoint = coll.contacts[0].point;
            Vector3 reverseCollisionVector = -coll.contacts[0].normal;
            Vector3 collisionNormal = new Vector3();
            collisionPoint -= reverseCollisionVector;
            RaycastHit hitInfo;
            if(coll.collider.Raycast(new Ray(collisionPoint,reverseCollisionVector),out hitInfo, 4))
            {
                collisionNormal = hitInfo.normal;
            }
            Vector3 newVelocity = Vector3.Reflect(GetComponent<Rigidbody>().velocity, collisionNormal);
            GetComponent<Rigidbody>().velocity = newVelocity * 0.8f;
            gameObject.transform.GetComponent<CapsuleCollider>().isTrigger = false;
        }
        gameObject.transform.GetComponent<CapsuleCollider>().isTrigger = false;
    }

    public void setPlayerState(PlayerState newState)
    {
        currentState = newState;
    }

    public PlayerState getState()
    {
        return currentState;
    }

    private IEnumerator setState(PlayerState newState, float time)
    {
        yield return new WaitForSeconds(time);
        currentState = newState;
    }

    public void setWhirl(bool status)
    {
        startedWhirl = status;
    }

    public bool getWhirl()
    {
        return startedWhirl;
    }

    public void disableInput()
    {
        canSpawn = false;
    }

    public void enableInput()
    {
        canSpawn = true;
    }

    public void Launch()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Rigidbody>().velocity.normalized * 2, ForceMode.Impulse);

    }

    private void Move()
    {
        
    }
    private void MaxSpeed()
    {

    }

    private void Bouncing()
    {

    }
    private void Stuck()
    {

    }
}
