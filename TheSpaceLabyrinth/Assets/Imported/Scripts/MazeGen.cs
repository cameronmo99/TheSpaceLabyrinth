using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour

{
    public GameObject GameManager;
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject WallHorizontal;
    public GameObject WallVertical;
    public GameObject Goal;
    public GameObject SinglePlayerSpawn;
    public List<GameObject> MazeTiles;
    public int ListCount;
    public int MazeTileRandomNumber;
    public GameObject Tile;
    public float RowAlignment;
    public GameObject LastTile;
    public Vector3 WallPosition;

    public bool SpawnSpawned = false;

    public Vector3 Position;
    public float WantedRows;
    public float WantedColumns;
    public int Column;
    public int Row;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the GameManager
        GameManager = GameObject.Find("GameManager");

        //Sets How Many Rows and Columns are wanted from GameManager
        WantedRows = GameObject.Find("GameManager").GetComponent<UIManager>().RowsWanted;
        WantedColumns = GameObject.Find("GameManager").GetComponent<UIManager>().ColumnsWanted;

        //Gets the Amount of Maze Tiles in the List and Sets Starts Positions
        Row = Row + 1;
        ListCount = MazeTiles.Count;
        Position = new Vector3(0, 0, 0);
        WallPosition = new Vector3(-15, 2.5f, 0);
        RowAlignment = 30 * WantedColumns;
        GenerateMaze();
        SpawnWalls();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Gets a Random Tile
    public void GetTile()
    {
        MazeTileRandomNumber = Random.Range(0, ListCount);
        Tile = MazeTiles[MazeTileRandomNumber];
    }

    public void GenerateMaze()
    {

        MazeColumn();

        //if (Column == WantedColumns)
        {
            //Instantiates the Rows
            while(Row < WantedRows)
            {
                Row++;
                Position = Position + new Vector3(+30, 0, -RowAlignment);
                Column = 0;
                MazeColumn();
            }
            Position = Position + new Vector3(0, 0, -30);
            Instantiate(Goal, Position, Quaternion.identity);
            Destroy(LastTile);



        }
    }

    public void MazeColumn()
    {
        //Instantiates the Columns
        while (Column < WantedColumns)
        {
            if (SpawnSpawned == false)
            {
                Instantiate(SinglePlayerSpawn, Position, Quaternion.identity);
                SpawnSpawned = true;
            }
            else
            {
                GetTile();
                LastTile = Instantiate(Tile, Position, Quaternion.identity);
            }
            Position = Position + new Vector3(0, 0, +30);
            Column++;
        }
    }
    public void SpawnWalls()
    {
        //Spawns the Walls
        Row = 1;
        Column = 1;
        SpawnWallsTop();
        Row = 1;
        Column = 1;
        SpawnWallsLeft();
        Row = 1;
        Column = 1;
        SpawnWallsRight();
        Row = 1;
        Column = 1;
        SpawnWallsBotton();
        Row = 1;
        Column = 1;
    }

    public void SpawnWallsTop()
    {
        Instantiate(WallHorizontal, WallPosition, Quaternion.identity);
        while (Column < WantedColumns)
        {
            WallPosition = WallPosition + new Vector3(0, 0, +30);
            Instantiate(WallHorizontal, WallPosition, Quaternion.identity);
            Column++;
         }
    }

    public void SpawnWallsLeft()
    {
        WallPosition = new Vector3 (0, 2.5f, -15);
        Instantiate(WallVertical, WallPosition, Quaternion.Euler(0,90f,0));
        while (Row < WantedRows)
        {
            WallPosition = WallPosition + new Vector3(+30 , 0, 0);
            Instantiate(WallVertical, WallPosition, Quaternion.Euler(0, 90f, 0));
            Row++;
        }

    }

    public void SpawnWallsRight()
    {
        WallPosition = Position;
        WallPosition = WallPosition + new Vector3(0, 2.5f, 15);
        Instantiate(WallVertical, WallPosition, Quaternion.Euler(0, 90f, 0));
        while (Row < WantedRows)
        {
            WallPosition = WallPosition + new Vector3(-30, 0, 0);
            Instantiate(WallVertical, WallPosition, Quaternion.Euler(0, 90f, 0));
            Row++;
        }

    }

    public void SpawnWallsBotton()
    {
        WallPosition = Position;
        WallPosition = WallPosition + new Vector3(15, 2.5f, 0);
        Instantiate(WallHorizontal, WallPosition, Quaternion.identity);
        while (Column < WantedColumns)
        {
            WallPosition = WallPosition + new Vector3(0, 0, -30);
            Instantiate(WallHorizontal, WallPosition, Quaternion.identity);
            Column++;
        }
    }
}
