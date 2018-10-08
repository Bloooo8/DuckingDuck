using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    float forwardSpeed = 0.025f;
    float horizontalMovementAccuracy = 0.001f;
    float jumpForce = 100f;
    Vector3 positionBeforeMove;
    Vector3 target;
    Vector3 horizontalVelocity=Vector3.zero;
    float horizontalSpeed = 5.1f;
    new Rigidbody rigidbody;
    Coroutine coroutine;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 vector)
    {
        if (vector.y != 0f)
            MoveVertically(vector);
        else
            MoveHorizontally(vector);    
    }
    void MoveVertically(Vector3 vector)
    {
        rigidbody.AddForce(vector * jumpForce, ForceMode.Impulse);
    }
    void MoveHorizontally(Vector3 vector)
    {
        if(coroutine!=null)
            StopCoroutine(coroutine);
        coroutine=StartCoroutine(MoveHorizontallyCoroutine(vector));
    }
    IEnumerator MoveHorizontallyCoroutine(Vector3 vector)
    {
        positionBeforeMove = transform.position;
        target = positionBeforeMove + vector;
        while (IsFarEnough(target))
        {
            positionBeforeMove.z = transform.position.z;
            target = positionBeforeMove + vector;
            transform.position=Vector3.SmoothDamp(transform.position,target , ref horizontalVelocity,1f/horizontalSpeed);  
            yield return null;
        }
        transform.position = positionBeforeMove + vector;
    }
    bool IsFarEnough(Vector3 vector)
    {
        return Mathf.Abs(transform.position.x - target.x) > horizontalMovementAccuracy;
    }
    public void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed);
    }
}
