using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockSpawnData
{
    private BlockId _blockId;
    private int _posX;
    private int _posY;
    private Direction _direction;

    public BlockId BlockId => _blockId;
    public Vector2 GetPosition => new Vector2(_posX,_posY);
    public Direction GetDirection => _direction;
}
