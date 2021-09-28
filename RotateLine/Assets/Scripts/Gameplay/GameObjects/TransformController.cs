using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction{
    None,
    Up,
    Down,
    Left,
    Right
}

public enum Corner{
    BottomLeft,
BottomRight,
TopLeft,
TopRight,
}

public class TransformController : MonoBehaviour
{
    public void SetPosition(Vector2 vector2)
    {
        transform.position = GameConstants.GameplayConstants.UnitDistance
         * new Vector3(vector2.x,vector2.y);
    }

    public void SetRotation(Direction direction)
    {
        transform.eulerAngles = direction.ToEulerAngle();
    }


    public void MoveTo(Vector2 vector2)
    {

    }

    public void RotateAround(Vector2 vector2)
    {

    }
}
