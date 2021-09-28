using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid
{
    public GridContainer gridContainer { get; private set; }
    public int x { get; private set; }
    public int y { get; private set; }
    public Vector2Int CurrentPosition => new Vector2Int(x,y);
    public Block block { get; private set; }
    public Grid(GridContainer gridContainer, int posX, int posY, Block block)
    {
        this.gridContainer = gridContainer;
        x = posX;
        y = posY;
        this.block = block;
    }

    public void SetBlock(Block block)
    {
        this.block = block;
    }

    public void RemoveBlock()
    {
        block = null;
    }

    //public List<MovementCommand> MovementThrough(List<MovementCommand> movements)
    //{
    //    List<MovementCommand> result = movements;
    //    if (block == null)
    //    {
    //        MovementCommand lastMovement = movements.Last();

    //        switch (lastMovement.MovementType)
    //        {
    //            case MovementType.Move:
    //                MoveCommand lastMove = (MoveCommand)lastMovement;
    //                Direction moveDir = lastMove.moveDirection;
    //                if (TryGetAdjacentGrid(moveDir, out Grid nextGrid))
    //                {
    //                    result = nextGrid.MovementThrough(movements);
    //                }
    //                else
    //                {
    //                    Vector2 nextPosition = new Vector2(x, y).AddOffset(moveDir);
    //                    // stop
    //                    result.Add(new MovementCommand(nextPosition));
    //                }
    //                break;
    //            case MovementType.Rotate:
    //                RotateCommand lastRotate = (RotateCommand)lastMovement;
    //                RotateDirection rotateDir = lastRotate.rotateDirection;
    //                if (TryGetAdjacentGrid(lastRotate, out nextGrid))
    //                {
    //                    result = nextGrid.MovementThrough(movements);
    //                }
    //                else
    //                {
    //                    DebugHelper.LogError($"{x},{y} Try rotate around {lastRotate.PointPosition} Fail  ");
    //                }

    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //    else
    //    {
    //        result = block.MovementThrough(movements);
    //    }
    //    return result;
    //}

    public bool TryGetAdjacentGrid(Direction direction, out Grid grid)
    {
        return gridContainer.TryGetGridByV2(CurrentPosition.AddOffset(direction), out grid);
    }

    public bool TryGetAdjacentGrid(RotateCommand rotateCommand, out Grid grid)
    {
        return gridContainer.TryGetGridByV2(
            CurrentPosition.RotateAroundPoint(
            rotateCommand.PointIndex, rotateCommand.rotateDirection), out grid);
    }
}



