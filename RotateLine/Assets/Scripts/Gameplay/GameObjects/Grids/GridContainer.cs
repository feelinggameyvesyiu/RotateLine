using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class GridContainer
{
    public Grid[,] Grids { get; private set; }
    public int Column { get; private set; }
    public int Row { get; private set; }
    public PlayerLine PlayerLine;

    public GridContainer(int column, int row)
    {
        Column = column;
        Row = row;
        Grids = new Grid[column, row];
        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {
                Grids[i, j] = new Grid(this,i,j,null);
            }
        }
    }


    public bool Contains(int x, int y)
    {
        bool result = true;
        if (x < 0 || x >= Column)
        {
            DebugHelper.LogError($"x:{x} is < 0 or >= Column:{Column}");
            result = false;
        }
        if (y < 0 || y >= Row)
        {
            DebugHelper.LogError($"y:{y} is < 0 or >= Row:{Row}");
            result = false;
        }
        return result;
    }

    public bool TryGetGrid(int x, int y, out Grid grid)
    {
        bool result = false;
        if (Contains(x, y))
        {
            grid = Grids[x, y];
            result = true;
        }
        else
        {
            DebugHelper.LogWarning($"Cannot GetGrid with x:{x},y:{y}");
            grid = null;
        }
        return result;
    }

    public bool TryGetGridByV2(Vector2Int vector2,out Grid grid)
    {
        return TryGetGrid(vector2.x, vector2.y,out grid);
    }

    public List<Grid> GetAllGridsInRoute(int x, int y, Direction direction)
    {
        List<Grid> result = new List<Grid>();
        switch (direction)
        {
            case Direction.Up:
                result = Grids.GetColumn(x).Where(grid => grid.y > y)
                    .OrderBy(grid => grid.y).ToList();
                break;
            case Direction.Down:
                result = Grids.GetColumn(x).Where(grid => grid.y < y)
                    .OrderByDescending(grid => grid.y).ToList();
                break;
            case Direction.Left:
                result = Grids.GetRow(x).Where(grid => grid.x < x)
                    .OrderByDescending(grid => grid.x).ToList();
                break;
            case Direction.Right:
                result = Grids.GetRow(x).Where(grid => grid.x > x)
                    .OrderBy(grid => grid.x).ToList();
                break;
        }
        return result;
    }

    public bool TryGetCloestBlockInRoute(Vector2Int vector2, Direction direction, out Block block)
    {
        return TryGetCloestBlockInRoute(vector2.x, vector2.y, direction, out block);
    }

    public bool TryGetCloestBlockInRoute(int x, int y, Direction direction, out Block block)
    {
        block = null;
        List<Grid> grids = GetAllGridsInRoute(x,y,direction);
        if (grids.Any(grid => grid.block != null))
        {
            block = grids.First(grid => grid.block != null).block;
        }
        return block != null;
    }

    public List<Grid> GetAllGridsAroundPoint(int x, int y, int pointX, int pointY
        , RotateDirection direction)
    {
        List<Grid> result = new List<Grid>();
        if (pointX <= 0 || pointX >= Column)
        {
            DebugHelper.LogError($"Should not get grids around x:{pointX} Column{Column}");
        }
        if (pointY <= 0 || pointY >= Row)
        {
            DebugHelper.LogError($"Should not get grids around y:{pointY} Row{Row}");
        }
        Vector2Int pointPos = new Vector2Int(pointX, pointY);
        Vector2Int gridPos = new Vector2Int(x,y);
        for (int i = 0; i < 4; i++)
        {
            gridPos = gridPos.RotateAroundPoint(pointPos, direction);
            if (TryGetGridByV2(gridPos, out Grid grid))
            {
                result.Add(grid);
            }
        }
        return result;
    }

    public bool TryGetCloestBlockAroundPoint(int x, int y,int pointX, int pointY
        , RotateDirection direction, out Block block, out int index)
    {
        block = null;
        index = 0;
        List<Grid> grids = GetAllGridsAroundPoint(x, y, pointX, pointY, direction);
        if(grids.Any(grid => grid.block != null))
        {
            block = grids.First(grid => grid.block != null).block;
            index = grids.IndexOf(block.grid);
        }
        return block != null;
    }
}
