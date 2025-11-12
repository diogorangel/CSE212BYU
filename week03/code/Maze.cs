using System.Collections.Generic;
using System;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // Helper method to consolidate movement logic
    private void Move(int index, int deltaX, int deltaY)
    {
        var currentCoord = new ValueTuple<int, int>(_currX, _currY);
        
        // Check if the current location is in the map and if movement is allowed
        // If TryGetValue fails, it means we are trying to move outside the defined maze boundaries, which is a wall.
        if (_mazeMap.TryGetValue(currentCoord, out var validMoves) && validMoves.Length > index)
        {
            if (validMoves[index])
            {
                // Move is allowed, update coordinates
                _currX += deltaX;
                _currY += deltaY;
                return;
            }
        }
        
        // If we reach here, it means there is a wall (validMoves[index] was false) or 
        // the coordinate was outside the map's definition (boundary wall).
        throw new InvalidOperationException("Can't go that way!");
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // Index 0: left, Change: x-1
        Move(0, -1, 0);
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // Index 1: right, Change: x+1
        Move(1, 1, 0);
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // Index 2: up, Change: y-1
        Move(2, 0, -1);
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // Index 3: down, Change: y+1
        Move(3, 0, 1);
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}