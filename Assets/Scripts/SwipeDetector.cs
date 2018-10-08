using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public abstract class SwipeDetector : MonoBehaviour
{

    protected Vector2 touchStartPoint;
    protected Vector2 touchEndPoint;
    protected Vector2 minSwipeLength;
    protected Vector2 percentOfScreenSize = new Vector2(0.15f, 0.15f);
    protected Vector2 swipeLength = new Vector2();
    public Vector3 SwipeDirection { get; protected set; }
    public UnityAction OnSwipeDetected;

    protected void Start()
    {
        minSwipeLength = new Vector2(Screen.width * percentOfScreenSize.x, Screen.width * percentOfScreenSize.y);
        SwipeDirection = Vector3.zero;
    }
    protected void Update()
    {
        CheckInput();
    }

    protected virtual void CheckInput()
    {
        GetSwipeStartPosition();
        OnSwipeEnded();
    }
    protected virtual void GetSwipeStartPosition()
    {
    }
    protected void OnSwipeEnded()
    {
        GetSwipeEndPosition();
        CalculateSwipeLength();
        if (IsSwipeLongEnough())
        {
            CheckSwipeDirection();
            OnSwipeDetected();
            Debug.Log("Swipe detected, " + " direction: " + SwipeDirection);
        }
        else
        {
            Debug.Log("Swipe not detected");
            SwipeDirection = Vector3.zero;
        }
    }
    protected virtual void GetSwipeEndPosition()
    {
    }

    void CalculateSwipeLength()
    {
        swipeLength.x = touchEndPoint.x - touchStartPoint.x;
        swipeLength.y = touchEndPoint.y - touchStartPoint.y;
    }

    bool IsSwipeLongEnough()
    {
        return Mathf.Abs(swipeLength.x) > minSwipeLength.x || Mathf.Abs(swipeLength.y) > minSwipeLength.y;
    }

    void CheckSwipeDirection()
    {
        if (Mathf.Abs(swipeLength.x) > Mathf.Abs(swipeLength.y))
        {
            if (swipeLength.x > 0)
            {
                SwipeDirection = Vector3.right;
            }
            else
            {
                SwipeDirection = Vector3.left;
            }
        }
        else
        {
            if (swipeLength.y > 0)
            {
                SwipeDirection = Vector3.up;
            }
            else
            {
                SwipeDirection = Vector3.down;
            }
        }
    }
}
