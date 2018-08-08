using UnityEngine;
using System.Collections;

public class DesktopSwipeDetector : SwipeDetector
{
    protected override void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
            GetSwipeStartPosition();
        else if (Input.GetMouseButtonUp(0))
            OnSwipeEnded();
        else
            SwipeDirection = Vector3.zero;
    }

    protected override void GetSwipeStartPosition()
    {
        touchStartPoint = touchEndPoint = Input.mousePosition;
    }
    protected override void GetSwipeEndPosition()
    {
        touchEndPoint = Input.mousePosition;
    }

}
