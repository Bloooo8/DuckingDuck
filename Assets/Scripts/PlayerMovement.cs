using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    float speed = 0.02f;
    float forceMultiplier = 100f;
    new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        rigidbody.AddForce(direction*forceMultiplier, ForceMode.Impulse);
    }

    public void MoveForward()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
