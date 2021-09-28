using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public partial class GridContainer
{
    public class Ground : Block
    {
        public override BlockId blockId => BlockId.Ground;

        public int hp { get; private set; }
        public Ground(GridContainer gridContainer, int posX, int posY, Direction dir, int healthPoint) 
        : base(gridContainer, posX, posY, dir)
        {
            hp = healthPoint;

        }

        public void DeductHp(int value = 1)
        {
            hp -= value;
            if(value == 0)
            {
                grid.RemoveBlock();
            }
        }

        public override void SomethingTouchBorder()
        {
            DeductHp();
            base.SomethingTouchBorder();
        }

        //public override List<MovementCommand> MoveThrough(List<MovementCommand> movements)
        //{
        //    MovementCommand lastMove = movements.Last();
        //    switch (lastMove.MovementType)
        //    {
        //        case MovementType.None:
        //            break;
        //        case MovementType.Move:
        //            break;
        //        case MovementType.Rotate:
        //            break;
        //        default:
        //            break;
        //    }
        //    return movements;

        //    List<MovementCommand> MoveTouchBorder()
        //    {
        //        MoveCommand move = (MoveCommand)lastMove;

        //        List<MovementCommand> result = new List<MovementCommand>();
        //        DeductHp();
        //        if (hp == 0)
        //        {
        //            int offsetX = x.XAddOffset(move.moveDirection);
        //            int offsetY = y.XAddOffset(move.moveDirection);
        //            if (gridContainer.Contains(offsetX, offsetY))
        //            {

        //            }
        //            result = gridContainer.Grids[offsetX, offsetY].MoveThrough(movements);
        //        }
        //        return result;
        //    }
        //}

    }

}

