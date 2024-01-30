using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCharacter : MonoBehaviour
{
    
    public enum Direction
    {
        TOP,
        RIGHT,
        DOWN,
        LEFT
    }

    public Direction direction;
    public Vector2Int currentPosition, nextPosition;
    GameMapGenerator mapGenerator;

    private void Start()
    {
        mapGenerator = GetComponentInParent<GameMapGenerator>();
        direction = Direction.DOWN;
    }

    int[,] move = {
        { 0, -1 },  // TOPの場合
        { 1, 0 },   // RIGHTの場合
        { 0, 1 },   // DOWNの場合
        { -1, 0 }   // LEFTの場合
    };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Direction.TOP;
            Move();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.RIGHT;
            Move();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.DOWN;
            Move();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.LEFT;
            Move();
        }
    }

    void Move()
    {
        nextPosition = currentPosition + new Vector2Int(move[(int)direction, 0], move[(int)direction, 1]);
        if (mapGenerator.GetNextTileType(nextPosition) == GameMapGenerator.MapTileType.GOAL)
        {
            SceneManager.LoadScene("maze-02-goal");
        }
        if (mapGenerator.GetNextTileType(nextPosition) != GameMapGenerator.MapTileType.WALL)
        {
            transform.localPosition = mapGenerator.GetScreenPosition(nextPosition);
            currentPosition = nextPosition;
        }
    }
}
