using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockId
{
    None,
    PlayerLine,
    Ground,
}

public class Block
{
    public GridContainer gridContainer { get; private set; }
    public Grid grid { get; private set; }
    public virtual BlockId blockId => BlockId.None;
    public int x { get; protected set; }
    public int y { get; protected set; }
    public Vector2Int CurrentPosition => new Vector2Int(x,y);

    public Direction currentDirection { get; private set; }
    public Block(GridContainer gridContainer, int posX, int posY, Direction dir)
    {
        this.gridContainer = gridContainer;
        x = posX;
        y = posY;
        currentDirection = dir;
        TrySetGrid(posX, posY);
    }

    protected void TrySetGrid(int posX, int posY)
    {
        if (gridContainer.TryGetGrid(posX,posY, out Grid grid))
        {
            SetGrid(grid);
        }
    }

    public void SetGrid(Grid grid)
    {
        if (this.grid != null)
        {
            this.grid.RemoveBlock();
        }
        this.grid = grid;
        this.grid.SetBlock(this);
    }

    public virtual void SomethingTouchBorder()
    {

    }

    public virtual List<MovementCommand> GetMovementCommand(MovementCommand lastMovement)
    {
        List<MovementCommand> result = new List<MovementCommand>();
        if (lastMovement.MovementType == MovementType.Move)
        {
            result = GetMovementCommandByMove((MoveCommand)lastMovement);
        }else if (lastMovement.MovementType == MovementType.Move)
        {
            //result = GetMovementCommandByRotate((RotateCommand)lastMovement);
        }
        return result;
    }

    public virtual List<MovementCommand> GetMovementCommandByMove(MoveCommand lastMove)
    {
        List<MovementCommand> result = new List<MovementCommand>();
        Vector2Int lastPosition = lastMove.futurePosition;
        Direction moveDirection = lastMove.moveDirection;
        if (gridContainer.TryGetCloestBlockInRoute(lastPosition,
         moveDirection, out Block obstacle))
        {
            int distance = (int)Vector2.Distance(CurrentPosition, obstacle.CurrentPosition);
            if (distance > 1)
            {
                Vector2Int positionToGo = lastPosition.AddOffset(lastMove.moveDirection, distance - 1);
                if (gridContainer.TryGetGridByV2(positionToGo, out Grid grid))
                {
                    SetGrid(grid);
                    obstacle.SomethingTouchBorder();
                    MoveCommand nextMove = new MoveCommand(positionToGo, moveDirection, distance - 1);
                    result.AddRange(GetMovementCommandByMove(nextMove));
                }
            }
        }
        return result;
    }

    public virtual List<MovementCommand> GetMovementCommandByRotate
        (Vector2Int rotatePoint, RotateDirection rotateDirection)
    {
        List<MovementCommand> result = new List<MovementCommand>();
        if (gridContainer.TryGetCloestBlockAroundPoint(x, y
            , rotatePoint.x, rotatePoint.y
            , rotateDirection, out Block obstacle, out int index))
        {
            int rotateCount = index + 1;
            Direction fakeDirection = currentDirection.Flip();
            Vector2Int fakePosition = CurrentPosition.AddOffset(fakeDirection);
            Vector2Int nextPosition = fakePosition.RotateAroundPoint(rotatePoint, rotateDirection, rotateCount);
            Direction nextDirection = fakeDirection.Rotate(rotateDirection, rotateCount);

            obstacle.SomethingTouchBorder();
            RotateCommand rotateCommand = new RotateCommand(CurrentPosition,rotatePoint, rotateDirection,rotateCount);
            MoveCommand moveCommand = new MoveCommand(nextPosition, nextDirection, 0);
            result.Add(rotateCommand);
            result.AddRange(GetMovementCommandByMove(moveCommand));

        }
        return result;
    }
}

