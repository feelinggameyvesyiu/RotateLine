using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : MovementCommand
{
    public Direction moveDirection { get; private set; }
    public int distance { get; private set; }
    public Vector2Int futurePosition => originalPosition.AddOffset(moveDirection, distance);
    public override MovementType MovementType => MovementType.Move;

    public MoveCommand(int x, int y, Direction direction, int dist) : base(x, y)
    {
        moveDirection = direction;
        distance = dist;
    }

    public MoveCommand(Vector2Int v2, Direction direction, int dist) : base(v2)
    {
        moveDirection = direction;
        distance = dist;
    }

    public override void ApplyOn(Block block)
    {
        base.ApplyOn(block);
        GridContainer gridContainer = block.gridContainer;
        if (gridContainer.TryGetCloestBlockInRoute(originalPosX,
             originalPosY, moveDirection, out Block obstacle))
        {
            int distance = (int)Vector2.Distance(block.CurrentPosition, obstacle.CurrentPosition);
            if (distance > 1)
            {
                Vector2Int positionToGo = block.CurrentPosition.AddOffset(moveDirection, distance - 1);
                if (gridContainer.TryGetGridByV2(positionToGo, out Grid grid))
                {
                    block.SetGrid(grid);
                    obstacle.SomethingTouchBorder();
                    // move = new MoveCommand(positionToGo, moveDirection);
                    //move.ApplyOn(block);
                }
            }
        }
    }
}
