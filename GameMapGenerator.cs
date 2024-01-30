using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMapGenerator : MonoBehaviour
{
    [SerializeField] TextAsset mapText;
    [SerializeField] GameObject[] prefabs;


    public enum MapTileType
    {
        GROUND, //0
        WALL,   //1
        PLAYER,  //2
        GOAL     //3
    }


    public MapTileType GetNextTileType(Vector2Int position)
    {
        return mapTiles[position.x, position.y];
    }

    MapTileType[,] mapTiles;

    float tileSize;
    
    Vector2 centerPosition;

    void Start()
    {
        LoadMapData();
        CreateMap();
    }

    void LoadMapData()
    {
        string[] mapLines = mapText.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        int rows = mapLines.Length;
        int cols = mapLines[0].Split(new char[] { ',' }).Length;
        mapTiles = new MapTileType[cols, rows];

        for (int y = 0; y < rows; y++)
        {
            string[] mapValues = mapLines[y].Split(new char[] { ',' });

            for (int x = 0; x < cols; x++)
            {
                mapTiles[x, y] = (MapTileType)int.Parse(mapValues[x]);
            }
        }
    }

    void CreateMap()
    {
        tileSize = prefabs[1].GetComponent<SpriteRenderer>().bounds.size.x;

        if (mapTiles.GetLength(0) % 2 == 0)
        {
            centerPosition.x = mapTiles.GetLength(0) / 2 * tileSize - (tileSize / 2);
        }
        else
        {
            centerPosition.x = mapTiles.GetLength(0) / 2 * tileSize;
        }

        if (mapTiles.GetLength(1) % 2 == 0)
        {
            centerPosition.y = mapTiles.GetLength(1) / 2 * tileSize - (tileSize / 2);
        }
        else
        {
            centerPosition.y = mapTiles.GetLength(1) / 2 * tileSize;
        }

        for (int y = 0; y < mapTiles.GetLength(1); y++)
        {
            for (int x = 0; x < mapTiles.GetLength(0); x++)
            {
                Vector2Int position = new Vector2Int(x, y);

                GameObject groundTile = Instantiate(prefabs[(int)MapTileType.GROUND], transform);
                GameObject mapTile = Instantiate(prefabs[(int)mapTiles[x, y]], transform);

                groundTile.transform.position = GetScreenPosition(position);
                mapTile.transform.position = GetScreenPosition(position);

                if (mapTiles[x, y] == MapTileType.PLAYER)
                {
                    mapTile.GetComponent<PlayerCharacter>().currentPosition = position;
                }
            }
        }
    }

    public Vector2 GetScreenPosition(Vector2Int position)
    {
        return new Vector2(
            position.x * tileSize - centerPosition.x,
            -(position.y * tileSize - centerPosition.y));
    }
}
