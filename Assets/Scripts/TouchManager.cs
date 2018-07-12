using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

    Vector2 touchStartPoint;
    Vector2 touchEndPoint;
    Vector2 minSwipeLength;
    Vector2 percentOfScreenSize = new Vector2(0.2f, 0.2f);
    Vector2 swipeLength = new Vector2();
    public SWIPE SwipeDirection { get; private set; }


    public void Start()
    {
        minSwipeLength = new Vector2(Screen.width * percentOfScreenSize.x, Screen.height * percentOfScreenSize.y);
        Debug.Log(minSwipeLength);
    }
    public void Update()
    {
        SwipeDirection = SWIPE.NULL;
        CheckMouseInput();
        CheckTouchInput();

    }
    void CheckMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseStarted();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnMouseEnded();
        }

    }
    void CheckTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                OnTouchStarted();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                OnTouchEnded();
            }
        }
    }

    void OnMouseStarted()
    {
        touchStartPoint = touchEndPoint = Input.mousePosition;
        Debug.Log("Touch started: " + touchStartPoint);
    }

    private void OnMouseEnded()
    {
        touchEndPoint = Input.mousePosition;
        Debug.Log("Touch ended: " + touchEndPoint);
        CalculateSwipeLength();
        if (CheckIfSwipe())
        {
            CheckSwipeDirection();
            Debug.Log("Swipe detected, " + " direction: " + SwipeDirection);
        }
        else
        {
            Debug.Log("Swipe not detected");
            SwipeDirection = SWIPE.NULL;
        }
    }
    void OnTouchStarted()
    {
        touchStartPoint = touchEndPoint = Input.GetTouch(0).position;
        Debug.Log("Touch started");
    }
    void OnTouchEnded()
    {
        touchEndPoint = Input.GetTouch(0).position;
        Debug.Log("Touch ended");
        CalculateSwipeLength();
        if (CheckIfSwipe())
        {
            CheckSwipeDirection();
            Debug.Log("Swipe detected, " + " direction: " + SwipeDirection);
        }
        else
        {
            Debug.Log("Swipe not detected");
            SwipeDirection = SWIPE.NULL;
        }
    }
    void CheckSwipeDirection()
    {
        if (Mathf.Abs(swipeLength.x) > Mathf.Abs(swipeLength.y))
        {
            if (swipeLength.x > 0)
            {
                SwipeDirection = SWIPE.RIGHT;
            }
            else
            {
                SwipeDirection = SWIPE.LEFT;
            }
        }
        else
        {
            if (swipeLength.y > 0)
            {
                SwipeDirection = SWIPE.UP;
            }
            else
            {
                SwipeDirection = SWIPE.DOWN;
            }
        }
    }

    void CalculateSwipeLength()
    {
        swipeLength.x = touchEndPoint.x - touchStartPoint.x;
        swipeLength.y = touchEndPoint.y - touchStartPoint.y;
    }

    bool CheckIfSwipe()
    {
        return Mathf.Abs(swipeLength.x) > minSwipeLength.x || Mathf.Abs(swipeLength.y) > minSwipeLength.y;
    }
}
public enum SWIPE { NULL, UP, RIGHT, DOWN, LEFT }
