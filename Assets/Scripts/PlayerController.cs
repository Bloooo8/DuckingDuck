using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    new Rigidbody rigidbody;
    public bool OnGround { get; private set; }
    float speed = 0.02f;
    float forceMultiplier = 100f;
    Vector3 jumpForce;
    Vector3 downForce;
    Vector3 rightForce;
    Vector3 leftForce;
    TouchManager touchManager;
   


    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        touchManager = FindObjectOfType<TouchManager>();
       
    }
    public void Update()
    {
        InitializeForces();
        MoveForward();
        CheckIfOnGround();
        DoMove();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (CheckIfCollectable(other))
        {
            other.GetComponent<ICollectable>().Collect();
        }
    }
   
    void InitializeForces()
    {
        jumpForce = new Vector3(0f, forceMultiplier, forceMultiplier / 10f);
        downForce = new Vector3(0f, -forceMultiplier, forceMultiplier / 10f);
        rightForce = Vector3.right * forceMultiplier;
        leftForce = Vector3.left * forceMultiplier;
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * speed);
    }
    void CheckIfOnGround()
    {
        if (transform.position.y < 0.140)
            OnGround = true;
        else
            OnGround = false;
    }

    void DoMove()
    {
        SWIPE swipe = touchManager.SwipeDirection;
        if (swipe != SWIPE.NULL && OnGround)
        {
            switch (swipe)
            {
                case SWIPE.UP:
                    rigidbody.AddForce(jumpForce, ForceMode.Impulse);
                    break;
                case SWIPE.DOWN:
                    rigidbody.AddForce(downForce, ForceMode.Impulse);
                    break;
                case SWIPE.RIGHT:
                    rigidbody.AddForce(rightForce, ForceMode.Impulse);
                    break;
                case SWIPE.LEFT:
                    rigidbody.AddForce(leftForce, ForceMode.Impulse);
                    break;
            }
        }
    }

  
    bool CheckIfCollectable(Collider collider)
    {
        if (IsCollectable(collider.gameObject))
        {
            return true;
        }          
        else
        {
            return false;
        }          
    }

    bool IsCollectable(GameObject item)
    {
        if (item.GetComponent<ICollectable>() != null)
            return true;
        else
            return false;
    }
}
