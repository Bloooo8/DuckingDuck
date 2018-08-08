using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    new Rigidbody rigidbody;
    public bool OnGround { get; private set; }
    DesktopSwipeDetector touchManager;
    float tolerableHorizontalVelocity = 0.2f;
    Vector3 swipeDirection;
    PlayerMovement playerMovement;


    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        touchManager = FindObjectOfType<DesktopSwipeDetector>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        GetPlayerInput();    
    }

    void GetPlayerInput()
    {
        swipeDirection = touchManager.SwipeDirection;
    }

    void FixedUpdate()
    {
        playerMovement.MoveForward();
        if (swipeDirection != Vector3.zero)
        {
            MovePlayer();
        }  
    }

    void MovePlayer()
    {
        if (CanMove())
        {
            playerMovement.Move(swipeDirection);
        }
    }
    bool CanMove()
    {
        return !IsMovingHorizontaly();
    }
    bool IsOnGround()
    {
        return true;
    }
    bool IsInAir()
    {
        return false;
    }
    bool IsMovingHorizontaly()
    {
        return Mathf.Abs(rigidbody.GetPointVelocity(Vector3.zero).x) > tolerableHorizontalVelocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsCollectable(other.gameObject))
        {
            other.GetComponent<ICollectable>().Collect();
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
