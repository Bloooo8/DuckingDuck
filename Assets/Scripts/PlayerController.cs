using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    Rigidbody rb;
    public bool OnGround { get; private set; }
    DesktopSwipeDetector touchManager;
    float tolerableHorizontalVelocity = 0.2f;
    Vector3 swipeDirection;
    PlayerMovement playerMovement;


    public void Start()
    {
        InitializeFields();
        touchManager.OnSwipeDetected += GetPlayerInput;
        touchManager.OnSwipeDetected += MovePlayer;
    }

    void InitializeFields()
    {
        rb = GetComponent<Rigidbody>();
        touchManager = FindObjectOfType<DesktopSwipeDetector>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void GetPlayerInput()
    {
        swipeDirection = touchManager.SwipeDirection;
    }

    void MovePlayer()
    {
        if (swipeDirection != Vector3.zero && CanMove())
        {
            playerMovement.Move(swipeDirection);
        }
    }
    bool CanMove()
    {
        return !IsMovingHorizontaly();
    }
    
    bool IsMovingHorizontaly()
    {
        return Mathf.Abs(rb.GetPointVelocity(Vector3.zero).x) > tolerableHorizontalVelocity;
    }

    void FixedUpdate()
    {
        playerMovement.MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsCollectable(other.gameObject))
        {
            other.GetComponent<ICollectable>().Collect();
        }
        else if (IsEnemy(other.gameObject))
        {
            other.GetComponent<IEnemy>().OnCollision();
        }
    }

    bool IsCollectable(GameObject item)
    {
        if (item.GetComponent<ICollectable>() != null)
            return true;
        else
            return false;
    }

    bool IsEnemy(GameObject item)
    {
        if (item.GetComponent<IEnemy>() != null)
            return true;
        else
            return false;
    }

}
