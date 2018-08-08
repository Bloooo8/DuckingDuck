using UnityEngine;
using System.Collections;

public class MobileSwipeDetector : SwipeDetector
{
    protected override void CheckInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                GetSwipeStartPosition();
            }
            else
            {
                OnSwipeEnded();
            }
        }
        else
            SwipeDirection = Vector3.zero;
    }

    protected override void GetSwipeStartPosition()
    {
        touchStartPoint = touchEndPoint = Input.GetTouch(0).position;
    }
    protected override void GetSwipeEndPosition()
    {
        touchEndPoint = Input.GetTouch(0).position;
    }
}
