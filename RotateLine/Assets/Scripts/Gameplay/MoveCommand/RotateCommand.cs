using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateDirection{
    Clockwise,
    AntiClockwise,
}

public class RotateCommand : MovementCommand
{
    public RotateDirection rotateDirection { get; private set; }
    public override MovementType MovementType => MovementType.Rotate;

    public int pointIndexX { get; private set; }
    public int pointIndexY { get; private set; }
    public Vector2Int PointIndex => new Vector2Int(pointIndexX, pointIndexY);

    public int rotateCount { get; private set; }


    public float pointPositionX => pointIndexX - 0.5f;
    public float pointPositionY => pointIndexY - 0.5f;
    public Vector2 PointPosition => new Vector2(pointPositionX, pointPositionY);

    public RotateCommand(int x, int y,int pointX, int pointY, RotateDirection rotateDir, int count) : base(x, y)
    {
        this.rotateDirection = rotateDir;
        pointIndexX = pointX;
        pointIndexY = pointY;
        rotateCount = count;
    }

    public RotateCommand(Vector2Int position, Vector2Int point, RotateDirection rotateDir, int count) : base(position)
    {
        this.rotateDirection = rotateDir;
        pointIndexX = point.x;
        pointIndexY = point.y;
        rotateCount = count;
    }

    public override void ApplyOn(Block block)
    {
        base.ApplyOn(block);
        GridContainer gridContainer = block.gridContainer;
        if (gridContainer.TryGetCloestBlockAroundPoint(originalPosX, originalPosY
            , pointIndexX,pointIndexY, rotateDirection, out Block obstacle, out int index))
        {

        }
    }
}
