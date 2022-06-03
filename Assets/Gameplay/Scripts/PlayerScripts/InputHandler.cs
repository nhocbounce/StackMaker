using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    static Dir curDir = Dir.None;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                curDir = CheckDir(Input.GetTouch(0));
            }

        }
    }   

    private Dir CheckDir(Touch touch)
    {
        //not moved
        if (touch.phase != TouchPhase.Moved)
            return Dir.None;
        if (touch.deltaPosition.magnitude < Constants.INPUTTHRESHOLD)
            return Dir.None;
        float x = touch.deltaPosition.x;
        float y = touch.deltaPosition.y;

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
