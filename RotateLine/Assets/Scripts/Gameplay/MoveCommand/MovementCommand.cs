using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    None,
    Move,
    Rotate,
    Stop,
    OutOfBorder,
}

public class MovementCommand
{
    public int originalPosX { get; private set; }
    public int originalPosY { get; private set; }
    public Vector2Int originalPosition => new Vector2Int(originalPosX, originalPosY);
    public virtual MovementType MovementType => MovementType.None;

    public MovementCommand(int x, int y)
    {
        originalPosX = x;
        originalPosY = y;
    }

    public MovementCommand(Vector2Int v2)
    {
        originalPosX = v2.x;
        originalPosY = v2.y;
    }

    public virtual void ApplyOn(Block block)
    {

    }
}
