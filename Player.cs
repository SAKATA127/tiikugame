using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public enum DIRECTION
    {
        TOP,
        RIGHT,
        DOWN,
        LEFT
    }

    public DIRECTION direction;
    //追記　nextPosを定義
    public Vector2Int currentPos, nextPos;
    MapGenerator mapGenerator;
    
private void Start()
{
    // もしプレイヤーが直接マップに配置されている場合
    mapGenerator = GetComponentInParent<MapGenerator>();
    
    // もしプレイヤーが子オブジェクトとして配置されている場合
    //mapGenerator = transform.parent.GetComponent<MapGenerator>();

    direction = DIRECTION.DOWN;
}
    //追記
    int[,] move = { 
      { 0, -1 },  //TOPの場合
      { 1, 0 },   //RIGHTの場合
      { 0, 1 },   //DOWNの場合
      { -1, 0 }   //LEFTの場合
    };
    
    //修正　入力時に_move関数を呼ぶようにする。
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = DIRECTION.TOP;
            _move();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = DIRECTION.RIGHT;
            _move();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = DIRECTION.DOWN;
            _move();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = DIRECTION.LEFT;
            _move();
        }
    }
    
    void _move()
    {
        nextPos = currentPos + new Vector2Int(move[(int)direction, 0], move[(int)direction, 1]);

        // Player.cs の _move 関数内
        if (mapGenerator.GetNextMapType(nextPos) == MapGenerator.MAP_TYPE.GOAL)
        {
            Debug.Log("Goal Reached!");
            
            // ゴールに到達した時の処理を追加する
            // 例: 次のステージに進む、ゲームクリアの処理を行うなど
            
            // ゴールしたらGoalSceneに遷移する
            SceneManager.LoadScene("maze-01-goal"); // "GoalScene"は遷移先のシーン名に変更してください
        }

        //修正　MAP_TYPEがWALL以外なら移動の処理をする
        if(mapGenerator.GetNextMapType(nextPos) != MapGenerator.MAP_TYPE.WALL)
        {
            transform.localPosition = mapGenerator.ScreenPos(nextPos);
            currentPos = nextPos;
        }
    }
}