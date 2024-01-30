using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMapGenerator1 : MonoBehaviour
{
    [SerializeField] TextAsset mapText;
    [SerializeField] GameObject[] prefabs;


    public enum MapTileType1
    {
        GROUND, //0
        WALL,   //1
        PLAYER,  //2
        GOAL     //3
    }


    public MapTileType1 GetNextTileType1(Vector2Int position)
    {
        return mapTiles1[position.x, position.y];
    }

    MapTileType1[,] mapTiles1;

    float tileSize1;
    
    Vector2 centerPosition1;

    void Start()
    {
        LoadMapData1();
        CreateMap1();
    }

    void LoadMapData1()
    {
        string[] mapLines1 = mapText.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        int rows1 = mapLines1.Length;
        int cols1 = mapLines1[0].Split(new char[] { ',' }).Length;
        mapTiles1 = new MapTileType1[cols1, rows1];

        for (int y = 0; y < rows1; y++)
        {
            string[] mapValues1 = mapLines1[y].Split(new char[] { ',' });

            for (int x = 0; x < cols1; x++)
            {
                mapTiles1[x, y] = (MapTileType1)int.Parse(mapValues1[x]);
            }
        }
    }

    void CreateMap1()
    {
        tileSize1 = prefabs[1].GetComponent<SpriteRenderer>().bounds.size.x;

        if (mapTiles1.GetLength(0) % 2 == 0)
        {
            centerPosition1.x = mapTiles1.GetLength(0) / 2 * tileSize1 - (tileSize1 / 2);
        }
        else
        {
            centerPosition1.x = mapTiles1.GetLength(0) / 2 * tileSize1;
        }

        if (mapTiles1.GetLength(1) % 2 == 0)
        {
            centerPosition1.y = mapTiles1.GetLength(1) / 2 * tileSize1 - (tileSize1 / 2);
        }
        else
        {
            centerPosition1.y = mapTiles1.GetLength(1) / 2 * tileSize1;
        }

        for (int y = 0; y < mapTiles1.GetLength(1); y++)
        {
            for (int x = 0; x < mapTiles1.GetLength(0); x++)
            {
                Vector2Int position = new Vector2Int(x, y);

                GameObject groundTile = Instantiate(prefabs[(int)MapTileType1.GROUND], transform);
                GameObject mapTile = Instantiate(prefabs[(int)mapTiles1[x, y]], transform);

                groundTile.transform.position = GetScreenPosition3(position);
                mapTile.transform.position = GetScreenPosition3(position);

                if (mapTiles1[x, y] == MapTileType1.PLAYER)
                {
                    mapTile.GetComponent<Player3>().currentPosition3 = position;
                }
            }
        }
    }

    public Vector2 GetScreenPosition3(Vector2Int position)
    {
        return new Vector2(
            position.x * tileSize1 - centerPosition1.x,
            -(position.y * tileSize1 - centerPosition1.y));
    }
}
