using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethod
{
    public static int StraightDistance(this Vector2 pos1, Vector2 pos2) 
    {
        return (int)( Mathf.Abs(pos1.x - pos2.x) + Mathf.Abs(pos1.y - pos2.y)); 
    }


    public static float PointToPosition(this int value) => value - 0.5f;
    public static Vector2 PointToPosition(this Vector2 v2) => new Vector2(v2.x - 0.5f, v2.y - 0.5f);
    public static Vector2 PointToPosition(this Vector2Int v2) => new Vector2(v2.x - 0.5f, v2.y -0.5f);
    public static int XAddOffset(this int value, Direction direction, int distance)
    {
        int result = value;
        switch (direction)
        {
            case Direction.Left:
                result = value - distance;
                break;
            case Direction.Right:
                result = value + distance;
                break;
        }
        return result;
    }

    public static int YAddOffset(this int value, Direction direction, int distance)
    {
        int result = value;
        switch (direction)
        {
            case Direction.Up:
                result = value + distance;
                break;
            case Direction.Down:
                result = value - distance;
                break;
        }
        return result;
    }

    public static Vector2Int AddOffset(this Vector2Int pos, Direction direction, int distance = 1)
    {
        return new Vector2Int((pos.x).XAddOffset(direction, distance)
        , (pos.y).YAddOffset(direction, distance));
    }

    public static Direction Rotate(this Direction direction, RotateDirection rotateDirection, int count)
    {
        if(rotateDirection == RotateDirection.Clockwise)
        {
            return direction.RotateClockwise(count);
        }
        else
        {
            return direction.RotateAntiClockwise(count);
        }
    }

    public static Direction RotateClockwise(this Direction direction, int count)
    {
        Direction result = Direction.None;
        switch (direction)
        {
            case Direction.Up:
                result = Direction.Right;
                break;
            case Direction.Down:
                result = Direction.Left;
                break;
            case Direction.Left:
                result = Direction.Up;
                break;
            case Direction.Right:
                result = Direction.Down;
                break;
        }
        return result;
    }

    public static Direction RotateAntiClockwise(this Direction direction, int count)
    {
        Direction result = Direction.None;
        switch (direction)
        {
            case Direction.Up:
                result = Direction.Left;
                break;
            case Direction.Down:
                result = Direction.Right;
                break;
            case Direction.Left:
                result = Direction.Down;
                break;
            case Direction.Right:
                result = Direction.Up;
                break;
        }
        return result;
    }

    public static Direction Flip(this Direction direction)
    {
        Direction result = Direction.None;
        switch (direction)
        {
            case Direction.Up:
                result = Direction.Down;
                break;
            case Direction.Down:
                result = Direction.Up;
                break;
            case Direction.Left:
                result = Direction.Right;
                break;
            case Direction.Right:
                result = Direction.Left;
                break;
        }
        return result;
    }

    public static Vector2Int RotateAroundPoint(this Vector2Int pos, Vector2Int point
        , RotateDirection direction, int count = 1)
    {
        Vector2 pointPosition = point.PointToPosition();
        Vector2 result = pos - pointPosition;
        int zEuler = (direction == RotateDirection.Clockwise ? 90 : -90) * count;
        result = Quaternion.Euler(0, 0, zEuler) * result;
        result = result + pointPosition;
        return new Vector2Int((int)result.x, (int)result.y);
    }

    public static Vector2 AddClockwiseRotation(this Vector2 vector2, Corner corner)
    {
        Vector2 result = vector2;
        switch (corner)
        {
            case Corner.BottomLeft:
                result = new Vector2(vector2.x, vector2.y - 1);
                break;
            case Corner.BottomRight:
                result = new Vector2(vector2.x + 1, vector2.y);
                break;
            case Corner.TopLeft:
                result = new Vector2(vector2.x - 1, vector2.y);
                break;
            case Corner.TopRight:
                result = new Vector2(vector2.x, vector2.y + 1);
                break;
        }
        return result;
    }

    public static Vector2 AddAntiClockwiseRotation(this Vector2 vector2, Corner corner)
    {
        Vector2 result = vector2;
        switch (corner)
        {
            case Corner.BottomLeft:
                result = new Vector2(vector2.x - 1, vector2.y);
                break;
            case Corner.BottomRight:
                result = new Vector2(vector2.x, vector2.y - 1);
                break;
            case Corner.TopLeft:
                result = new Vector2(vector2.x, vector2.y + 1);
                break;
            case Corner.TopRight:
                result = new Vector2(vector2.x + 1, vector2.y);
                break;
        }
        return result;
    }

    public static Vector3 ToEulerAngle(this Direction direction)
    {
        Vector3 result = Vector3.zero;
        switch (direction)
        {
            case Direction.Down:
                result = new Vector3(0, 0, 180);
                break;
            case Direction.Left:
                result = new Vector3(0, 0, 90);
                break;
            case Direction.Right:
                result = new Vector3(0, 0, 270);
                break;
        }
        return result;
    }

    public static Direction ToDirection(this Vector3 vector3)
    {
        Direction result = Direction.None;
        int z = ClampInside360(vector3.z);
        if (z < 45 || z > 315)
        {
            result = Direction.Up;
        }
        else if (z >= 45 && z <= 135)
        {
            result = Direction.Left;
        }
        else if (z >= 135 && z <= 225)
        {
            result = Direction.Down;
        }
        else
        {
            result = Direction.Right;
        }
        return result;
    }

    public static int ClampInside360(float angle)
    {
        int result = Mathf.RoundToInt(angle);
        while (result < 0)
        {
            result += 360;
        }
        result = result % 360;
        return result;
    }

    public static IEnumerable<T> GetColumn<T>(this T[,] array, int column)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            yield return array[i, column];
        }
    }

    public static IEnumerable<IEnumerable<T>> GetColumns<T>(this T[,] array)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            yield return array.GetColumn(i);
        }
    }

    public static IEnumerable<T> GetRow<T>(this T[,] array, int row)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            yield return array[row, i];
        }
    }

    public static IEnumerable<IEnumerable<T>> GetRows<T>(this T[,] array)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            yield return array.GetColumn(i);
        }
    }
}
