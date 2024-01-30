using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player3 : MonoBehaviour
{

    public enum MovementDirection
    {
        Top,
        Right,
        Down,
        Left
    }
    public MovementDirection currentDirection;
    public Vector2Int currentPosition3, nextPosition3;
    GameMapGenerator1 mapGenerator3;

    private void Start()
    {
        mapGenerator3 = GetComponentInParent<GameMapGenerator1>();
        currentDirection = MovementDirection.Down;
    }
    int[,] movementOffsets = {
        { 0, -1 },  // Topの場合
        { 1, 0 },   // Rightの場合
        { 0, 1 },   // Downの場合
        { -1, 0 }   // Leftの場合
    };
    private void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentDirection = MovementDirection.Top;
            Move();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentDirection = MovementDirection.Right;
            Move();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentDirection = MovementDirection.Down;
            Move();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentDirection = MovementDirection.Left;
            Move();
        }
    }
    void Move()
    {
        nextPosition3 = currentPosition3 + new Vector2Int(movementOffsets[(int)currentDirection, 0], movementOffsets[(int)currentDirection, 1]);
        if (mapGenerator3.GetNextTileType1(nextPosition3) == GameMapGenerator1.MapTileType1.GOAL)
        {
            SceneManager.LoadScene("maze-11-goal");
        }
        if (mapGenerator3.GetNextTileType1(nextPosition3) != GameMapGenerator1.MapTileType1.WALL)
        {
            transform.localPosition = mapGenerator3.GetScreenPosition3(nextPosition3);
            currentPosition3 = nextPosition3;
        }
    }
}

