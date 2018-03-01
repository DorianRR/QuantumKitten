using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);
    public bool startedWhirl = false;
    public bool canSpawn = true;
    public float ImpulsePower = 20;
    public Animator animations;

    public enum PlayerState {Moving,Bouncing,Stuck,MaxSpeed }
    private PlayerState currentState;

    private Vector3 playerDirection;
    private bool canBounce = true;

    private float bounceCD = 0.1f;
    private bool reversed = false;
    private float spinCountDown;


    void Start ()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
        animations = gameObject.GetComponentInChildren<Animator>();
        currentState = PlayerState.Moving;
	}
	
	void Update ()
    {
        
        
        
        //handles bounce cooldown
        if(!canBounce)
        {
            bounceCD -= Time.deltaTime;
            if(bounceCD<=0f)
            {
                animations.SetBool("justBounced", false);

                canBounce = true;
                bounceCD = 0.1f;
            }
        }

     

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

        //for spin anim
        spinCountDown -= Time.deltaTime;
        if (spinCountDown <= 0f)
        {
            animations.SetBool("hitAsteroid", false);
        }
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.transform.tag == "Bounce" && currentState == PlayerState.Moving)
        {

            canBounce = false;

            currentState = PlayerState.Bouncing;
            StartCoroutine(setState(PlayerState.Moving, 0.1f));

            Vector3 collisionPoint = coll.contacts[0].point;
            Vector3 reverseCollisionVector = -coll.contacts[0].normal;
            Vector3 collisionNormal = new Vector3();
            collisionPoint -= reverseCollisionVector;
            RaycastHit hitInfo;
            if(coll.collider.Raycast(new Ray(collisionPoint,reverseCollisionVector),out hitInfo, 1))
            {
                collisionNormal = hitInfo.normal;
            }
            Vector3 newVelocity = Vector3.Reflect(GetComponent<Rigidbody>().velocity, collisionNormal);
            GetComponent<Rigidbody>().velocity = newVelocity * 0.8f;

        }

        else if(coll.transform.tag == "Asteroid")
        {
            spinCountDown = 0.5f;
            animations.SetBool("hitAsteroid", true);
        }
        else if(coll.transform.tag == "WormHole")
        {
            animations.SetBool("hitBlackHole", true);
        }
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

    //public void setWhirl(bool status)
    //{
    //    startedWhirl = status;
    //}

    //public bool getWhirl()
    //{
    //    return startedWhirl;
    //}

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

    public void bounceAnimationFinished()
    {
        animations.SetBool("justBounced", false);
    }

    public void setReversed(bool set)
    {
        reversed = set;
    }

    private void Move()
    {
        //protect us from insane speed, set which moving animation we're using
        if (GetComponent<Rigidbody>().velocity.magnitude > 50)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.75f;
        }
        else if (GetComponent<Rigidbody>().velocity.magnitude > 20 && GetComponent<Rigidbody>().velocity.magnitude < 50)
        {
            setPlayerState(PlayerState.MaxSpeed);

        }
        else
        {
            animations.SetBool("fastSwim", false);
            animations.SetBool("slowSwim", true);

        }


        //Cat facing direction of movement used for anim
        playerDirection = GetComponent<Rigidbody>().velocity.normalized;
        gameObject.GetComponentInChildren<Rigidbody>().transform.rotation = Quaternion.LookRotation(playerDirection); //transform.rotation =  Quaternion.LookRotation(playerDirection);

        //I don't know what  happened, but this became necessary again. QQ
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);

    }
    private void MaxSpeed()
    {
        animations.SetBool("fastSwim", true);
        animations.SetBool("slowSwim", false);

        
        //Cat facing direction of movement used for anim
        playerDirection = GetComponent<Rigidbody>().velocity.normalized;
        gameObject.GetComponentInChildren<Rigidbody>().transform.rotation = Quaternion.LookRotation(playerDirection); //transform.rotation =  Quaternion.LookRotation(playerDirection);

        //I don't know what  happened, but this became necessary again. QQ
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
    }

    private void Bouncing()
    {
        animations.SetBool("justBounced", true);

    }
    private void Stuck()
    {
        if (reversed)
        {
            playerDirection = GetComponent<Rigidbody>().velocity.normalized;

            gameObject.GetComponentInChildren<Rigidbody>().transform.rotation = Quaternion.LookRotation(-playerDirection); //transform.rotation =  Quaternion.LookRotation(playerDirection);
        }
    }
}
