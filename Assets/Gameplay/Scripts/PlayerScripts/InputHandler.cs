using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    static Dir curDir = Dir.None;
    bool movedPhase;
    Vector2 touchPos, deltaPos;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            movedPhase = true;
            touchPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            movedPhase = false;
            touchPos = Vector2.zero;
            deltaPos = Vector2.zero;
        }

        curDir = CheckDir();


        // Smoother Input (Smartphone Environment only)
        //if (Input.touchCount == 1)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //    {
        //        curDir = CheckDir(Input.GetTouch(0));
        //    }

        //}
    }   

    private Dir CheckDir(/*Touch touch*/)
    {
        //if (touch.phase != TouchPhase.Moved)
        //    return Dir.None;
        //if (touch.deltaPosition.magnitude < Constants.INPUTTHRESHOLD)
        //    return Dir.None;
        if (!movedPhase)
            return Dir.None;
        deltaPos = (Vector2)Input.mousePosition - touchPos;
        if (deltaPos.magnitude < Constants.INPUTTHRESHOLD)
        {
            return Dir.None;
        }
        float x = deltaPos.x;
        float y = deltaPos.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
                return Dir.Right;
            else
                return Dir.Left;
        }
        else
        {
            if (y > 0)
                return Dir.Up;
            else
                return Dir.Down;
        }
        //
    }

    public static Dir GetCurDir()
    {
        return curDir;
    }

    public static void ResetCurDir()
    {
        curDir = Dir.None;
    }    
}

public enum Dir
{
    Up,
    Down,
    Left,
    Right,
    None
}
