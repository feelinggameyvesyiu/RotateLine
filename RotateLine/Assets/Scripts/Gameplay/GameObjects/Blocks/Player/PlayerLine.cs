using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : Block
{
    public override BlockId blockId => BlockId.PlayerLine;

    public PlayerLine(GridContainer gridContainer, int posX, int posY, Direction dir)
     : base(gridContainer, posX, posY, dir)
    {

    }

    public void RunMoveCommand(MoveCommand moveCommand)
    {
        /*Vector2 v2 = moveCommand.distance * CurrentPosition.AddOffset(moveCommand.moveDirection);
        if (gridContainer.TryGetGridByV2(v2, out Grid grid))
        {
            SetGrid(grid);
        }*/


    }



}


